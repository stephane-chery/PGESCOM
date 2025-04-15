//using Microsoft.Office.Interop.Word;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static iTextSharp.text.pdf.qrcode.Version;

namespace PGESCOM
{

    internal class P850UI_UPS_INV_New_SQL_Controller
    {
        public static string _connectionString = @"user id=" + "sa" + ";password=" + "darasam" + ";server=" + @"ERPSERVER\PSM_DB2K8K" + ";Trusted_Connection=No;database=" + "PGESCOM_NEW" + ";connection timeout=30";//";"
        public static string M_stCon = @"user id=" + "sa" + ";password=" + "darasam" + ";server=" + @"ERPSERVER\PSM_DB2K8K" + ";Trusted_Connection=No;database=" + "Orig_PSM_FDB" + ";connection timeout=30";
        private DatabaseHelper dbHelper = new DatabaseHelper(_connectionString);

        /*
         * retroune le nouveau voltage en indexant dans la liste ( + )  si 
         * le prix ou les informations du KA n'ont pas ete trouves
         */
        private (string, int) FindVoltInList(string volt)
        {
            string newVolt = "";
            int index = 0;
            //replace this static list by a sql query to get the datas directly from the database
            var VacList = new List<string> { "120Vac", "240Vac", "400Vac", "480Vac", "600Vac" };
            var VdcList = new List<string> { "80Vdc", "125Vdc", "130Vdc", "250Vdc", "500Vdc", "600Vdc" };

            if (volt.Contains("Vac"))
            {
                index = VacList.IndexOf(volt);
                if(index != -1) newVolt = VacList.ElementAt(index);
            } else
            {
                index = VdcList.IndexOf(volt);
                if (index != -1) newVolt = VdcList.ElementAt(index);
            }

            return (newVolt, index);
        }

        //lookup for the best possible KA in the Configo_CB1xx_CB2xx table 
        public async Task<(string price, string KALookup)> KALookUp(string KA, string ampere, string volt)
        {
            string price = "";
            string KALookup = "";

            var VacList = new List<string> { "120Vac", "240Vac", "400Vac", "480Vac", "600Vac" };
            var VdcList = new List<string> { "80Vdc", "125Vdc", "130Vdc", "250Vdc", "500Vdc", "600Vdc" };

            // Determine initial voltage type and index
            (string newVolt, int index) = FindVoltInList(volt);

            if (string.IsNullOrEmpty(newVolt))
            {
                return ("Price not found", "KA not found");
            }

            var dbHelper = new DatabaseHelper(M_stCon);

            while (true)
            {
                string query = $@"
            SELECT TOP 1 * 
            FROM Configo_CB1xx_CB2xx 
            WHERE (PHASE = 1 OR PHASE = 3) 
            AND CAST([ICB1] AS FLOAT) >= @Ampere 
            AND CAST([{newVolt}] AS FLOAT) >= @KA 
            ORDER BY ABS(List_Price), ICB1";

                try
                {
                    var parameters = new Dictionary<string, object>
            {
                { "@Ampere", ampere },
                { "@KA", KA }
            };

                    var results = await dbHelper.ExecuteSelectQueryAsync(query, parameters);

                    if (results.Any())
                    {
                        var row = results.First();
                        price = row["List_Price"].ToString();
                        KALookup = row[newVolt].ToString();
                        return (price, KALookup); // Result found, exit the loop
                    }
                }
                catch (Exception ex)
                {
                    await Console.Out.WriteLineAsync($"Error: {ex.Message}");
                }

                // If no result found, try the next voltage in the list
                index++;
                if (volt.Contains("Vac"))
                {
                    if (index >= VacList.Count) break; // Exit if out of bounds
                    newVolt = VacList[index];
                }
                else if (volt.Contains("Vdc"))
                {
                    if (index >= VdcList.Count) break; // Exit if out of bounds
                    newVolt = VdcList[index];
                }
                else
                {
                    return ("Price not found", "KA not found");
                }
            }

            // If the loop exits without finding a result
            return ("Price not found", "KA not found");
        }



