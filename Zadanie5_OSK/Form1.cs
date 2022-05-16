using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie5_OSK
{
    public partial class Instrukcja : Form
    {
        public Instrukcja()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.TestProbny = new NoweOkno();
            this.TestProbny.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.TestWlasciwy = new NoweOkno2();
            this.TestWlasciwy.Show();
        }
    }
}
