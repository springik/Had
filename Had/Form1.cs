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
        int s, m = 0;
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            bubble.Location = new Point(rnd.Next(0, this.Width), rnd.Next(0, this.Height));
        }
        void moveBubble(Panel bubble) //posune bublinu na nahodnou pozici
        {
            bubble.Location = new Point(rnd.Next(0, this.Width), rnd.Next(0, this.Height));
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                if(panel1.Location.X + panel1.Width + 20 < this.Width) //kontrola kolize s hernim prostorem (horizontalni)
                {
                    panel1.Location = new Point(panel1.Location.X + 10, panel1.Location.Y);
                }
                else //restartovani pozice na druhe strane h. p.
                {
                    panel1.Location = new Point(0 , panel1.Location.Y);
                }
                //if ()
                //{
                //    moveBubble(bubble);
                //}
            }
            else if (e.KeyCode == Keys.A)
            {
                if(panel1.Location.X > 0)//kontrola kolize s hernim prostorem z druhe strany (horizontalni)
                {
                    panel1.Location = new Point(panel1.Location.X - 10, panel1.Location.Y);
                }
                else //restartovani pozice na druhe strane h. p.
                {
                    panel1.Location = new Point(this.Width - panel1.Width - panel1.Width/3, panel1.Location.Y);
                }
            }
            else if (e.KeyCode == Keys.W)
            {
                if(panel1.Location.Y > 0)
                {
                    panel1.Location = new Point(panel1.Location.X, panel1.Location.Y - 10);// kontrola kolize s hp. (vertikálně)
                }
                else
                {
                    panel1.Location = new Point(panel1.Location.X, this.Height - panel1.Height * 2);// restartování pozice z druhé strany h.p.
                }
            }
            else if (e.KeyCode == Keys.S)
            {
                if(panel1.Location.Y + panel1.Height + 40 < this.Height)// kontrola kolize s h. p. (vert.)
                {
                    panel1.Location = new Point(panel1.Location.X, panel1.Location.Y + 10);
                }
                else
                {
                    panel1.Location = new Point(panel1.Location.X, 0);//restartovani pozice z druhe strany h. p.
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
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
                label1.Text = m + ":0" + s;
            }
            else
            {
                label1.Text = m + ":" + s;
            }
        }
    }
}
