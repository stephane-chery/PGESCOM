using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIMCHUPS
{
    public partial class Simulators : Form
    {
        public Simulators()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MainM  myPWD = new MainM();
            this.Hide();
            myPWD.ShowDialog();
            myPWD.Close();
            this.Visible = true;
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          UPSMain myPWD = new UPSMain();
            this.Hide();
            myPWD.ShowDialog();
            myPWD.Close();
            this.Visible = true;
        }
    }
}
