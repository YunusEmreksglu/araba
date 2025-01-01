using System;
using System.Drawing;
using System.Windows.Forms;


namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        int skor = 0; 
        System.Windows.Forms.Timer oyunZamanlayici;
        Random rastgele = new Random();

        public Form1()
        {
            InitializeComponent();
            this.Text = "Araba Oyunu";
            this.KeyPreview = true;

            

            
            oyunZamanlayici = new System.Windows.Forms.Timer
            {
                Interval = 100 
            };
            oyunZamanlayici.Tick += OyunZamanlayici_Tick;
            oyunZamanlayici.Start();



            
        }

        private void OyunZamanlayici_Tick(object sender, EventArgs e)
        {

            skor++;
            label1.Text=($"{skor/60}:{skor % 60}");



            if (rastgele.Next(100) < 10) 
            {
                Button engel = new Button
                {
                    Text = "Engel",
                    Size = new Size(60, 20),
                    Location = new Point(this.ClientSize.Width, rastgele.Next(this.ClientSize.Height - 20)),
                    BackColor = Color.Red
                };
                this.Controls.Add(engel);
            }

            
            foreach (Control kontrol in this.Controls)
            {
                if (kontrol is Button && kontrol.Text == "Engel")
                {
                    kontrol.Left -= 5;


                    if (araba.Bounds.IntersectsWith(kontrol.Bounds))
                    {
                        oyunZamanlayici.Stop();
                        MessageBox.Show($"Oyun Bitti! Skor:{skor/60}:{skor % 60}");
                        Application.Exit();
                    }
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            

            
            if (e.KeyCode == Keys.W && araba.Top > 0)
                araba.Top -= 10;
            if (e.KeyCode == Keys.S && araba.Top < this.ClientSize.Height - araba.Height)
                araba.Top += 10;
            if (e.KeyCode == Keys.A && araba.Left > 0)
                araba.Left -= 10;
            if (e.KeyCode == Keys.D && araba.Left < this.ClientSize.Width - araba.Width)
                araba.Left += 10;
        }
    }
}