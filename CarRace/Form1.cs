using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRace
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lblGameOver.Visible = false;
            btnTryAgain.Visible = false;
        }
      

        int gamespeed = 2;
        int tickCount = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            // oyun hızı ayarı
            moveline(gamespeed);
            tickCount++;
            enemy(gamespeed);
            gameover();
            coins(gamespeed);
            coincollection();

            if (tickCount % 250 == 0) // Her 600 tick yaklaşık 10 saniyeye denk gelir.
            {
                if (gamespeed < 25)
                {
                    gamespeed++;
                }
                else
                {
                    gamespeed = 1;
                }
                tickCount = 0; 
            }
        }
        int collectedcoin = 0;
        void coincollection()
        {
            // coinleri toplayınca sayac sayar
            if (pbRaceCar.Bounds.IntersectsWith(pbcoin1.Bounds))
            {
                collectedcoin++;
                lblCoins.Text = "Coins : " + collectedcoin.ToString();
                x = rndm.Next(0, 250);
                pbcoin1.Location = new Point(x, 0);
            }
            if (pbRaceCar.Bounds.IntersectsWith(pbcoin2.Bounds))
            {
                collectedcoin++;
                lblCoins.Text = "Coins : " + collectedcoin.ToString();
                x = rndm.Next(0, 250);
                pbcoin2.Location = new Point(x, 0);
            }
            if (pbRaceCar.Bounds.IntersectsWith(pbcoin3.Bounds))
            {
                collectedcoin++;
                lblCoins.Text = "Coins : " + collectedcoin.ToString();
                x = rndm.Next(0, 250);
                pbcoin3.Location = new Point(x, 0);
            }
        }

        Random rndm = new Random();
        int x;
        void enemy(int speed)
        {
            // Rastgele konumlardan düşman arabaların çıkıp haraket etmesi için sürekli
            if (pbEnemy1.Top >= 400)
            { 
                x = rndm.Next(0,250);
                pbEnemy1.Location = new Point(x, 0);
            }
            else { pbEnemy1.Top += speed; }
            if (pbEnemy3.Top >= 400)
            {
                x = rndm.Next(0, 250);
                pbEnemy3.Location = new Point(x, 0);
            }
            else { pbEnemy3.Top += speed; }
            if (pbEnemy4.Top >= 400)
            {
                x = rndm.Next(0, 250);
                pbEnemy4.Location = new Point(x, 0);
            }
            else { pbEnemy4.Top += speed; }

        }
        void coins(int speed)
        {
            // coinlerin rastgele çıkıp haraket etmesi için
            if (pbcoin1.Top >= 400)
            {
                x = rndm.Next(0, 250);
                pbcoin1.Location = new Point(x, 0);
            }
            else { pbcoin1.Top += speed; }
            if (pbcoin2.Top >= 400)
            {
                x = rndm.Next(0, 250);
                pbcoin2.Location = new Point(x, 0);
            }
            else { pbcoin2.Top += speed; }

            if (pbcoin3.Top >= 400)
            {
                x = rndm.Next(0, 250);
                pbcoin3.Location = new Point(x, 0);
            }
            else { pbcoin3.Top += speed; }

        }


        void gameover()
        {
            // düşman arabalara çarpınca oyun bitmesi için
            if(pbRaceCar.Bounds.IntersectsWith(pbEnemy1.Bounds))
            {
                timer1.Enabled = false;
                lblGameOver.Visible = true;
                btnTryAgain.Visible = true;
            }
            if (pbRaceCar.Bounds.IntersectsWith(pbEnemy3.Bounds))
            {
                timer1.Enabled = false;
                lblGameOver.Visible = true;
                btnTryAgain.Visible = true;
            }
            if (pbRaceCar.Bounds.IntersectsWith(pbEnemy4.Bounds))
            {
                timer1.Enabled = false;
                lblGameOver.Visible = true;
                btnTryAgain.Visible = true;
            }
        }
        void moveline(int speed)
        {
            // Haraket ediyormuş gibi göstermek için yol çizgilerini haraket ettiriyoruz.
           if(pictureBox1.Top>= 450)
            {  pictureBox1.Top = 0; }
           else { pictureBox1.Top += speed; }

            if (pictureBox2.Top >= 450)
            { pictureBox2.Top = 0; }
            else { pictureBox2.Top += speed; }

            if (pictureBox3.Top >= 450)
            { pictureBox3.Top = 0; }
            else { pictureBox3.Top += speed; }
            
            if (pictureBox4.Top >= 450)
            { pictureBox4.Top = 0; }
            else { pictureBox4.Top += speed; }
           

        }
       
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // yarış arabamızın haraket etmesi
            if (e.KeyCode == Keys.Left)
            {
                if(pbRaceCar.Left >0)
                pbRaceCar.Left +=-gamespeed-3;
            }if (e.KeyCode == Keys.Right)
            {
                if (pbRaceCar.Right < 280)
                    pbRaceCar.Left += gamespeed+3;
            }
            if (e.KeyCode == Keys.Up)
            {
                if (pbRaceCar.Top > 0)
                    pbRaceCar.Top -= gamespeed-2;
                
            }
            if (e.KeyCode == Keys.Down)
            {
                if (pbRaceCar.Bottom < this.ClientSize.Height)
                    pbRaceCar.Top += gamespeed + 2;
            }
        }

        private void btnTryAgain_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Oyunu yeniden başlatmak istiyor musunuz?", "Yeniden Başlat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Kullanıcı Evet'i seçerse, formu yeniden başlat
            if (result == DialogResult.Yes)
            {
                Application.Restart();
            }
        }
    }
}