        //lookup ( database search) to get the real value of Icb1 and Icb2
        public async Task<double> IcbLookup(double ILookup, string phase)
        {
            double result = 0;
            try
            {
                string stSql = $"select top 1 ICB1 from Configo_CB1xx_CB2xx where cast([ICB1] as float) >= @ILookup and PHASE >= @Phase order by ICB1";
                using (SqlConnection conn = new SqlConnection(M_stCon))
                using (SqlCommand cmd = new SqlCommand(stSql, conn))
                {
                    cmd.Parameters.AddWithValue("@ILookup", ILookup);
                    cmd.Parameters.AddWithValue("@Phase", phase);
                    await conn.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            result = Double.Parse(reader["ICB1"].ToString());
                            Console.WriteLine(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the error, replace with proper logging if needed
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        //lookup to get the real value of the Idc ( not the same as IcbLookup) 
        public async Task<double> IdcLookup(double ILookup)
        {
            double result = 0;
            string query = @"SELECT TOP 1 IdcCharger 
                     FROM IdcLookup 
                     WHERE IdcCharger >= @ILookup AND Phase >= 1";

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add parameter to prevent SQL injection
                    cmd.Parameters.AddWithValue("@ILookup", ILookup);

                    await conn.OpenAsync();

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            result = Double.Parse(reader["IdcCharger"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the error, replace with proper logging if needed
                Console.WriteLine(ex.Message);
            }

            return result;
        }




        //get Batteries
        public async Task getBatteries(System.Windows.Forms.ComboBox BatteryComboBox)
        {
            SqlConnection OConn = new SqlConnection(_connectionString);
            try
            {
                string stSql = "SELECT BatteryType FROM Batteries";
                await OConn.OpenAsync();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = await Ocmd.ExecuteReaderAsync();
                while (await Oreadr.ReadAsync())
                {
                    BatteryComboBox.Items.Add(Oreadr["BatteryType"].ToString());
                }
                //put a default value into the battery combo box
                BatteryComboBox.Text = BatteryComboBox.Items[0].ToString();
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }
            finally
            {
                OConn.Close();
            }
        }

        //get Batteries values depending on the battery type
        public void getBatteryTypeValue(string BatteryType, System.Windows.Forms.TextBox Fb)
        {
            try
            {
                string stSql = "SELECT Frech FROM Batteries where BatteryType=@BatteryType";

                SqlConnection OConn = new SqlConnection(_connectionString);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Ocmd.Parameters.AddWithValue("@BatteryType", BatteryType);
                SqlDataReader Oreadr = Ocmd.ExecuteReader();
                while (Oreadr.Read())
                {
                    Fb.Text = Oreadr["Frech"].ToString();

                }
                OConn.Close();
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }

        }



        /*
        //model Default values 
        public async Task getModelDefaultValues(System.Windows.Forms.Label lChrgREF, System.Windows.Forms.TextBox Pho, System.Windows.Forms.TextBox kvao, System.Windows.Forms.TextBox Vo, ComboBox Vdc,
            System.Windows.Forms.TextBox V_Inverter, Char upsOrInverter)
        {
            try
            {
                string foundModel = "";

                string stSql = $"SELECT top 1 * FROM P850 where inverter_or_ups = @upsOrInverter";

                SqlConnection OConn = new SqlConnection(_connectionString);
                await OConn.OpenAsync();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Ocmd.Parameters.AddWithValue("@upsOrInverter", upsOrInverter.ToString());
                SqlDataReader Oreadr = await Ocmd.ExecuteReaderAsync();
                while (await Oreadr.ReadAsync())
                {
                    foundModel = $"{Oreadr["typeP850"]}{Oreadr["inverter_or_ups"]}-{Oreadr["ph9"]}-{Oreadr["kva9"]}-{Oreadr["v9"]}-{Oreadr["vdc"]}";
                    Pho.Text = Oreadr["ph9"].ToString();
                    kvao.Text = Oreadr["kva9"].ToString();
                    Vo.Text = Oreadr["v9"].ToString();
                    Vdc.Text = Oreadr["vdc"].ToString();
                    V_Inverter.Text = Oreadr["vdc"].ToString();
                }
                OConn.Close();


                lChrgREF.Text = foundModel;
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }

        }
        */

        public async Task getModelDefaultValues(Dictionary<string, Control> controls, char upsOrInverter)
        {
            try
            {
                string foundModel = "";

                string stSql = $"SELECT TOP 1 * FROM P850 WHERE inverter_or_ups = @upsOrInverter";

                using (SqlConnection OConn = new SqlConnection(_connectionString))
                {
                    await OConn.OpenAsync();
                    using (SqlCommand Ocmd = OConn.CreateCommand())
                    {
                        Ocmd.CommandText = stSql;
                        Ocmd.Parameters.AddWithValue("@upsOrInverter", upsOrInverter.ToString());

                        using (SqlDataReader Oreadr = await Ocmd.ExecuteReaderAsync())
                        {
                            if (await Oreadr.ReadAsync())
                            {
                                foundModel = $"{Oreadr["typeP850"]}{Oreadr["inverter_or_ups"]}-{Oreadr["ph9"]}-{Oreadr["kva9"]}-{Oreadr["v9"]}-{Oreadr["vdc"]}";

                                if (controls["Ph_output"] is System.Windows.Forms.TextBox pho)
                                    pho.Text = Oreadr["ph9"].ToString();

                                if (controls["KVA_output"] is System.Windows.Forms.TextBox kva)
                                    kva.Text = Oreadr["kva9"].ToString();

                                if (controls["V_output"] is System.Windows.Forms.ComboBox vo)
                                    vo.Text = Oreadr["v9"].ToString();

                                if (controls["VdcComboBox"] is System.Windows.Forms.ComboBox vdc)
                                    vdc.Text = Oreadr["vdc"].ToString();

                                if (controls["V_Inverter"] is System.Windows.Forms.TextBox vInverter)
                                    vInverter.Text = Oreadr["vdc"].ToString();
                            }
                        }
                    }
                    OConn.Close();
                }
               
                if (controls["P850Model"] is System.Windows.Forms.Label P850model)
                    P850model.Text = foundModel;
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }
        }



        //get the possible values of the VAC, Vo, Vbp
        public async Task getVacValues(ComboBox ComboBox, String phase)
        {
            try
            {
                //clear first 
                ComboBox.Items.Clear();

                string stSql = $"SELECT * FROM VacValues where phase = {phase}";

                SqlConnection OConn = new SqlConnection(_connectionString);
                await OConn.OpenAsync();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = await Ocmd.ExecuteReaderAsync();
                while (await Oreadr.ReadAsync())
                {
                    ComboBox.Items.Add(Oreadr["VACValues"].ToString());
                }
                OConn.Close();

                ComboBox.SelectedIndex = 1;
                if (ComboBox.Name.Equals("VacComboBox"))
                {
                    ComboBox.SelectedIndex = 7;
                }
                else if (ComboBox.Name.Equals("V_output_comboBox") && phase.Equals("1"))
                {
                    ComboBox.SelectedIndex = 1;
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }
        }

        //get the possible values of the Vdc
        public async Task getVdcValues(ComboBox VdcComboBox)
        {
            try
            {
                string stSql = "SELECT * FROM VdcValues";

                SqlConnection OConn = new SqlConnection(_connectionString);
                await OConn.OpenAsync();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = await Ocmd.ExecuteReaderAsync();
                while (await Oreadr.ReadAsync())
                {
                    VdcComboBox.Items.Add(Oreadr["Vdc"].ToString());
                }
                OConn.Close();

                //put a default value into the Vdc combo box
                VdcComboBox.Text = VdcComboBox.Items[5].ToString();


            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }
        }

        public void getVdcMaxAndVdcMin(ComboBox VdcComboBox, System.Windows.Forms.TextBox Vdc_max, System.Windows.Forms.TextBox Vdc_min, System.Windows.Forms.Label cellNumber)
        {
            try
            {
                string stSql = "SELECT * FROM VdcValues where Vdc = @Vdc";

                SqlConnection OConn = new SqlConnection(_connectionString);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Ocmd.Parameters.AddWithValue("@Vdc", VdcComboBox.Text);
                SqlDataReader Oreadr = Ocmd.ExecuteReader();
                while (Oreadr.Read())
                {
                    Vdc_max.Text = Oreadr["VdcMax"].ToString();
                    Vdc_min.Text = Oreadr["VdcMin"].ToString();
                    cellNumber.Text = Oreadr["numberCells"].ToString();
                }
                OConn.Close();


            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }
        }


        //VdcMaxLookup 
        public double VdcMaxLookup(double VdcMax)
        {
            double result = 0;

            string stSql = $"select top 1 * from VdcValues where  VdcMax > {VdcMax}";
            SqlConnection OConn = new SqlConnection(_connectionString);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                result = Double.Parse(Oreadr["Vdc"].ToString());
            }
            return result;
        }


        //get the price of the ups or inverter
        public void getInverterOrUpsPrice(System.Windows.Forms.TextBox KVA_output, String table,
            System.Windows.Forms.TextBox UnitCost_textbox)
        {
            bool priceFound = false;
            try
            {
                string stSql = $"SELECT top 1 * FROM {table} where KVA >= @Kva";

                SqlConnection OConn = new SqlConnection(_connectionString);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Ocmd.Parameters.AddWithValue("@Kva", KVA_output.Text.ToString());
                SqlDataReader Oreadr = Ocmd.ExecuteReader();
                while (Oreadr.Read())
                {
                    UnitCost_textbox.Text = Math.Round(Double.Parse(Oreadr["PU"].ToString()), 2).ToString();
                    priceFound = true;
                }
                OConn.Close();

                if (priceFound == false)
                {
                    UnitCost_textbox.Text = "1000000";
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }
            
        }

        public (String, String, String) OMBSPrice(System.Windows.Forms.TextBox KVA_output, String table)
        {
            String OMBSPrice = "";
            String Cabinet = "";
            String description = "";

            try
            {
                string stSql = $"SELECT top 1 * FROM {table} where UPS_KVA >= @Kva";

                SqlConnection OConn = new SqlConnection(_connectionString);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Ocmd.Parameters.AddWithValue("@Kva", KVA_output.Text.ToString());
                SqlDataReader Oreadr = Ocmd.ExecuteReader();
                while (Oreadr.Read())
                {
                    // dotnet_style_prefer_simplified_interpolation = true
                    Cabinet = $"{Oreadr["CabinetModel"]},  {Oreadr["Dimensions"]}(in)  {Oreadr["Dimensions"]}(mm) 16GA / 1.5mm STEEL, GREY ASA 61 NEMA1, IP20,Weight {Oreadr["WeightInKg"]}kg-{Oreadr["WeightInLbs"]}lbs\r\n";
                    OMBSPrice = Oreadr["PriceInUs"].ToString();
                    description = Oreadr["UpsDescription"].ToString();
                }
                OConn.Close();

            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }

            return (OMBSPrice, Cabinet, description);
        }

        public (String, String) MBSPrice(System.Windows.Forms.TextBox KVA_output)
        {
            String MBSPrice = "";
            String description = "";
            try
            {
                string stSql = $"SELECT top 1 * FROM P850_Mbs where KVA >= @Kva";

                SqlConnection OConn = new SqlConnection(_connectionString);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Ocmd.Parameters.AddWithValue("@Kva", KVA_output.Text.ToString());
                SqlDataReader Oreadr = Ocmd.ExecuteReader();
                while (Oreadr.Read())
                {
                    // dotnet_style_prefer_simplified_interpolation = true
                    description = Oreadr["Description"].ToString(); ;
                    MBSPrice = Oreadr["Price"].ToString();
                }
                OConn.Close();

            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }

            MBSPrice = Math.Round(Double.Parse(MBSPrice), 2).ToString();
            return (MBSPrice, description);
        }

        public async Task<string> CBKADefaultValue(string cbName, string phase)
        {
            string kaDefaultValue = "";
            string stSql = "SELECT KAValue FROM CB_KA_DefaultValue WHERE CbName = @CbName AND Phase = @Phase";

            try
            {
                using (SqlConnection oConn = new SqlConnection(_connectionString))
                {
                    await oConn.OpenAsync();

                    using (SqlCommand oCmd = new SqlCommand(stSql, oConn))
                    {
                        oCmd.Parameters.AddWithValue("@CbName", cbName);
                        oCmd.Parameters.AddWithValue("@Phase", phase);

                        using (SqlDataReader oReadr = await oCmd.ExecuteReaderAsync())
                        {
                            while (await oReadr.ReadAsync())
                            {
                                kaDefaultValue = oReadr["KAValue"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                // Optionally, you can rethrow the error or handle it based on your application's requirements
                throw;
            }

            return kaDefaultValue;
        }

        private (string, string) getVcbText(TextBox VCB, String CBType)
        {
            string VCBText = string.Empty;
            string VdcOrVac = "Vdc";
            var VacList = new List<string> { "120", "240", "400", "480", "600" };
            var VdcList = new List<string> { "80", "125", "130", "250", "500", "600" };

            int index = VdcList.IndexOf(VCB.Text);
            if (index != -1)
            {
                VCBText = VdcList.ElementAt(index);
            }
            else
            {
                index = 0;
                VCBText = VdcList.ElementAt(index);
            }

            if (CBType.Equals("CB4") || CBType.Equals("CB5") || CBType.Equals("CB7"))
            {
                index = VacList.IndexOf(VCB.Text);
                if (index != -1)
                {
                    VCBText = VacList.ElementAt(index);
                }
                else
                {
                    index = 0;
                    VCBText = VacList.ElementAt(index);
                }

                VdcOrVac = "Vac";
            }

            return (VCBText, VdcOrVac);
        }


        //select the right CB Price 
        public async Task<(String, String)> CbPriceSelector(String CBType, TextBox ICB, TextBox VCB, String KACB)
        {
            String CBPrice = "";
            String Manifac = "";
            String VdcOrVac = "Vdc";
            int index = 0;
            String VCBText = "";

            var VacList = new List<string> { "120", "240", "400", "480", "600"};
            var VdcList = new List<string> { "80", "125", "130", "250", "500", "600"};

            if (!ICB.Text.Equals("") && !VCB.Text.Equals("") && !KACB.Equals(""))
            {
                VCBText = getVcbText(VCB, CBType).Item1;
                VdcOrVac = getVcbText(VCB, CBType).Item1;

                bool priceFound = false;

                //loop the query until a price is found ( 
                while (!priceFound)
                {
                    string stSql = $"select top 1 * from Configo_CB1xx_CB2xx where ([PHASE]=1 OR [PHASE]=3) and (cast ([ICB1] as float) >= {ICB.Text}) and (cast ([{VCBText}{VdcOrVac}] as float) >= {KACB}) order by abs ([List_Price])";

                    using (SqlConnection OConn = new SqlConnection(M_stCon))
                    {
                        try
                        {
                            await OConn.OpenAsync();
                            using (SqlCommand Ocmd = new SqlCommand(stSql, OConn))
                            {
                                //Ocmd.Parameters.AddWithValue("@ICB", ICB.Text.ToString());
                                using (SqlDataReader Oreadr = await Ocmd.ExecuteReaderAsync())
                                {
                                    while (await Oreadr.ReadAsync())
                                    {
                                        // dotnet_style_prefer_simplified_interpolation = true
                                        CBPrice = Oreadr["List_Price"].ToString(); ;
                                        Manifac = Oreadr["MANIFAC"].ToString();
                                        priceFound = true;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error retrieving charger price: {ex.ToString()}");
                        }
                        // If no price is found, adjust the parameters for the next iteration
                        if (!priceFound)
                        {
                            index++;

                            if (index > VdcList.Count || index > VacList.Count) 
                            {
                                CBPrice = "1 000 000";
                                return ("Price Not Found", "Manufacturer Not Found"); // Exit the loop if no more adjustments can be made
                            } else
                            {
                                VCBText = VdcList.ElementAt(index);
                                if (CBType.Equals("CB4") || CBType.Equals("CB5") || CBType.Equals("CB7"))
                                {
                                    VCBText = VacList.ElementAt(index);
                                    VdcOrVac = "Vac";
                                }
                            }

                       }
                    }
                }

            }
            //CBPrice = Math.Round(Double.Parse(CBPrice), 2).ToString();
            return (CBPrice, Manifac);
        }

        // select the right deliveryyDate
        public string SelectLeadTime(string charger)
        {
            string chargerDeliveryDate = "";
            try
            {
                string stSql = "SELECT top 1 * FROM Chargers_DeliveryDate where charger = @charger";

                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Ocmd.Parameters.AddWithValue("@charger", charger);
                SqlDataReader Oreadr = Ocmd.ExecuteReader();
                while (Oreadr.Read())
                {
                    chargerDeliveryDate = Oreadr["leadTime"].ToString();

                }
                OConn.Close();

            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }

            return chargerDeliveryDate;
        }

        //fill the a listview after a validation click
        /// <summary>
        /// </summary>
        /// <param name="multiplicator"></param> come from the Quote page and will be used to determine the total price
        /// <param name="listView"></param>
        /// <param name="validationId"></param> unique Id to help retrieve a specific validation
        public async void fill_listview(string multiplicator, ListView listView1, string validationId)
        {
            try
            {
                string query = "SELECT * FROM P850_validation_details WHERE validationId = @validationId";

                var results = await dbHelper.ExecuteSelectQueryAsync(query, new Dictionary<string, object>
        {
            { "@validationId", validationId }
        });

                listView1.Items.Clear();

                foreach (var row in results)
                {
                    ListViewItem lvI = listView1.Items.Add("");
                    lvI.Checked = true;

                    lvI.SubItems.Add(row["optionReference"].ToString());
                    lvI.SubItems.Add(row["itemDescription"].ToString());
                    lvI.SubItems.Add(row["quantity"].ToString());
                    lvI.SubItems.Add(row["unitPrice"].ToString());
                    lvI.SubItems.Add(row["multiplicator"].ToString());
                    lvI.SubItems.Add(row["totalPrice"].ToString());
                    lvI.SubItems.Add(row["leadTime"].ToString());
                }

                if (listView1.Items.Count < 1)
                {
                    MessageBox.Show("Sorry No Charger Validated.......");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // optimize to cancel the 20 calls and try to make it one big batch call for better performance
        public async Task insertIntoP850ValidationQuery(String validationId, String optionReference, String itemDescription, string quantity, String multiplicator, String unitPrice, String totalPrice, String leadTime)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                String query = "INSERT INTO P850_validation_details values (@validationId, @optionReference, @itemDescription, @quantity, @multiplicator, @unitPrice, @totalPrice, @leadTime)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@validationId", validationId);
                    command.Parameters.AddWithValue("@optionReference", !string.IsNullOrEmpty(optionReference) ? optionReference : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@itemDescription", !string.IsNullOrEmpty(itemDescription) ? itemDescription : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@quantity", !string.IsNullOrEmpty(quantity) ? Int32.Parse(quantity) : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@multiplicator", !string.IsNullOrEmpty(multiplicator) ? Double.Parse(multiplicator) : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@unitPrice", !string.IsNullOrEmpty(unitPrice) ? Double.Parse(unitPrice) : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@totalPrice", !string.IsNullOrEmpty(totalPrice) ? Double.Parse(totalPrice) : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@leadTime", !string.IsNullOrEmpty(leadTime) ? leadTime : (object)DBNull.Value);

                    await connection.OpenAsync();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                    {
                        Console.WriteLine("Error inserting data into Database!");
                    }
                }
            }
        }

        public void DeleteIntoP850ValidationQuery(string validationId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                String query = "Delete from P850_validation_details  where validationId = @validationId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@validationId", validationId);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                    {
                        Console.WriteLine("Error while deleting  from Database!");
                    }
                }
            }
        }


        //save the progress of the user by saving the input and the validation that he made
        public int saveUserProgressOutputGroupbox(string quoteId, string V_output, string Ph_output, string KVA_output, string PF_output)
        {

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                String query = "INSERT INTO P850_OutputGroupbox_save values (@quoteId, @V_output, @Ph_output, @KVA_output, @PF_output)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@quoteId", quoteId);
                    command.Parameters.AddWithValue("@V_output", !string.IsNullOrEmpty(V_output) ? Double.Parse(V_output) : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Ph_output", !string.IsNullOrEmpty(Ph_output) ? Double.Parse(Ph_output) : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@KVA_output", !string.IsNullOrEmpty(KVA_output) ? Double.Parse(KVA_output) : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PF_output", !string.IsNullOrEmpty(PF_output) ? Double.Parse(PF_output) : (object)DBNull.Value);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                    {
                        Console.WriteLine("Error inserting data into Database!");
                    }
                    return result;
                }
            }
        }

        public int saveUserProgressBypassInputGroupbox(string quoteId, string V_bypass_input, string KA_bypass_input, string PH_bypass_input)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                String query = "INSERT INTO P850_BypassInputGroupbox_Save values (@quoteId, @V_bypass_input, @KA_bypass_input, @PH_bypass_input)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@quoteId", quoteId);
                    command.Parameters.AddWithValue("@V_bypass_input", !string.IsNullOrEmpty(V_bypass_input) ? Double.Parse(V_bypass_input) : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@KA_bypass_input", !string.IsNullOrEmpty(KA_bypass_input) ? Double.Parse(KA_bypass_input) : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PH_bypass_input", !string.IsNullOrEmpty(PH_bypass_input) ? Double.Parse(PH_bypass_input) : (object)DBNull.Value);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                    {
                        Console.WriteLine("Error inserting data into Database!");
                    }
                    return result;
                }
            }
        }

        public int saveUserProgressInputGroupbox(string quoteId, string input_Vac, string input_PH1, string input_KA1, string Vdc_charger)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                String query = "INSERT INTO P850_InputGroupbox_Save values (@quoteId, @input_Vac, @input_PH1, @input_KA1, @Vdc_charger)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@quoteId", quoteId);
                    command.Parameters.AddWithValue("@input_Vac", !string.IsNullOrEmpty(input_Vac) ? Double.Parse(input_Vac) : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@input_PH1", !string.IsNullOrEmpty(input_PH1) ? Double.Parse(input_PH1) : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@input_KA1", !string.IsNullOrEmpty(input_KA1) ? Double.Parse(input_KA1) : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Vdc_charger", !string.IsNullOrEmpty(Vdc_charger) ? Double.Parse(Vdc_charger) : (object)DBNull.Value);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                    {
                        Console.WriteLine("Error inserting data into Database!");
                    }
                    return result;
                }
            }
        }

