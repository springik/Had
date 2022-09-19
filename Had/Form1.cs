using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Had
{
    public partial class Form1 : Form
    {
        int score;
        int s, m = 0;
        int scale = 20;
        Random rnd = new Random();
        List<Panel> tail = new List<Panel>();
        public Form1()
        {
            InitializeComponent();
            this.Height = 600;
            this.Width = 600;
            scale = panel1.Width;
            label1.Location = new Point(this.Width / 2 - label1.Width / 2, 20);
            scoreLabel.Location = new Point(this.Width/2 - scoreLabel.Width / 2 + 5, 40);
            scoreLabel.Text = "0";
            bubble.Location = new Point(rnd.Next(0, this.Width), rnd.Next(0, this.Height));
            //panel1.Location = new Point(this.Width / 2 - panel1.Width - panel1.Width / 3, this.Height / 2 - panel1.Height - panel1.Height / 3);
            panel1.Location = new Point(0,0);
            //tail.Add(panel1);
            //tail.Add(panel1);
        }
        void moveBubble(Panel bubble) //posune bublinu na nahodnou pozici
        {
            bubble.Location = new Point(rnd.Next(0, 550), rnd.Next(0, 550)); //TODO: neposouva se po gridu
        }
        void updateTail()
        {
            tail1.Location = tail[tail.Count - 2].Location;
            //foreach (var item in tail)
            //{
            //    tail{x}.Location = item.Location;
            //}
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                if(panel1.Location.X + panel1.Width + 20 < this.Width) //kontrola kolize s hernim prostorem (horizontalni)
                {
                    panel1.Location = new Point(panel1.Location.X + scale, panel1.Location.Y);
                    tail.Add(panel1);
                    updateTail();
                }
                else //restartovani pozice na druhe strane h. p.
                {
                    panel1.Location = new Point(0 , panel1.Location.Y);
                    updateTail();
                }
                if (panel1.Bounds.IntersectsWith(bubble.Bounds))//kolize hada a bublinky
                {
                    moveBubble(bubble);
                    score++;
                    updateTail();
                }
            }
            else if (e.KeyCode == Keys.A)
            {
                if(panel1.Location.X > 0)//kontrola kolize s hernim prostorem z druhe strany (horizontalni)
                {
                    panel1.Location = new Point(panel1.Location.X - scale, panel1.Location.Y);
                    tail.Add(panel1);
                    updateTail();
                }
                else //restartovani pozice na druhe strane h. p.
                {
                    panel1.Location = new Point(this.Width - panel1.Width - panel1.Width/3, panel1.Location.Y);
                    updateTail();
                }
                if (panel1.Bounds.IntersectsWith(bubble.Bounds))//kolize hada a bublinky
                {
                    moveBubble(bubble);
                    score++;
                    updateTail();
                }
            }
            else if (e.KeyCode == Keys.W)
            {
                if(panel1.Location.Y > 0)
                {
                    panel1.Location = new Point(panel1.Location.X, panel1.Location.Y - scale);// kontrola kolize s hp. (vertikálně)
                    tail.Add(panel1);
                    updateTail();
                }
                else
                {
                    panel1.Location = new Point(panel1.Location.X, this.Height - panel1.Height * 2);// restartování pozice z druhé strany h.p.
                    updateTail();
                }
                if (panel1.Bounds.IntersectsWith(bubble.Bounds))//kolize hada a bublinky
                {
                    moveBubble(bubble);
                    score++;
                    updateTail();
                }
            }
            else if (e.KeyCode == Keys.S)
            {
                if(panel1.Location.Y + panel1.Height + 40 < this.Height)// kontrola kolize s h. p. (vert.)
                {
                    panel1.Location = new Point(panel1.Location.X, panel1.Location.Y + scale);
                    tail.Add(panel1);
                    updateTail();
                }
                else
                {
                    panel1.Location = new Point(panel1.Location.X, 0);//restartovani pozice z druhe strany h. p.
                    updateTail();
                }
                if (panel1.Bounds.IntersectsWith(bubble.Bounds))//kolize hada a bublinky
                {
                    moveBubble(bubble);
                    score++;
                    updateTail();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            scoreLabel.Text = Convert.ToString(score);
            if(s < 59)
            {
                s++;
            }
            else
            {
                m++;
                s = 0;
            }
            if (s < 10)
            {
                if (m < 10)
                {
                    label1.Text = "0" + m + ":0" + s;
                }
                else
                {
                    label1.Text = m + ":0" + s;
                }
            }
            else
            {
                if(m < 10)
                {
                    label1.Text = "0" + m + ":" + s;
                }
                else
                {
                    label1.Text = m + ":" + s;
                }
                
            }
        }
    }
}
