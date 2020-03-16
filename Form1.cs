using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace carracing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int speed;
        PictureBox[] road = new PictureBox[6];
        private void Form1_Load(object sender, EventArgs e)
        {
            speed = 5;
            road[0] = pictureBox1;
            road[1] = pictureBox2;
            road[2] = pictureBox3;
            road[3] = pictureBox4;
            road[4] = pictureBox5;
            road[5] = pictureBox6;

        }
        Random r = new Random();
        int x, y;

        void coins(int speed)
        {
            if (coin1.Top >= 500)
            {
                x = r.Next(0, 200);
                coin1.Location = new Point(x, 0);
            }
            else {coin1.Top += speed;  }
            if (coin2.Top >= 500)
            {
                x = r.Next(0, 200);
                coin2.Location = new Point(x, 0);
            }
            else { coin2.Top += speed; }
            if (coin3.Top >= 500)
            {
                x = r.Next(50, 300);
                coin3.Location = new Point(x, 0);
            }
            else { coin3.Top += speed; }
            if (coin4.Top >= 500)
            {
                x = r.Next(0, 400);
                coin4.Location = new Point(x, 0);
            }
            else { coin4.Top += speed; }


        }
        int collectedcoins = 0;
        void coinscollection()
        {
            if(carbox.Bounds.IntersectsWith(coin1.Bounds))
            {
                collectedcoins++;
                label1.Text = "coins=" + collectedcoins.ToString();
                x = r.Next(50, 300);
                coin1.Location = new Point(x, 0);

            }
            if (carbox.Bounds.IntersectsWith(coin2.Bounds))
            {
                collectedcoins++;
                label1.Text = "coins=" + collectedcoins.ToString();
                x = r.Next(50, 300);
                coin2.Location = new Point(x, 0);

            }
            if (carbox.Bounds.IntersectsWith(coin3.Bounds))
            {
                collectedcoins++;
                label1.Text = "coins=" + collectedcoins.ToString();
                x = r.Next(50, 300);
                coin3.Location = new Point(x, 0);

            }
            if (carbox.Bounds.IntersectsWith(coin4.Bounds))
            {
                collectedcoins++;
                label1.Text = "coins=" + collectedcoins.ToString();
                x = r.Next(50, 300);
                coin4.Location = new Point(x, 0);

            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (var item in road)
            {
                item.Top +=8 ;
                if (item.Top > this.Height)
                    item.Top = -item.Height;
            }
            coins(speed);
            coinscollection();
           
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
                t_right.Start();

            if (e.KeyCode == Keys.Left)
                t_left.Start();
               
        }

        private void t_right_Tick(object sender, EventArgs e)
        {
            if(carbox.Location.X<209)
            carbox.Left += 5;

        }

        private void t_left_Tick(object sender, EventArgs e)
        {
            if (carbox.Location.X>2)
            carbox.Left -= 5;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            t_left.Stop();
            t_right.Stop();

        }
        
    }
}
