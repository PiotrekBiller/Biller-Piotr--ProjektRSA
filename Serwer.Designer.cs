﻿namespace Serwer
{
    partial class frmSerwer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtOdbieranie = new System.Windows.Forms.RichTextBox();
            this.txtWysylane = new System.Windows.Forms.RichTextBox();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.cmdSluchaj = new System.Windows.Forms.Button();
            this.cmdWyslij = new System.Windows.Forms.Button();
            this.Polaczenie = new System.ComponentModel.BackgroundWorker();
            this.Odbieranie = new System.ComponentModel.BackgroundWorker();
            this.txtOdbieranieRSA = new System.Windows.Forms.RichTextBox();
            this.txtWysylaneRSA = new System.Windows.Forms.RichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_n = new System.Windows.Forms.Label();
            this.label_e = new System.Windows.Forms.Label();
            this.label_d = new System.Windows.Forms.Label();
            this.label_n2 = new System.Windows.Forms.Label();
            this.label_e2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtOdbieranie
            // 
            this.txtOdbieranie.Location = new System.Drawing.Point(12, 88);
            this.txtOdbieranie.Name = "txtOdbieranie";
            this.txtOdbieranie.ReadOnly = true;
            this.txtOdbieranie.Size = new System.Drawing.Size(267, 135);
            this.txtOdbieranie.TabIndex = 0;
            this.txtOdbieranie.Text = "";
            // 
            // txtWysylane
            // 
            this.txtWysylane.Location = new System.Drawing.Point(12, 254);
            this.txtWysylane.Name = "txtWysylane";
            this.txtWysylane.Size = new System.Drawing.Size(267, 90);
            this.txtWysylane.TabIndex = 1;
            this.txtWysylane.Text = "";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(12, 437);
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(267, 62);
            this.txtLog.TabIndex = 2;
            this.txtLog.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(299, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nr portu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(12, 421);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Log";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(350, 118);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(66, 20);
            this.txtPort.TabIndex = 5;
            this.txtPort.Text = "8000";
            // 
            // cmdSluchaj
            // 
            this.cmdSluchaj.Location = new System.Drawing.Point(302, 144);
            this.cmdSluchaj.Name = "cmdSluchaj";
            this.cmdSluchaj.Size = new System.Drawing.Size(114, 39);
            this.cmdSluchaj.TabIndex = 6;
            this.cmdSluchaj.Text = "Czekaj na połączenie";
            this.cmdSluchaj.UseVisualStyleBackColor = true;
            this.cmdSluchaj.Click += new System.EventHandler(this.cmdSluchaj_Click);
            // 
            // cmdWyslij
            // 
            this.cmdWyslij.Enabled = false;
            this.cmdWyslij.Location = new System.Drawing.Point(285, 275);
            this.cmdWyslij.Name = "cmdWyslij";
            this.cmdWyslij.Size = new System.Drawing.Size(107, 46);
            this.cmdWyslij.TabIndex = 7;
            this.cmdWyslij.Text = "Wyślij";
            this.cmdWyslij.UseVisualStyleBackColor = true;
            this.cmdWyslij.Click += new System.EventHandler(this.cmdWyslij_Click);
            // 
            // Polaczenie
            // 
            this.Polaczenie.WorkerSupportsCancellation = true;
            this.Polaczenie.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Polaczenie_DoWork);
            // 
            // Odbieranie
            // 
            this.Odbieranie.WorkerSupportsCancellation = true;
            this.Odbieranie.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Odbieranie_DoWork);
            // 
            // txtOdbieranieRSA
            // 
            this.txtOdbieranieRSA.Location = new System.Drawing.Point(12, 25);
            this.txtOdbieranieRSA.Name = "txtOdbieranieRSA";
            this.txtOdbieranieRSA.ReadOnly = true;
            this.txtOdbieranieRSA.Size = new System.Drawing.Size(267, 35);
            this.txtOdbieranieRSA.TabIndex = 8;
            this.txtOdbieranieRSA.Text = "";
            // 
            // txtWysylaneRSA
            // 
            this.txtWysylaneRSA.Location = new System.Drawing.Point(12, 373);
            this.txtWysylaneRSA.Name = "txtWysylaneRSA";
            this.txtWysylaneRSA.ReadOnly = true;
            this.txtWysylaneRSA.Size = new System.Drawing.Size(267, 35);
            this.txtWysylaneRSA.TabIndex = 9;
            this.txtWysylaneRSA.Text = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(324, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "d = ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(324, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "e = ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(324, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "n = ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(324, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "e = ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(324, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "n = ";
            // 
            // label_n
            // 
            this.label_n.AutoSize = true;
            this.label_n.Location = new System.Drawing.Point(345, 18);
            this.label_n.Name = "label_n";
            this.label_n.Size = new System.Drawing.Size(16, 13);
            this.label_n.TabIndex = 29;
            this.label_n.Text = "---";
            // 
            // label_e
            // 
            this.label_e.AutoSize = true;
            this.label_e.Location = new System.Drawing.Point(345, 31);
            this.label_e.Name = "label_e";
            this.label_e.Size = new System.Drawing.Size(16, 13);
            this.label_e.TabIndex = 30;
            this.label_e.Text = "---";
            // 
            // label_d
            // 
            this.label_d.AutoSize = true;
            this.label_d.Location = new System.Drawing.Point(345, 44);
            this.label_d.Name = "label_d";
            this.label_d.Size = new System.Drawing.Size(16, 13);
            this.label_d.TabIndex = 31;
            this.label_d.Text = "---";
            // 
            // label_n2
            // 
            this.label_n2.AutoSize = true;
            this.label_n2.Location = new System.Drawing.Point(345, 73);
            this.label_n2.Name = "label_n2";
            this.label_n2.Size = new System.Drawing.Size(16, 13);
            this.label_n2.TabIndex = 32;
            this.label_n2.Text = "---";
            // 
            // label_e2
            // 
            this.label_e2.AutoSize = true;
            this.label_e2.Location = new System.Drawing.Point(345, 89);
            this.label_e2.Name = "label_e2";
            this.label_e2.Size = new System.Drawing.Size(16, 13);
            this.label_e2.TabIndex = 33;
            this.label_e2.Text = "---";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Ostatnia otrzymana wiadomość (Szyfr RSA)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(12, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Wiadomości";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Green;
            this.label7.Location = new System.Drawing.Point(12, 238);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Napisz wiadomość: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Green;
            this.label8.Location = new System.Drawing.Point(12, 357);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(207, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "Ostatnia wysyłana wiadomość (Szyfr RSA)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(299, 5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(123, 13);
            this.label12.TabIndex = 38;
            this.label12.Text = "Dane szyfrujące serwera";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(299, 60);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(117, 13);
            this.label13.TabIndex = 39;
            this.label13.Text = "Dane szyfrujące klienta";
            // 
            // frmSerwer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(434, 511);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_e2);
            this.Controls.Add(this.label_n2);
            this.Controls.Add(this.label_d);
            this.Controls.Add(this.label_e);
            this.Controls.Add(this.label_n);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtWysylaneRSA);
            this.Controls.Add(this.txtOdbieranieRSA);
            this.Controls.Add(this.cmdWyslij);
            this.Controls.Add(this.cmdSluchaj);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.txtWysylane);
            this.Controls.Add(this.txtOdbieranie);
            this.MaximizeBox = false;
            this.Name = "frmSerwer";
            this.Text = "Serwer";
            this.Load += new System.EventHandler(this.frmSerwer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtOdbieranie;
        private System.Windows.Forms.RichTextBox txtWysylane;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button cmdSluchaj;
        private System.Windows.Forms.Button cmdWyslij;
        private System.ComponentModel.BackgroundWorker Polaczenie;
        private System.ComponentModel.BackgroundWorker Odbieranie;
        private System.Windows.Forms.RichTextBox txtOdbieranieRSA;
        private System.Windows.Forms.RichTextBox txtWysylaneRSA;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_n;
        private System.Windows.Forms.Label label_e;
        private System.Windows.Forms.Label label_d;
        private System.Windows.Forms.Label label_n2;
        private System.Windows.Forms.Label label_e2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}

