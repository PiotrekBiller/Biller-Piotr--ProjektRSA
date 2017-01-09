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
using System.Numerics;
using SzyfrowanieRSA;

namespace Klient
{
    public partial class frmKlient : Form
    {
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
        
        public frmKlient()
        {
            InitializeComponent();
            /*
            liczba = zm_e.liczba_p_q();
            liczba = zm_e.liczba_p_q();
            iloczyn_p_q = zm_e.iloczyn_p_q();
            ee = zm_e.zmienna_e;
            d = zm_d.licz_klucz_d(ee, liczba);
            */
            iloczyn_p_q = 368177;
            ee = 7;
            d = 52423;
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
        private void frmKlient_Load(object sender, EventArgs e)
        {

        }
        private void frmKlient_FormClosed(object sender, EventArgs e)
        {
            if (czy_polaczono)
            {
                w.Write(KomunikatyKlienta.Rozlacz);
                klient.Close();
                czy_polaczono = false;
            }
            Polaczenie.CancelAsync();
            Odbieranie.CancelAsync();
        }
        private void Polaczenie_DoWork(object sender, DoWorkEventArgs e)
        {
            klient = new TcpClient();
            wyswietl(txtLog, "Próbuje się połączyć\n");
            klient.Connect(IPAddress.Parse(txtIP.Text), int.Parse(txtPort.Text));
            wyswietl(txtLog, "Połączenie nawiązane\nŻądam zezwolenia\n");
            
            NetworkStream stream = klient.GetStream();
            w = new BinaryWriter(stream);
            r = new BinaryReader(stream);

            w.Write(KomunikatyKlienta.Zadaj);
            if (r.ReadString() == KomunikatySerwera.OK)
            {
                wyswietl(txtLog, "Połączono\n");
                czy_polaczono = true;
                cmdWyslij.Enabled = true;
                Odbieranie.RunWorkerAsync();

                ee2 = 41;
                iloczyn_p_q2 = 97897;
                label_e2.Text = ee2.ToString();
                label_n2.Text = iloczyn_p_q2.ToString();
            }
            else
            {
                wyswietl(txtLog, "Brak odpowiedzi\nRozlaczono\n");
                czy_polaczono = false;
                if (klient != null) klient.Close();
                cmdWyslij.Enabled = false;
                cmdPolacz.Text = "Połącz";
            }
        }
        private void cmdPolacz_Click(object sender, EventArgs e)
        {
            if (cmdPolacz.Text == "Połącz")
            {
                Polaczenie.RunWorkerAsync();
                cmdPolacz.Text = "Rozłącz";
            }
            else
            {
                if (czy_polaczono)
                {
                    w.Write(KomunikatyKlienta.Rozlacz);
                    klient.Close();
                    czy_polaczono = false;
                }
                cmdPolacz.Text = "Połącz";
                cmdWyslij.Enabled = false;
                wyswietl(txtLog, "Rozlaczono\n");                
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
            while ((tekst = r.ReadString()) != KomunikatySerwera.Rozlacz)
            {
                txtOdbieranieRSA.Text = "";
                wyswietl(txtOdbieranieRSA, tekst);
                string odszyfr = Odszyfrowywanie(tekst);
                wyswietl(txtOdbieranie, "===== Serwer =====\n" + odszyfr + '\n');
            }
            cmdWyslij.Enabled = false;
            wyswietl(txtLog, "Rozlaczono\n");
            cmdPolacz.Text = "Połącz";
            czy_polaczono = false;
            if (klient != null) klient.Close();
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
            wyswietl(txtOdbieranie, "===== Klient =====\n" + tekst + '\n');
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
                BigInteger zmienna2 = BigInteger.ModPow(zmienna, ee2, iloczyn_p_q2); //3e 4n
                bloki[i] = (int)zmienna2;
            }
            string szyfr;
            szyfr = String.Join(" ", bloki);
            return szyfr;
        }        
    }
}
