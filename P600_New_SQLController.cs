using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PGESCOM
{
    internal class P600_New_SQLController
    {
        public static string _connectionString = @"user id=" + "sa" + ";password=" + "darasam" + ";server=" + @"ERPSERVER\PSM_DB2K8K" + ";Trusted_Connection=No;database=" + "PGESCOM_NEW" + ";connection timeout=30";
        private DatabaseHelper dbHelper = new DatabaseHelper(_connectionString);
        private DatabaseHelper dbHelperOrig = new DatabaseHelper(MainMDI.M_stCon);


        public async Task getVacValues(ComboBox comboBox, String phase)
        {
            try
            {
                comboBox.Items.Clear();

                string query = "SELECT * FROM VacValues WHERE phase = @phase";

                var results = await dbHelper.ExecuteSelectQueryAsync(query, new Dictionary<string, object>
        {
            { "@phase", phase }
        });

                foreach (var row in results)
                {
                    comboBox.Items.Add(row["VACValues"].ToString());
                }

                comboBox.SelectedIndex = 4; // Set default index
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //get the possible values of the Vdc
        public async Task getVdcValues(ComboBox vdcComboBox)
        {
            try
            {
                string query = "SELECT * FROM VdcValues";

                var results = await dbHelper.ExecuteSelectQueryAsync(query);

                foreach (var row in results)
                {
                    vdcComboBox.Items.Add(row["Vdc"].ToString());
                }

                vdcComboBox.Text = vdcComboBox.Items[5]?.ToString(); // Set default value
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //get maximum Vdc or min Vdc depending on the currently selected Vdc from the comboBox 
        public async void getVdcMaxAndVdcMin(ComboBox vdcComboBox, TextBox vdcMax, TextBox vdcMin, Label cellNumber)
        {
            try
            {
                string query = "SELECT * FROM VdcValues WHERE Vdc = @Vdc";
                //var dbHelper = new DatabaseHelper(_connectionString);

                var results = await dbHelper.ExecuteSelectQueryAsync(query, new Dictionary<string, object>
        {
            { "@Vdc", vdcComboBox.Text }
        });

                if (results.Any())
                {
                    var row = results.First();
                    vdcMax.Text = row["VdcMax"].ToString();
                    vdcMin.Text = row["VdcMin"].ToString();
                    cellNumber.Text = row["numberCells"].ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //select the right delivery time depending on the generated charger
        public async Task<string> SelectLeadTime(string charger)
        {
            try
            {
                string query = "SELECT TOP 1 leadTime FROM Chargers_DeliveryDate WHERE charger = @charger";

                var results = await dbHelper.ExecuteSelectQueryAsync(query, new Dictionary<string, object>
        {
            { "@charger", charger }
        });

                return results.FirstOrDefault()?["leadTime"].ToString() ?? string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return string.Empty;
            }
        }

        public async Task IcbLookupP600(double ILookup, string phase, TextBox Idc)
        {
            try
            {
                string query = $"select top 1 ICB1 from Configo_CB1xx_CB2xx where cast([ICB1] as float) >= @ILookup and PHASE >= @Phase order by ICB1";
                var results = await dbHelperOrig.ExecuteSelectQueryAsync(query, new Dictionary<string, object>
                    {
                        {"@ILookup", ILookup},
                        {"@Phase", phase}
                    });
                Idc.Text = results.FirstOrDefault()?["ICB1"].ToString() ?? string.Empty;
                await Console.Out.WriteLineAsync(results.FirstOrDefault()?["ICB1"].ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        //insert validation details into P600_validation_details table ( for easy access ) 
        public async void insertIntoP600ValidationQuery(String validationId, String optionReference, String itemDescription, string quantity, String multiplicator, String unitPrice, String totalPrice, String leadTime)
        {
            try
            {
                string query = "INSERT INTO P600_validation_details " +
                               "VALUES (@validationId, @optionReference, @itemDescription, @quantity, @multiplicator, @unitPrice, @totalPrice, @leadTime)";

                var parameters = new Dictionary<string, object>
        {
            { "@validationId", validationId },
            { "@optionReference", !string.IsNullOrEmpty(optionReference) ? optionReference : (object)DBNull.Value },
            { "@itemDescription", !string.IsNullOrEmpty(itemDescription) ? itemDescription : (object)DBNull.Value },
            { "@quantity", !string.IsNullOrEmpty(quantity) ? Int32.Parse(quantity) : (object)DBNull.Value },
            { "@multiplicator", !string.IsNullOrEmpty(multiplicator) ? Double.Parse(multiplicator) : (object)DBNull.Value },
            { "@unitPrice", !string.IsNullOrEmpty(unitPrice) ? Double.Parse(unitPrice) : (object)DBNull.Value },
            { "@totalPrice", !string.IsNullOrEmpty(totalPrice) ? Double.Parse(totalPrice) : (object)DBNull.Value },
            { "@leadTime", !string.IsNullOrEmpty(leadTime) ? leadTime : (object)DBNull.Value }
        };

                int result = await dbHelper.ExecuteNonQueryAsync(query, parameters);

                if (result < 0)
                {
                    Console.WriteLine("Error inserting data into Database!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }





    }
}
