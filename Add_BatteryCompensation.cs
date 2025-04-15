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
    public partial class Add_BatteryCompensation : Form
    {
        private List<string> listTitle = new List<string>();
        private List<string> listValue = new List<string>();

        private List<int> listNumeroColonne = new List<int>();

        public bool verify = false;

        public Add_BatteryCompensation()
        {
            InitializeComponent();
        }

        private void radioBtn_enableOn_CheckedChanged(object sender, EventArgs e)
        {
            lbl_enableValue.Text = "On";
        }

        private void radioBtn_enableOff_CheckedChanged(object sender, EventArgs e)
        {
            lbl_enableValue.Text = "Off";
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            listTitle.Add(txtBox_titleCol1.Text);
            listTitle.Add(txtBox_titleCol2.Text);
            listTitle.Add(txtBox_titleCol3.Text);

            listValue.Add(txtBox_valueCol1.Text);
            listValue.Add(txtBox_valueCol2.Text);
            listValue.Add(txtBox_valueCol3.Text);

            Ajouter();
            listTitle.Clear();
            listValue.Clear();
            if (verify) this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Ajouter()
        {
            int compteur = 0;
            if ((!string.IsNullOrWhiteSpace(txtBox_titleCol1.Text)) && (!string.IsNullOrWhiteSpace(txtBox_valueCol1.Text))) compteur++;
            if ((!string.IsNullOrWhiteSpace(txtBox_titleCol2.Text)) && (!string.IsNullOrWhiteSpace(txtBox_valueCol2.Text))) compteur++;
            if ((!string.IsNullOrWhiteSpace(txtBox_titleCol3.Text)) && (!string.IsNullOrWhiteSpace(txtBox_valueCol3.Text))) compteur++;
            for (int i = 0; i < compteur; i++)
            {
                verify = true;
                int numeroColonne = RechercherNumeroColonne();
                AjouterColonne_BatteryCompensation(numeroColonne);
                AjouterBatteryCompensations_Columns(listTitle[i]);
                listNumeroColonne.Add(numeroColonne);
                if (i == compteur - 1) AjouterBatteryCompensation(compteur);
            }
        }

        private int RechercherNumeroColonne()
        {
            int numero = 0;
            string stSQL = "SELECT TOP 1 [pgm_batteryCompensation_columns].* FROM [pgm_batteryCompensation_columns] " +
                "ORDER BY [pgm_batteryCompensation_columns].batteryCompensation_columns_Id DESC";
            SqlConnection Oconn = new SqlConnection(MainMDI.M_stCon);
            Oconn.Open();
            SqlCommand Ocmd = Oconn.CreateCommand();
            Ocmd.CommandText = stSQL;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read()) 
                numero = Convert.ToInt32(Oreadr["batteryCompensation_columns_Id"].ToString()) + 1;
            Oconn.Close();

            return numero;
        }

        private void AjouterColonne_BatteryCompensation(int compteur)
        {
            string stSQL = "ALTER TABLE [pgm_batteryCompensation] " +
                "ADD batteryCompensation_Col" + compteur + " varchar(max);";
            MainMDI.ExecSql(stSQL);
        }

        private void AjouterBatteryCompensation(int compteur)
        {
            int nbr = 0;
            string stSQL = "INSERT INTO [pgm_batteryCompensation] ([pgm_batteryCompensation].batteryCompensation_Description, " +
                "[pgm_batteryCompensation].batteryCompensation_Price, [pgm_batteryCompensation].batteryCompensation_Enable";

            while (nbr < 2)
            {
                for (int i = 0; i < compteur; i++)
                {
                    if (nbr == 0) stSQL += ", [pgm_batteryCompensation].batteryCompensation_Col" + listNumeroColonne[i];
                    else if ((i == 0) && (nbr != 0))
                    {
                        stSQL += " VALUES ('" +
                            txtBox_description.Text + "', " +
                            txtBox_price.Text + ", '" +
                            lbl_enableValue.Text + "', '" +
                            listValue[i] + "'";
                    }
                    else stSQL += ", '" + listValue[i] + "'";
                }
                stSQL += ")";
                nbr++;
            }
            MainMDI.ExecSql(stSQL);
        }

        private void AjouterBatteryCompensations_Columns(string columnName)
        {
            string stSQl = "INSERT INTO [pgm_batteryCompensation_columns] " +
                "([pgm_batteryCompensation_columns].batteryCompensation_columns_ColumnName) VALUES ('" + 
                columnName + "')";
            MainMDI.ExecSql(stSQl);
        }
    }
}
