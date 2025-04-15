using EAHLibs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PGESCOM
{
    public partial class Add_Protocol : Form
    {
        private Lib1 Tools = new Lib1();

        public int protocol_No;

        public Add_Protocol(int protocolNo)
        {
            InitializeComponent();
            protocol_No = protocolNo;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            AjouterProtocol();
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AjouterProtocol()
        {
            string stSQL = "INSERT INTO [pgm_communicationCard_protocol] ([pgm_communicationCard_protocol].protocol_No, " +
                "[pgm_communicationCard_protocol].protocol_Description, [pgm_communicationCard_protocol].protocol_Price) " +
                "VALUES (" + 
                protocol_No + ", '" + 
                txtBox_description.Text + "', " + 
                Tools.Conv_Dbl(txtBox_price.Text) + ")";
            MainMDI.ExecSql(stSQL);
        }
    }
}