        public int saveUserProgressBatteryGroupbox(string quoteId, string T_Battery, string Ah_Battery, string KA_battery)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                String query = "INSERT INTO P850_BatteryGroupbox_Save values (@quoteId, @T_Battery, @Ah_Battery, @KA_battery)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@quoteId", quoteId);
                    command.Parameters.AddWithValue("@T_Battery", !string.IsNullOrEmpty(T_Battery) ? Double.Parse(T_Battery) : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Ah_Battery", !string.IsNullOrEmpty(Ah_Battery) ? Double.Parse(Ah_Battery) : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@KA_battery", !string.IsNullOrEmpty(KA_battery) ? Double.Parse(KA_battery) : (object)DBNull.Value);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                    {
                        Console.WriteLine("Error inserting data into Database!");
                    }
                    return result;
                }
            }
        }


        //Other input saving
        public int saveUserProgressOtherInputs(string quoteId, Char upsOrInverter, string PF_output, string F_output, string F_bypass_input, string F_Battery)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                String query = "INSERT INTO Other_Inputs_Save values (@quoteId, @upsOrInverter, @PF_output, @F_output, @F_bypass_input, @F_Battery)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@quoteId", quoteId);
                    command.Parameters.AddWithValue("@upsOrInverter", upsOrInverter);
                    command.Parameters.AddWithValue("@PF_output", !string.IsNullOrEmpty(PF_output) ? Double.Parse(PF_output) : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@F_output", !string.IsNullOrEmpty(F_output) ? Double.Parse(F_output) : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@F_bypass_input", !string.IsNullOrEmpty(F_bypass_input) ? Double.Parse(F_bypass_input) : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@F_Battery", !string.IsNullOrEmpty(F_Battery) ? Double.Parse(F_Battery) : (object)DBNull.Value);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                    {
                        Console.WriteLine("Error inserting data into Database!");
                    }
                    return result;
                }
            }
        }

        /*
        //upload the progress of the user by groupbox 
        public async Task uploadUserProgress(String table, String quoteId, TextBox texbox1, TextBox texbox2, TextBox texbox3)
        {
            try
            {
                string stSql = $"SELECT * FROM {table}  WHERE quoteId = @quoteId ";
                SqlConnection OConn = new SqlConnection(_connectionString);
                await OConn.OpenAsync();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Ocmd.Parameters.AddWithValue("@quoteId", quoteId);
                SqlDataReader Oreadr = await Ocmd.ExecuteReaderAsync();
                while (await Oreadr.ReadAsync())
                {
                    texbox1.Text = Oreadr[_ = texbox1.Name.ToString()].ToString();
                    texbox2.Text = Oreadr[_ = texbox2.Name.ToString()].ToString();
                    texbox3.Text = Oreadr[_ = texbox3.Name.ToString()].ToString();

                }

                OConn.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        */

        public async Task uploadUserProgress(string table, string quoteId, Dictionary<string, Control> controls)
        {
            try
            {
                string stSql = $"SELECT * FROM {table} WHERE quoteId = @quoteId";
                using (SqlConnection OConn = new SqlConnection(_connectionString))
                {
                    await OConn.OpenAsync();
                    using (SqlCommand Ocmd = new SqlCommand(stSql, OConn))
                    {
                        Ocmd.Parameters.AddWithValue("@quoteId", quoteId);
                        using (SqlDataReader Oreadr = await Ocmd.ExecuteReaderAsync())
                        {
                            if (await Oreadr.ReadAsync())
                            {
                                foreach (var entry in controls)
                                {
                                    string columnName = entry.Key; // The expected column name
                                    Control control = entry.Value; // The UI control

                                    if (Oreadr[columnName] != DBNull.Value)
                                    {
                                        string value = Oreadr[columnName].ToString();

                                        if (control is TextBox textBox)
                                        {
                                            textBox.Text = value;
                                        }
                                        else if (control is ComboBox comboBox)
                                        {
                                            comboBox.SelectedItem = value; // Ensure the value exists in the items list
                                        }
                                        else if (control is Label label)
                                        {
                                            label.Text = value;
                                        }
                                        // Add more control types as needed
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        //upload a specific saving table of the user
        public String uploadOtherInputSaving(String quoteId, TextBox PF_output, TextBox F_output, TextBox F_bypass_input, TextBox F_battery)
        {
            String upsOrInverter = "";
            try
            {
                string stSql = $"SELECT * FROM Other_Inputs_Save  WHERE quoteId = @quoteId ";
                SqlConnection OConn = new SqlConnection(_connectionString);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Ocmd.Parameters.AddWithValue("@quoteId", quoteId);
                SqlDataReader Oreadr = Ocmd.ExecuteReader();
                while (Oreadr.Read())
                {
                    upsOrInverter = Oreadr[1].ToString();
                    PF_output.Text = Oreadr[_ = PF_output.Name.ToString()].ToString();
                    F_output.Text = Oreadr[_ = F_output.Name.ToString()].ToString();
                    F_bypass_input.Text = Oreadr[_ = F_bypass_input.Name.ToString()].ToString();
                    F_battery.Text = Oreadr[_ = F_battery.Name.ToString()].ToString();
                }

                OConn.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return upsOrInverter;
        }

        //delete an old user progress to save memory
        public int deleteOlddUserProgress(String table, String quoteId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                String query = $"Delete from {table} where quoteId = @quoteId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@quoteId", quoteId);
                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                    {
                        Console.WriteLine("Error deleting data into Database!");
                    }
                    return result;
                }
            }
        }



        public async Task<string> getChargerPrice(string chargerReference, String Idc_charger)
        {
            string chargerPrice = "";
            bool pricefound = false;
            //string Idc_charger = "column_name"; // Replace with actual column name

            using (SqlConnection OConn = new SqlConnection(M_stCon))
            {
                try
                {
                    await OConn.OpenAsync();

                    string stSql = $"SELECT * FROM configo_TBLTOXL13_pgc WHERE REF_CHRG = @chargerReference";
                    using (SqlCommand Ocmd = new SqlCommand(stSql, OConn))
                    {
                        Ocmd.Parameters.AddWithValue("@chargerReference", chargerReference);

                        using (SqlDataReader Oreadr = await Ocmd.ExecuteReaderAsync())
                        {
                            while (await Oreadr.ReadAsync())
                            {
                                chargerPrice = Oreadr[Idc_charger]?.ToString(); // Use null conditional operator for safer access
                                pricefound = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving charger price: {ex.ToString()}");
                    // Handle exception as needed, e.g., rethrow or return default value
                }
            }

            if (pricefound == false)
            {
                chargerPrice = "1000000";
            } 

            return chargerPrice;
            
        }

        //get the charger model depending of the language that the user is using 
        //look for the charger price 
        public List<string> getValidationDescriptionModel(String Language)
        {
            List<string> DescriptionModel = new List<string>();

            try
            {
                //[{Idc_charger}]
                string stSql = $"select * from P850DescriptionModel";
                SqlConnection OConn = new SqlConnection(_connectionString);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = Ocmd.ExecuteReader();
                while (Oreadr.Read())
                {
                    DescriptionModel.Add(Oreadr[Language].ToString());
                }

                OConn.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return DescriptionModel;
        }

        //get P850 cabinet size and charger desing 
        public async Task<(String, String)> P850CabinetAndChargerDesing(Char inverterOrUps, String phase, String KVA)
        {
            (String, String) cabinetAndDesign = ("", "");

            string stSql = $"select top 1 * from P850 where inverter_or_ups = '{inverterOrUps}' and kva9 = {KVA} and ph9 = {phase}";

            using (SqlConnection OConn = new SqlConnection(_connectionString))
            {
                try
                {
                    await OConn.OpenAsync();
                    using (SqlCommand Ocmd = new SqlCommand(stSql, OConn))
                    {
                        using (SqlDataReader Oreadr = await Ocmd.ExecuteReaderAsync())
                        {
                            while (await Oreadr.ReadAsync())
                            {
                                // dotnet_style_prefer_simplified_interpolation = true
                                cabinetAndDesign.Item1 = Oreadr["cabinet"].ToString() + " " + Oreadr["weight_P850"].ToString();
                                cabinetAndDesign.Item2 = Oreadr["charger_design"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving charger price: {ex.ToString()}");
                    // Handle exception as needed, e.g., rethrow or return default value
                }
            }
            //CBPrice = Math.Round(Double.Parse(CBPrice), 2).ToString();
            return (cabinetAndDesign);
        }


    }
}
