using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Collections;

namespace Zadanie5_OSK
{
    public partial class NoweOkno : Form
    {
        public NoweOkno()
        {
            InitializeComponent();
            xt = true;
            xw = false;
            xs = false;
            i = 0;
            this.chart1.Visible = false;
            this.chart2.Visible = false;
        }
        public void onePing()
        {
            SystemSounds.Beep.Play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (xs == false)
            {
                this.button1.Text = " ";
                this.button1.Visible = false;
                Random rnd1 = new Random();
                this.LiczbaLosowa = rnd1.Next(500, 5000);
                this.timer1.Interval = this.LiczbaLosowa;
                this.timer1.Start();
                xs = true;
            }
            else
            {
                this.button1.Text = " ";
                this.button1.Visible = false;
                Random rnd1 = new Random();
                this.LiczbaLosowa = rnd1.Next(500, 5000);
                this.timer1.Interval = this.LiczbaLosowa;
                this.timer1.Start();
                this.button2.BackColor = Color.White;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (xt == true)
            {
                this.button2.BackColor = Color.Blue;
                this.start = DateTime.Now;
                this.timer1.Stop();
                xt = false;
                this.button1.Text = "Kontynuuj";
                
            }
            else
            {
                SystemSounds.Asterisk.Play();
                //Console.Beep();
                this.start = DateTime.Now;
                this.timer1.Stop();
                xt = true; ;
                this.button1.Text = "Kontynuuj";
            }
            xw = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (xw == true)
            {
                this.label5.Text = " ";
                if (i <= 9)
                {
                    this.button1.Visible = true;
                    DateTime stop = DateTime.Now;
                    TimeSpan ts = (stop - this.start);
                    this.label3.Text = ts.ToString();
                    double time = (double)ts.Milliseconds;
                    double time2 = (double)ts.Seconds;
                    if (time2 > 0)
                    {
                        T[i] = time + (time2 * 1000);
                    }
                    else
                    {
                        T[i] = time;
                    }
                    Console.WriteLine("{0,12}", this.LiczbaLosowa);
                    Console.WriteLine("{0,12}", T[i]);
                    i++;
                }
                else
                {
                    this.label5.Text = "Test zakończony";
                    this.chart1.Enabled = true;
                    this.chart1.Series["Czasy"].Points.AddXY(1, Convert.ToDouble(T[0]));
                    this.chart1.Series["Czasy"].Points.AddXY(2, Convert.ToDouble(T[2]));
                    this.chart1.Series["Czasy"].Points.AddXY(3, Convert.ToDouble(T[4]));
                    this.chart1.Series["Czasy"].Points.AddXY(4, Convert.ToDouble(T[6]));
                    this.chart1.Series["Czasy"].Points.AddXY(5, Convert.ToDouble(T[8]));
                    this.chart1.Visible = true;
                    this.chart2.Enabled = true;
                    this.chart2.Series["Czasy"].Points.AddXY(1, Convert.ToDouble(T[1]));
                    this.chart2.Series["Czasy"].Points.AddXY(2, Convert.ToDouble(T[3]));
                    this.chart2.Series["Czasy"].Points.AddXY(3, Convert.ToDouble(T[5]));
                    this.chart2.Series["Czasy"].Points.AddXY(4, Convert.ToDouble(T[7]));
                    this.chart2.Series["Czasy"].Points.AddXY(5, Convert.ToDouble(T[9]));
                    this.chart2.Visible = true;
                }
                xw = false;
            }
            else
            {
                this.label5.Text = "Poczekaj na sygnał";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
