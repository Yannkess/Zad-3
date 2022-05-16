using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace Zadanie5_OSK
{
    public partial class NoweOkno2 : Form
    {
        public NoweOkno2()
        {
            InitializeComponent();
            lock1 = true;
            first_timer = false;
            lock2 = false;
            i = 0;
            Ts = 350;
            Ts2 = 700;
            S1 = 0;
            S2 = 0;
            Tmaxw = 0;
            Tminw = 10000;
            Tmaxd = 0;
            Tmind = 10000;
            this.chart1.Visible = false;
            this.chart2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public double average(double a,double b, double c)
        {
            double S = (a + b + c) / 3;
            return S;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (lock2 == false) {
                this.button1.Visible = false;
                Random rnd1 = new Random();
                this.random_number = rnd1.Next(500, 5000);
                this.timer1.Interval = this.random_number;
                this.timer1.Start();
                lock2 = true;
            }
            else
            {
                this.button1.Visible = false;
                Random rnd1 = new Random();
                this.random_number = rnd1.Next(500, 5000);
                this.timer1.Interval = this.random_number;
                this.timer1.Start();
                this.button2.BackColor = Color.White;
            }
            
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (lock1 == true)
            {
                this.button2.BackColor = Color.Red;
                this.start = DateTime.Now;
                this.timer1.Stop();
                lock1 = false;
                this.button1.Text = "Kontynuuj";

            }
            else
            {
                SystemSounds.Exclamation.Play();
                //Console.Beep();
                this.start = DateTime.Now;
                this.timer1.Stop();
                lock1 = true;
                this.button1.Text = "Kontynuuj";
            }
            first_timer = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (first_timer == true)
            {
                this.label5.Text = " ";
                if (i <= 5)
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
                    if (i%2 == 0)
                    {
                        if (Tmaxw < T[i])
                        {
                            Tmaxw = T[i];
                        }
                        if(Tminw > T[i])
                        {
                            Tminw = T[i];
                        }
                    }
                    else
                    {
                        if (Tmaxd < T[i])
                        {
                            Tmaxd = T[i];
                        }
                        if (Tmind > T[i])
                        {
                            Tmind = T[i];
                        }
                    }
                    Console.WriteLine("{0,12}", this.random_number);
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
                    this.chart1.Visible = true;
                    this.chart2.Enabled = true;
                    this.chart2.Series["Czasy"].Points.AddXY(1, Convert.ToDouble(T[1]));
                    this.chart2.Series["Czasy"].Points.AddXY(2, Convert.ToDouble(T[3]));
                    this.chart2.Series["Czasy"].Points.AddXY(3, Convert.ToDouble(T[5]));
                    this.chart2.Visible = true;
                    this.label6.Text = "Najszybszy czas reakcji na bodźce wzrokowe: " + Tminw + " ms";
                    this.label7.Text = "Najwolniejszy czas reakcji na bodźce wzrokowe: " + Tmaxw + " ms";
                    this.label8.Text = "Najszybszy czas reakcji na bodźce dźwiękowe: " + Tmind + " ms";
                    this.label9.Text = "Najwolniejszy czas reakcji na bodźce dźwiękowe: " + Tmaxd + " ms";
                    S1 = average(T[0], T[2], T[4]);
                    if (S1<=Ts)
                    {
                        this.label10.Text = "Twój średni czas jest lepszy od średniego \n czasu reakcji dla przeciętnego człowieka";
                    }else if (S1 <= Ts2)
                    {
                        this.label10.Text = "Twój średni czas reakcji mieści się w przedziale średniego  \n czasu reakcji dla przeciętnego człowieka";
                    }
                    else
                    {
                        this.label10.Text = "Twój średni czas jest gorszy od średniego \n czasu reakcji dla przeciętnego człowieka";
                    }
                    S2 = average(T[1], T[3], T[5]);
                    if (S2 <= Ts)
                    {
                        this.label11.Text = "Twój średni czas jest lepszy od średniego \n czasu reakcji dla przeciętnego człowieka";
                    }
                    else if (S1 <= Ts2)
                    {
                        this.label11.Text = "Twój średni czas reakcji mieści się w przedziale średniego \n czasu reakcji dla przeciętnego człowieka";
                    }
                    else
                    {
                        this.label11.Text = "Twój średni czas jest gorszy od średniego \n czasu reakcji dla przeciętnego człowieka";
                    }
                }
                first_timer = false;
            }
            else
            {
                this.label5.Text = "Poczekaj na sygnał";
            }
        }
    }
}
