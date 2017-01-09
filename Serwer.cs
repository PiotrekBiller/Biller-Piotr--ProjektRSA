using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using komunikaty;
using SzyfrowanieRSA;
using System.Numerics;


namespace Serwer
{
    public partial class frmSerwer : Form
    {
        private TcpListener listener = null;
        private TcpClient klient = null;
        private bool czy_polaczono = false;
        private BinaryReader r = null;
        private BinaryWriter w = null; 
        
        klucz_e zm_e = new klucz_e();
        klucz_d zm_d = new klucz_d();
        int ee;
        int ee2;
        int d;
        int iloczyn_p_q;
        int iloczyn_p_q2;
        int liczba;
                
        public frmSerwer()
        {
            InitializeComponent();
             /*
             liczba = zm_e.liczba_p_q();
             iloczyn_p_q = zm_e.iloczyn_p_q();
             ee = zm_e.zmienna_e;
             d = zm_d.licz_klucz_d(ee, liczba);
             */
             ee=41;
             d = 42689;
             iloczyn_p_q = 97897;            
             /*
             * Powyższe zmienne powinny być losowane, ale ze względu problemów z przesyłaniem kluczy 
             * zaraz po połączniu klient->serwer ustawiłem je domyślnie, szyfrowanie w pełni działa, 
             * klasy klucz_d, klucz_e prawidłowo liczą zmienne, powyższe zmienne zostały za pomocą 
             * tych klas wygenerowane, wysyłanie tych zmiennych jest jedynym nie działającym elementem 
             * aplikacji
             */
            label_n.Text = iloczyn_p_q.ToString();
            label_e.Text = ee.ToString();
            label_d.Text = d.ToString();
        }
        private void frmSerwer_Load(object sender, EventArgs e)
        {

        }
        private void frmSerwer_FormClosed(object sender, EventArgs e)
        {
            if (czy_polaczono)
            {
                w.Write(KomunikatySerwera.Rozlacz);
                listener.Stop();
                if (klient != null) klient.Close();
                czy_polaczono = false;
            }
            Polaczenie.CancelAsync();
            Odbieranie.CancelAsync();
        }
        private void Polaczenie_DoWork(object sender, DoWorkEventArgs e)
        {
            wyswietl(txtLog, "Czekam na połączenie\n");
            listener = new TcpListener(IPAddress.Any, int.Parse(txtPort.Text));
            listener.Start();
            while (!listener.Pending())
            {
                if (this.Polaczenie.CancellationPending)
                {
                    if (klient != null)
                        klient.Close();
                    listener.Stop();
                    czy_polaczono = false;
                    cmdSluchaj.Text = "Czekaj na połączenie";
                    return;
                }
            }
            klient = listener.AcceptTcpClient();
            wyswietl(txtLog, "Zażądano połączenia\n");
            NetworkStream stream = klient.GetStream();
            w = new BinaryWriter(stream);
            r = new BinaryReader(stream);

            if (r.ReadString() == KomunikatyKlienta.Zadaj)
            {
                w.Write(KomunikatySerwera.OK);
                wyswietl(txtLog, "Połączono\n");
                czy_polaczono = true;
                cmdWyslij.Enabled = true;
                Odbieranie.RunWorkerAsync();
                //zmienne które ustawiłem ręcznie a powinny być przesyłane
                ee2 = 7;
                iloczyn_p_q2 = 368177;
                label_e2.Text = ee2.ToString();
                label_n2.Text = iloczyn_p_q2.ToString();
            }
            else
            {
                wyswietl(txtLog, "Klient odrzucony\nRozlaczono\n");
                if (klient != null) klient.Close();
                listener.Stop();
                czy_polaczono = false;
            }
        }
        private void cmdSluchaj_Click(object sender, EventArgs e)
        {
            if (cmdSluchaj.Text == "Czekaj na połączenie")
            {
                Polaczenie.RunWorkerAsync();
                cmdSluchaj.Text = "Rozłącz";
            }
            else
            {
                if (czy_polaczono == true)
                {
                    w.Write(KomunikatySerwera.Rozlacz);
                    listener.Stop();
                    if (klient != null) klient.Close();
                    czy_polaczono = false;
                }
                wyswietl(txtLog, "Rozlaczono\n");
                cmdSluchaj.Text = "Czekaj na połączenie";
                cmdWyslij.Enabled = false;
                Polaczenie.CancelAsync();
                Odbieranie.CancelAsync();
            }
        }
        public void wyswietl(RichTextBox o, string tekst)
        {
            o.Focus();
            o.AppendText(tekst);
            o.ScrollToCaret();
        }
        private void Odbieranie_DoWork(object sender, DoWorkEventArgs e)
        {
            string tekst;
            while ((tekst = r.ReadString()) != KomunikatyKlienta.Rozlacz)
            {
                txtOdbieranieRSA.Text = "";
                wyswietl(txtOdbieranieRSA, tekst);
                string odszyfr = Odszyfrowywanie(tekst);
                wyswietl(txtOdbieranie, "===== Klient =====\n" + odszyfr + '\n');
            }
            wyswietl(txtLog, "Rozlaczono\n");
            czy_polaczono = false;
            klient.Close();
            listener.Stop();
            cmdSluchaj.Text = "Czekaj na połączenie";
            }
        private void cmdWyslij_Click(object sender, EventArgs e)
        {
            txtWysylaneRSA.Text = "";
            string tekst = txtWysylane.Text;
            if (tekst == "")
            {
                txtWysylane.Focus();
                return;
            }
            if (tekst[tekst.Length - 1] == '\n')
                tekst = tekst.TrimEnd('\n');
            
            Szyfrowanie(tekst);
            string szyfr = Szyfrowanie(tekst);

            w.Write(szyfr);
            wyswietl(txtWysylaneRSA, szyfr);
            wyswietl(txtOdbieranie, "===== Serwer =====\n" + tekst + '\n');
            txtWysylane.Text = "";
        }
        public string Odszyfrowywanie(string tekst)
        {            
            string[] Odkodowywanie = tekst.Split(new char[] { ' ' });
            int[] odkodowana = new int[Odkodowywanie.Length];
            for (int i = 0; i < Odkodowywanie.Length; i++)
            {
                odkodowana[i] = int.Parse(Odkodowywanie[i]);
            }
            for (int i = 0; i < odkodowana.Length; i++)
            {
                int zmienna = odkodowana[i];
                BigInteger zmienna2 = BigInteger.ModPow(zmienna, d, iloczyn_p_q);
                odkodowana[i] = (int)zmienna2;
            }
            char[] wiadomosc = new char[odkodowana.Length];
            for (int i = 0; i < odkodowana.Length; i++)
            {
                wiadomosc[i] = System.Convert.ToChar(odkodowana[i]);
            }
            string odszyfrowana = new string(wiadomosc);
            return odszyfrowana;
        }
        public string Szyfrowanie(string tekst)
        {
            string value = tekst;
            byte[] asciiBytes = Encoding.ASCII.GetBytes(value);
            int[] bloki = new int[value.Length];
            for (int i = 0; i < value.Length; i++)
            {
                int zmienna = asciiBytes[i];
                BigInteger zmienna2 = BigInteger.ModPow(zmienna, ee2, iloczyn_p_q2);
                bloki[i] = (int)zmienna2;
            }
            string szyfr;
            szyfr = String.Join(" ", bloki);
            return szyfr;
        }
    }
}
