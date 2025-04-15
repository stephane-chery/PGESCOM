using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PGESCOM
{
    public partial class FindBestUPSInverter : Form
    {

        static string DBusrNm = "sa";
        static string dbpwd = "darasam";
        static string SQLDB = @"ERPSERVER\PSM_DB2K8K";
        static string currDB = "PGESCOM_test_app";
        string M_stCon = @"user id=" + DBusrNm + ";password=" + dbpwd + ";server=" + SQLDB + ";Trusted_Connection=No;database=" + currDB + ";connection timeout=30";
        //string _connectionString = MainMDI._connectionString;
        private int _inputPH9;
        private float _inputkVA;
        private int _inputv9;
        private int _inputVDC;

        //values that will be used outside the class
        public string upsModel = "";
        public string Vdc = "";
        public string Kvao = "";
        public string Vo = "";
        public string Pho = "";

        public FindBestUPSInverter()
        {
            InitializeComponent();
        }


        private bool ValidateP850Inputs()
        {
            int parsedPH9;
            float parsedkVA;
            int parsedv9;
            int parsedVDC;
            bool validPH9 = Int32.TryParse(textBoxPH9.Text.Trim(), out parsedPH9);
            bool validkVA = Single.TryParse(textBoxkVA.Text.Trim(), out parsedkVA);
            bool validkv9 = Int32.TryParse(textBoxv9.Text.Trim(), out parsedv9);
            bool validVDC = Int32.TryParse(textBoxVDC.Text.Trim(), out parsedVDC);

            if (validPH9 && validkVA && validkv9 && validVDC)
            {
                //every field successfully parsed, set current inputs
                _inputPH9 = parsedPH9;
                _inputkVA = parsedkVA;
                _inputv9 = parsedv9;
                _inputVDC = parsedVDC;
                labelFilledValuesRequired.Text = "";
                return true;
            }
            else
            {
                labelFilledValuesRequired.Text = "Inputs must be filled and/or valid.";
                return false;
            }
        }

        public async Task GetP850Model(int inputPh_output, float inputkVA_output, int inputV_output, int inputVdc, String inverterOrUPS)
        {
            bool modelFound = false;
            string foundModel = "";

            //Querys the P850 table to find the most suitable UPS/inverter model using the inputs
            string stSql = $"select top 1 * from P850 where inverter_or_ups = '{inverterOrUPS}' and ph9 = {inputPh_output} and kva9 >= {inputkVA_output} and v9 >= {inputV_output} and vdc >= {inputVdc} order by kva9 asc, v9 asc, vdc asc;";

            SqlConnection OConn = new SqlConnection(M_stCon);
            await OConn.OpenAsync();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = await Ocmd.ExecuteReaderAsync();

            //displays model name if a model found
            while (await Oreadr.ReadAsync())
            {
                modelFound = true;
                foundModel = $"{Oreadr["typeP850"]}{Oreadr["inverter_or_ups"]}-{Oreadr["ph9"]}-{Oreadr["kva9"]}-{Oreadr["v9"]}-{Oreadr["vdc"]}";
                upsModel = foundModel;
                Pho = Oreadr["ph9"].ToString();
                Kvao = Oreadr["kva9"].ToString();
                Vo = Oreadr["v9"].ToString();
                Vdc = Oreadr["vdc"].ToString();
            }

            labelBestP850result.Text = modelFound ? foundModel : "<Model not found>";
            string newModel = $"P850{inverterOrUPS}-{inputPh_output}-{inputkVA_output}-{inputV_output}-{inputVdc}";
            //upsModel = modelFound ? foundModel : "<Model not found>";
            if (inputVdc < 125 || inputVdc > 125)
            {
                upsModel =newModel;
            }
            
        }

        private void buttonFindP850ModelClick(object sender, EventArgs e)
        {
            labelBestP850result.Text = "";
            string inverterOrUPS = radioButtonUPS.Checked ? "u" : "i";
            bool inputsValid = ValidateP850Inputs();

            if (!inputsValid)
            {
                return;
            }

            GetP850Model(_inputPH9, _inputkVA, _inputv9, _inputVDC, inverterOrUPS);


        }

        //Input field change handlers
        private void textBoxPH9_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPH9.Text.ToString() != "")
            {
                if (textBoxPH9.Text.ToString() == "1" || textBoxPH9.Text.ToString() == "3")
                {
                   //do nothing
                   //had some trouble with !=
                }
                else
                {
                    MessageBox.Show("the phase can only be be 1 or 3");
                    textBoxPH9.Text = "";
                }
            }
            ValidateP850Inputs();
        }
        private void textBoxkVA_TextChanged(object sender, EventArgs e)
        {
            ValidateP850Inputs();
        }

        private void textBoxv9_TextChanged(object sender, EventArgs e)
        {
            ValidateP850Inputs();
        }

        private void textBoxVDC_TextChanged(object sender, EventArgs e)
        {
            ValidateP850Inputs();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
