using CrystalDecisions.CrystalReports.Engine;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.IO;
using IronXL;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using Microsoft.Office.Interop.Word;

namespace PGESCOM
{
    public partial class P850UI_UPS_INV_New : System.Windows.Forms.Form
    {
        private CancellationTokenSource debounceTokenSource = null;

        //public string M_stCon = @"user id=" + "sa" + ";password=" + "darasam" + ";server=" + @"ERPSERVER\PSM_DB2K8K" + ";Trusted_Connection=No;database=" + "PGESCOM_test_app" + ";connection timeout=30";
        public string M_stCon = @"user id=" + "sa" + ";password=" + "darasam" + ";server=" + @"ERPSERVER\PSM_DB2K8K" + ";Trusted_Connection=No;database=" + "PGESCOM_NEW" + ";connection timeout=30";
        P850UI_UPS_INV_New_Controller P850Controller = new P850UI_UPS_INV_New_Controller();
        P850UI_UPS_INV_New_SQL_Controller P850SQLController = new P850UI_UPS_INV_New_SQL_Controller();
        FindBestUPSInverter UPSInverter = new FindBestUPSInverter();

        //Params 
        private String P850quoteId = "";
        private String P850Multiplicator;
        private Char UpsOrInverterParams;
        private String LangueParams;

        //Cbs default price
        private String Cb1DefaultKA;
        private String Cb3DefaultKA;
        private String Cb4DefaultKA;

        //Cb4 Price
        (String, String) Cb4Price = ("", "");

        //Fcb1Phase1 and Fcb1Phase3
        String Fcb1Phase1 = "";
        String Fcb1Phase3 = "";
        public String OldValidationId = "";
        private double TotalPriceP850 = 0.0;


        //import datas to the submission on ok click depending on saveText values
        public String saveText = "N"; // N = No and Y = Yes


        public P850UI_UPS_INV_New(String quoteId, String multiplicator, Char UpsOrInverter, String Langue)
        {
            InitializeComponent();
            LoadDataAsync();

            //initialize the quote ID and multiplicator
            P850quoteId = quoteId;
            P850Multiplicator = multiplicator;
            LangueParams = Langue;
            Char inverterOrUPS = radioButtonUPS.Checked ? 'u' : 'i';
            //UpsOrInverterParams = UpsOrInverter; was the  first version but we decided to upgrade it -- can go back to this if needed
            UpsOrInverterParams = inverterOrUPS;

            //default values of some input
            input_PH1.Text = "3";
            input_KA1.Text = "1";
            Frequency.SelectedIndex = 1;
            //Battery groupbox
            Ah_Battery.Text = "1";
            T_Battery.Text = "10";
            kA_battery.Text = "1";
            //Bypass input groupbox
            PH_bypass_input.Text = "1";
            kA_bypass_input.Text = "1";           

            String upsOrInverterUpload = P850SQLController.uploadOtherInputSaving(quoteId, PF_output, F_output, F_bypass_input, F_Battery);

            //Fb textbox
            P850SQLController.getBatteryTypeValue(BatteryComboBox.Text.ToString(), F_Battery);

            if (upsOrInverterUpload != "")
            {
                if (upsOrInverterUpload == "u")
                {
                    radioButtonUPS.Checked = true;
                }
                else
                {
                    radioButtonInverter.Checked = true;
                }
            }

            //initiliaze the charger type to P4600
            ChargerType.Text = ChargerType.Items[0].ToString();


            //PHcb5 && PHcb5 default value
            PHcb5.Text = "1";
            PHcb6.Text = "1";


            //maximization of the form
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            KVA_output.Text = "10";
        }

        //get totalPrice
        public double getTotalPriceP850()
        {
            return this.TotalPriceP850;
        }

        private async void LoadDataAsync()
        {
            this.Cursor = Cursors.WaitCursor;
            await GetFactorDefaultValues();
            Dictionary<string, Control> modelDefaultValueControls = CreateControlDictionary(P850Model, Ph_output, KVA_output, V_output, VdcComboBox, V_Inverter);
            await P850SQLController.getModelDefaultValues(modelDefaultValueControls, UpsOrInverterParams);

            //default values of some input
            input_PH1.Text = "3";
            input_KA1.Text = "10";
            Frequency.SelectedIndex = 1;
            //Battery groupbox
            Ah_Battery.Text = "1";
            T_Battery.Text = "10";
            kA_battery.Text = "1";
            //Bypass input groupbox
            PH_bypass_input.Text = "1";
            kA_bypass_input.Text = "10";

            await P850SQLController.getBatteries(BatteryComboBox);

            await P850SQLController.getVdcValues(VdcComboBox);
            await P850SQLController.getVacValues(input_Vac, "3"); //default phase to 3 
            await P850SQLController.getVacValues(V_bypass_input, "1"); //default phase to 1
            await P850SQLController.getVacValues(V_output, "1"); //default phase to 1

            //load user progress 
            Dictionary<string, Control> batteryControls = CreateControlDictionary(T_Battery, Ah_Battery, kA_battery);
            await P850SQLController.uploadUserProgress("P850_BatteryGroupbox_Save", P850quoteId, batteryControls);
            Dictionary<string, Control> bypassControls = CreateControlDictionary(V_bypass_input, kA_bypass_input, PH_bypass_input);
            await P850SQLController.uploadUserProgress("P850_BatteryGroupbox_Save", P850quoteId, bypassControls);
            Dictionary<string, Control> inputControls = CreateControlDictionary(input_Vac, input_KA1, input_PH1);
            await P850SQLController.uploadUserProgress("P850_BatteryGroupbox_Save", P850quoteId, inputControls);
            Dictionary<string, Control> ouputControls = CreateControlDictionary(V_output, Ph_output, KVA_output);
            await P850SQLController.uploadUserProgress("P850_BatteryGroupbox_Save", P850quoteId, ouputControls);


            this.Cursor = Cursors.Default;
        }

        public Dictionary<string, Control> CreateControlDictionary(params Control[] controls)
        {
            Dictionary<string, Control> controlDict = new Dictionary<string, Control>();

            foreach (var control in controls)
            {
                if (!string.IsNullOrEmpty(control.Name)) // Ensure the control has a valid name
                {
                    controlDict[control.Name] = control;
                }
                else
                {
                    throw new ArgumentException("One or more controls do not have a valid Name property set.");
                }
            }

            return controlDict;
        }


        //get the right model if Ph_output, KVA_output, V_output, Vdc_charger text change
        public async void GetModelOnTextChange()
        {
            if (Ph_output.Text.ToString() != "" && KVA_output.Text.ToString() != "" && V_output.Text.ToString() != "" && VdcComboBox.Text.ToString() != "")
            {
                int int_Ph_output = Int32.Parse(Ph_output.Text.ToString());
                float float_KVA_output = float.Parse(KVA_output.Text.ToString());
                int int_V_output = Int32.Parse(V_output.Text.ToString());
                int int_Vdc_charger = Int32.Parse(VdcComboBox.Text.ToString());

                await UPSInverter.GetP850Model(int_Ph_output, float_KVA_output, int_V_output, int_Vdc_charger, UpsOrInverterParams.ToString());
                if (UPSInverter.upsModel != "")
                {
                    P850Model.Text = UPSInverter.upsModel;
                }
            }
        }


        //get the default values of the factors 
        public async Task GetFactorDefaultValues()
        {
            try
            {
                string stSql = "SELECT * FROM UpsFactor_defaultValue";

                SqlConnection OConn = new SqlConnection(M_stCon);
                await OConn.OpenAsync();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = await Ocmd.ExecuteReaderAsync();
                while (await Oreadr.ReadAsync())
                {
                    Fcb5.Text = Oreadr["kcb5"].ToString();
                    F_output.Text = Oreadr["k9"].ToString();
                    F_bypass_input.Text = Oreadr["k12"].ToString();
                    Fcb3.Text = Oreadr["kcb3"].ToString();
                    Fcb4.Text = Oreadr["kcb4"].ToString();
                    Fcb7.Text = Oreadr["kcb7"].ToString();
                    Fcb3.Text = Oreadr["kcb3"].ToString();
                    Fcb6.Text = Oreadr["kcb6"].ToString();
                    Fcb1.Text = Oreadr["Fcb1Phase1"].ToString();
                    Fcb2.Text = Oreadr["defaultValue"].ToString();
                    Ft3.Text = Oreadr["defaultValue"].ToString();
                    //transform the efficiency data to %
                    double efficiency = Double.Parse(Oreadr["kinv"].ToString()) * 100;
                    inv_efficiency.Text = efficiency.ToString();

                    //tranform imp data to %
                    double imp = Double.Parse(Oreadr["imp"].ToString()) * 100;
                    Imp.Text = imp.ToString();

                    //store the Fcb1Phase1 and Fcb1Phase3 in case of changes of the phase (Ph_output)
                    Fcb1Phase1 = Oreadr["Fcb1Phase1"].ToString();
                    Fcb1Phase3 = Oreadr["Fcb1Phase3"].ToString();
                }
                OConn.Close();
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }

        }

        //cancel button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MainMDI.Confirm("Are you sure you want to cancel ? All unsaved progress will be lost."))
            {
                this.Dispose();
            }
        }


        // ok button
        private void ok_button_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("Please Validate the charger to continue");
            }
            else
            {
                saveText = "Y";
                this.Hide();
                this.Dispose(true);
            }

        }

        public async Task Cb1Insertion(List<(String, String)> CbPricesList, String validationId, List<string> DescriptionModel,string inputBreaker)
        {
            if (Double.Parse(input_KA1.Text) > Double.Parse(Cb1DefaultKA))
            {
                try
                {
                    if (CbPricesList.Count > 0)
                    {
                        TotalPriceP850 += Double.Parse(CbPricesList[0].Item1);
                        //insertion of the datas
                        double totalPrice = Double.Parse(CbPricesList[0].Item1) * Double.Parse(P850Multiplicator);
                        await P850SQLController.insertIntoP850ValidationQuery(validationId, DescriptionModel[2], inputBreaker, "", "", $"{CbPricesList[0].Item1}", $"{totalPrice}", "");
                    }
                    else
                    {
                        MessageBox.Show("liste prix cb nul");
                        Console.WriteLine("La liste des prix des cb est nul");
                    }

                }
                catch (Exception error)
                {
                    Console.WriteLine(error.ToString());
                }

            }
        }

        //insert the base entries into the database that will later be retrieved to fill the ListView
        private async Task ValidationDataInsert(string validationId, List<(string, string)> CbPricesList, (string, string) P850CabinetAndDesign)
        {
            try
            {
                var descriptionModel = P850SQLController.getValidationDescriptionModel(LangueParams);
                string leadTime = P850SQLController.SelectLeadTime("P850");

                double totalPriceCharger = double.Parse(total_textbox.Text) * double.Parse(P850Multiplicator);

                // Common data definitions
                var dataEntries = new List<(int, string, string, bool)>
        {
            (0, $"{P850Model.Text}", quantity_textbox.Text, true), // Model
            (1, $"{input_Vac.Text} V +10% / -12%, {input_PH1.Text} ph, {input_I1.Text} A, {Frequency.Text}Hz", "", false), // UPS Input
            (3, $"{V_output.Text}V, {KVA_output.Text}kVA-{KW_Output.Text}kW at {PF_output.Text}pf, {Ph_output.Text}ph, {I_output.Text}A, {Frequency.Text}Hz", "", false), // UPS Output
            (6, $"{VdcComboBox.Text}Vdc, {Idc_inverter.Text}A, {KWb.Text}kWb", "", false), // Inverter Input
            (10, $"{Vcb1.Text}V, {Icb1.Text}A, {PHcb1.Text}pole, {KAcb1.Text}kA", "", false), // Charger Input Breaker
            (9, $"{VdcComboBox.Text}V, {Idc_charger.Text}A", "", false), // Charger Output
            (12, $"{VdcComboBox.Text}Vdc, {IbchNew.Text}A", "", false) // Battery Charging
        };

                // Insert static data
                foreach (var (index, value, quantity, hasPrice) in dataEntries)
                {
                    await P850SQLController.insertIntoP850ValidationQuery(
                        validationId, descriptionModel[index], value, quantity, hasPrice ? P850Multiplicator : "",
                        hasPrice ? UnitCost_textbox.Text : "", hasPrice ? totalPriceCharger.ToString() : "", hasPrice ? leadTime : "");
                }

                // Insert UPS cabinet and description
                await P850SQLController.insertIntoP850ValidationQuery(validationId, "Cabinet : ", P850CabinetAndDesign.Item1, "", "", "", "", "");
                await P850SQLController.insertIntoP850ValidationQuery(validationId, "Industrial grade UPS including : ", P850CabinetAndDesign.Item2 + ", IGBT based inverter and back-to-back SCR STS", "", "", "", "", "");

                // Frequency operation price adjustment
                if (Frequency.SelectedIndex == 0)
                {
                    double totalPriceMajoration = totalPriceCharger * 0.05;
                    await P850SQLController.insertIntoP850ValidationQuery(validationId, descriptionModel[4], $"{Frequency.Text}Hz", quantity_textbox.Text, P850Multiplicator, totalPriceMajoration.ToString(), totalPriceMajoration.ToString(), "");
                }
                else
                {
                    await P850SQLController.insertIntoP850ValidationQuery(validationId, descriptionModel[4], $"{Frequency.Text}Hz", "", "", "", "", "");
                }

                // Insert breaker data dynamically
                var breakerData = new (int, int, string, System.Windows.Forms.CheckBox)[]
                {
            (5, 6, $"{Vcb7.Text}V, {Icb7.Text}A, {PHcb7.Text}pole, {Kacb7.Text}kA", CB7_Yes),
            (7, 5, $"{Vcb6.Text}V, {Icb6.Text}A, {PHcb6.Text}pole, {KAcb6.Text}kA", CB6_Yes),
            (8, 4, $"{Vcb5.Text}V, {Icb5.Text}A, {PHcb5.Text}pole, {KAcb5.Text}kA", CB5_Yes),
            (11, 1, $"{Vcb2.Text}V, {Icb2.Text}A, {PHcb2.Text}pole, {KAcb2.Text}kA", Cb2_Yes)
                };

                foreach (var (descIndex, cbIndex, value, checkBox) in breakerData)
                {
                    if (checkBox.Checked)
                    {
                        double totalPrice = double.Parse(CbPricesList[cbIndex].Item1) * double.Parse(P850Multiplicator);
                        TotalPriceP850 += double.Parse(CbPricesList[cbIndex].Item1);
                        await P850SQLController.insertIntoP850ValidationQuery(validationId, descriptionModel[descIndex], value, quantity_textbox.Text, P850Multiplicator, CbPricesList[cbIndex].Item1, totalPrice.ToString(), "");
                    }
                }

                // Battery Breaker Condition
                if (double.Parse(kA_battery.Text) > double.Parse(Cb3DefaultKA))
                {
                    double totalPrice = double.Parse(CbPricesList[2].Item1) * double.Parse(P850Multiplicator);
                    TotalPriceP850 += double.Parse(CbPricesList[2].Item1);
                    await P850SQLController.insertIntoP850ValidationQuery(validationId, descriptionModel[13], $"{Vcb3.Text}V, {Idc_charger.Text}A, {PHcb3.Text}pole, {KAcb3.Text}kA", quantity_textbox.Text, P850Multiplicator, CbPricesList[2].Item1, totalPrice.ToString(), "");
                }
                else
                {
                    await P850SQLController.insertIntoP850ValidationQuery(validationId, descriptionModel[13], $"{Vcb3.Text}V, {Idc_charger.Text}A, {PHcb3.Text}pole, {KAcb3.Text}kA", "", "", "", "", "");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        //MBS data insertion ( will later be used in the validate button onclick) 
        private async Task MBSDataInsertion(String validationId, (String, String, String) OMBSPriceAndCabinet, String chargerPrice, (String, String) MBSPriceAndCabinet)
        {
            try
            {
                //get the model description 
                List<string> DescriptionModel = new List<string>();
                DescriptionModel = P850SQLController.getValidationDescriptionModel(LangueParams);

                //Mbs
                string MBSInput = $"{V_bypass_input.Text}V +/ -10 %, {Ph_output.Text}ph, {Frequency.Text}Hz, {I_output.Text}A";
                //Cb4
                string MBSInputCircuitBreaker = $"{Vcb4.Text}V, {Icb4.Text}A, {PHcb4.Text}pole(s), {KaCb4.Text}kA";
                string OMBSInputCircuitBreaker = $"{Vcb4.Text}V, {Icb4.Text}A, {PHcb4.Text}pole(s), {KaCb4.Text}kA"; //(optional)

                //Ombs
                if (Bypass_input_yes_checkbox.Checked && T3_Yes.Checked)
                {
                    if (UpsOrInverterParams == 'u')
                    {
                        double newIbch = Double.Parse(IbchNew.Text) - Double.Parse(IbchStart.Text);
                        double totalPrice = Double.Parse(chargerPrice) * Double.Parse(P850Multiplicator);
                        await P850SQLController.insertIntoP850ValidationQuery(validationId, DescriptionModel[14], $"{newIbch} A", quantity_textbox.Text, $"{P850Multiplicator}", $"{chargerPrice}", $"{totalPrice}", "");
                    }
                    double OmbstotalPrice = Double.Parse(OMBSPriceAndCabinet.Item1) * Double.Parse(P850Multiplicator);
                    await P850SQLController.insertIntoP850ValidationQuery(validationId, "OMBS Description", $"{OMBSPriceAndCabinet.Item3}", "", "", "", "", "");
                    await P850SQLController.insertIntoP850ValidationQuery(validationId, DescriptionModel[17], OMBSInputCircuitBreaker, quantity_textbox.Text, $"{P850Multiplicator}", $"{OMBSPriceAndCabinet.Item1}", $"{OmbstotalPrice}", "");
                }

                //Mbs
                else if (Bypass_input_yes_checkbox.Checked && T3_No.Checked)
                {
                    // for format purpose
                    await P850SQLController.insertIntoP850ValidationQuery(validationId, "Options : ", "", "", "", "", "", "");
                    if (UpsOrInverterParams == 'u')
                    {
                        double newIbch = Double.Parse(IbchNew.Text) - Double.Parse(IbchStart.Text);
                        double totalPrice = Double.Parse(chargerPrice) * Double.Parse(P850Multiplicator);
                        await P850SQLController.insertIntoP850ValidationQuery(validationId, DescriptionModel[14], $"{newIbch} A", quantity_textbox.Text, $"{P850Multiplicator}", $"{chargerPrice}", $"{totalPrice}", "");
                    }

                    //affichage du prix du mbs
                    if (MBS_Yes.Checked && Double.Parse(V_bypass_input.Text) != Double.Parse(V_output.Text))
                    {
                        //MBS input
                        await P850SQLController.insertIntoP850ValidationQuery(validationId, DescriptionModel[15], MBSInput, quantity_textbox.Text.ToString(), $"{P850Multiplicator}", "999999", "999999", "");
                        MBSPriceAndCabinet.Item2 = "999999";
                    }
                    if (Double.Parse(V_bypass_input.Text) == Double.Parse(V_output.Text))
                    {
                        double totalPrice = Double.Parse(MBSPriceAndCabinet.Item1) * Double.Parse(P850Multiplicator);
                        await P850SQLController.insertIntoP850ValidationQuery(validationId, DescriptionModel[15], MBSInput, quantity_textbox.Text.ToString(), $"{P850Multiplicator}", MBSPriceAndCabinet.Item1, $"{totalPrice}", "");
                        //MBS input circuit breaker
                        double totalPriceCb4 = Double.Parse(Cb4Price.Item1) * Double.Parse(P850Multiplicator);
                        await P850SQLController.insertIntoP850ValidationQuery(validationId, DescriptionModel[16], MBSInputCircuitBreaker, quantity_textbox.Text.ToString(), $"{P850Multiplicator}", Cb4Price.Item1, totalPriceCb4.ToString(), "");
                    }
                    else
                    {
                        //MBS input circuit breaker
                        double totalPrice = Double.Parse(MBSPriceAndCabinet.Item1) * Double.Parse(P850Multiplicator);
                        await P850SQLController.insertIntoP850ValidationQuery(validationId, DescriptionModel[16], MBSInputCircuitBreaker, quantity_textbox.Text.ToString(), $"{P850Multiplicator}", MBSPriceAndCabinet.Item1, $"{totalPrice}", "");
                    }


                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }
        }

        //help to verify if the cb prices are higher than the default one and charge the client for the extra
        private async Task<List<(String, String)>> CheckCbPrice()
        {
            //default CBKA
            Cb1DefaultKA = await P850SQLController.CBKADefaultValue("CB1", PHcb1.Text);
            Cb3DefaultKA = await P850SQLController.CBKADefaultValue("CB3", PHcb3.Text);
            Cb4DefaultKA = await P850SQLController.CBKADefaultValue("CB4", PHcb4.Text);

            //Calculate CBPrice
            (String, String) Cb1Price = await P850SQLController.CbPriceSelector("CB1", Icb1, Vcb1, KAcb1.Text);
            (String, String) Cb2Price = await P850SQLController.CbPriceSelector("CB2", Icb2, Vcb2, KAcb2.Text);
            (String, String) Cb3Price = await P850SQLController.CbPriceSelector("CB3", Icb3, Vcb3, KAcb3.Text);
            Cb4Price  = await P850SQLController.CbPriceSelector("CB4", Icb4, Vcb4, KaCb4.Text);
            (String, String) Cb5Price = await P850SQLController.CbPriceSelector("CB5", Icb5, Vcb5, KAcb5.Text);
            (String, String) Cb6Price = await P850SQLController.CbPriceSelector("CB6", Icb6, Vcb6, KAcb6.Text);
            (String, String) Cb7Price = await P850SQLController.CbPriceSelector("CB7", Icb7, Vcb7, Kacb7.Text);

             
            // Create an ArrayList
            // Create a List of tuples
            List<(String, String)> CbPricesList = new List<(String, String)>();
            //ArrayList CbPricesList = new ArrayList();

            // Add tuples to the ArrayList
            CbPricesList.Add(Cb1Price); CbPricesList.Add(Cb2Price); CbPricesList.Add(Cb3Price); CbPricesList.Add(Cb4Price);
            CbPricesList.Add(Cb5Price); CbPricesList.Add(Cb6Price); CbPricesList.Add(Cb7Price);

            return CbPricesList;
        }

        private async Task<(string, string, string)> OMBSPriceONValidation()
        {
            //OMBS price
            (string, string, string) OMBSPriceAndCabinet = ("", "", "");
            if (Bypass_input_yes_checkbox.Checked && T3_Yes.Checked)
            {

                if (PH_bypass_input.Text == "1")
                {
                    try
                    {
                        OMBSPriceAndCabinet = P850SQLController.OMBSPrice(KVA_output, "P850_OMBS_Cell_Phase1");
                        TotalPriceP850 += Double.Parse(OMBSPriceAndCabinet.Item1);
                    }
                    catch (Exception ex)
                    {
                        await Console.Out.WriteLineAsync(ex.Message);
                    }

                }
                else
                {
                    OMBSPriceAndCabinet = P850SQLController.OMBSPrice(KVA_output, "P850_OMBS_Cell_Phase3");
                    TotalPriceP850 += Double.Parse(OMBSPriceAndCabinet.Item1);
                }
            }
            return OMBSPriceAndCabinet;
        }

        private bool groupBoxInputVerification()
        {
            bool verification1 = P850Controller.OutputGroupboxVerification(V_output, Ph_output, KVA_output);
            bool verification2 = P850Controller.BatteryGroupboxVerification(T_Battery, Ah_Battery, kA_battery);
            bool verification3 = P850Controller.BypassInputGroupboxVerification(kA_bypass_input, PH_bypass_input);
            bool verification4 = P850Controller.InputGroupboxVerification(input_PH1, input_KA1);

            if (verification1 && verification2 && verification3 && verification4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private async  Task<String> chargerPriceOnValidation()
        {
            //calculate the price of the charger
            String chargerPrice = "0";
            double IbchDifference = Double.Parse(IbchNew.Text) - Double.Parse(IbchStart.Text);
            if (Double.Parse(VdcComboBox.Text) < 125)
            {
                chargerPrice = "1000000";
                return chargerPrice;
            }
            if (IbchDifference > 1.5)
            {
                chargerPrice = await P850Controller.CalculateChargerPrice(UpsOrInverterParams, KW_Output, VdcComboBox, Double.Parse(IbchNew.Text), Double.Parse(IbchStart.Text), input_PH1, Idc_charger);
            }

            if (chargerPrice != "")
            {
                TotalPriceP850 += Double.Parse(chargerPrice);
            }
            else
            {
                MessageBox.Show("Couldn't find the right charger");
            }
            return chargerPrice;
        }

        private async void btn_validate_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (string.IsNullOrEmpty(KAcb3.Text))
            {
                MessageBox.Show("Could't find the right KA for the Cb3 groupbox");
                return;
            }

            if (!groupBoxInputVerification() || !double.TryParse(KVA_output.Text, out double kvaValue) || kvaValue >= 200)
            {
                MessageBox.Show("Some Values are empty!!");
                return;
            }

            // Cache description model
            List<string> descriptionModel = P850SQLController.getValidationDescriptionModel(LangueParams);

            // Remove old validation
            if (!string.IsNullOrEmpty(OldValidationId))
            {
                P850SQLController.DeleteIntoP850ValidationQuery(OldValidationId);
            }

            string validationId = Guid.NewGuid().ToString();
            OldValidationId = validationId;

            // Parallel execution of tasks
            var ombsPriceTask = OMBSPriceONValidation();
            var chargerPriceTask = chargerPriceOnValidation();
            var p850CabinetTask = P850SQLController.P850CabinetAndChargerDesing(UpsOrInverterParams, Ph_output.Text, KVA_output.Text);
            var cbPricesTask = CheckCbPrice();

            // Price Calculation
            if (double.TryParse(VdcComboBox.Text, out double vdcValue) && vdcValue < 125)
            {
                UnitCost_textbox.Text = "1000000";
                total_textbox.Text = "1000000";
            }
            else
            {
                try
                {
                    P850Controller.GetUnitCostAndTotalPrice(Ph_output, P850Model, UnitCost_textbox, quantity_textbox, KVA_output, total_textbox);
                    if (double.TryParse(total_textbox.Text, out double totalPrice))
                    {
                        TotalPriceP850 += totalPrice;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            // Await all parallel tasks
            var ombsPriceAndCabinet = await ombsPriceTask;
            var chargerPrice = await chargerPriceTask;
            var p850CabinetAndDesign = await p850CabinetTask;
            var cbPricesList = await cbPricesTask;

            // Calculate MBS Price
            (string, string) mbsPriceAndDescription = ("", "");
            if (Bypass_input_yes_checkbox.Checked && T3_No.Checked && MBS_Yes.Checked)
            {
                mbsPriceAndDescription = P850SQLController.MBSPrice(KVA_output);
                if (double.TryParse(mbsPriceAndDescription.Item1, out double mbsPrice))
                {
                    TotalPriceP850 += mbsPrice;
                }
            }

            // Insert Validation Data
            await ValidationDataInsert(validationId, cbPricesList, p850CabinetAndDesign);
            await MBSDataInsertion(validationId, ombsPriceAndCabinet, chargerPrice, mbsPriceAndDescription);

            if (!string.IsNullOrEmpty(ombsPriceAndCabinet.Item2))
            {
                await P850SQLController.insertIntoP850ValidationQuery(validationId, descriptionModel[18], ombsPriceAndCabinet.Item2, "", "", "", "", "");
            }

            await P850SQLController.insertIntoP850ValidationQuery(validationId, " ", descriptionModel[19], "", "", "", "", "");

            // Populate listView
            P850SQLController.fill_listview(P850Multiplicator, listView1, validationId);

            this.Cursor = Cursors.Default;
        }

        private void T3_Yes_CheckedChanged(object sender, EventArgs e)
        {
            if (T3_Yes.Checked)
            {
                T3_No.Checked = false;
                I_bypass_input.Text = It3p.Text.ToString();
                P850Controller.Icb4T3CheckedCalculs(Icb4, It3p, Fcb4);
                T3_Yes.Checked = true;
                T3_groupbox.Visible = true;
                T3_groupbox2.Visible = true;
            }
            else
            {
                if (Double.Parse(V_bypass_input.Text) == Double.Parse(V_output.Text))
                {
                    T3_No.Checked = true;
                    I_bypass_input.Text = I_output.Text.ToString();
                    P850Controller.Icb4T3UncheckedCalculs(Icb4, I_output, Fcb4);
                }
                else
                {
                    MessageBox.Show("Can not change to No since V Bypass is not equal to V output");
                    T3_Yes.Checked = true;
                }

            }
        }

        private void T3_No_CheckedChanged(object sender, EventArgs e)
        {
            if (T3_No.Checked)
            {
                T3_Yes.Checked = false;
                T3_groupbox.Visible = false;
                T3_groupbox2.Visible = false;
            }
            else
            {
                T3_Yes.Checked = true;
                T3_No.Checked = false;
                T3_groupbox.Visible = true;
                T3_groupbox2.Visible = true;
            }

        }

        //Inverter 
        private void inv_eff_TextChanged(object sender, EventArgs e)
        {
            P850Controller.InputVerification(inv_efficiency);

            P850Controller.KWbInvCalculs(KWb, KW_Output, inv_efficiency);

            //Ib Calculs
            P850Controller.IbCalculs(IbchNew, Ah_Battery, T_Battery, KW_Output, inv_efficiency, F_Battery, Vdc_min);

            if (inv_efficiency.Text.ToString() != "")
            {
                if (Int32.Parse(inv_efficiency.Text.ToString()) > 100)
                {
                    MessageBox.Show("the efficiency cannot ne be higher than 100%");
                    inv_efficiency.Text = "";
                }
                //can<t be lower than 15%
                if (Int32.Parse(inv_efficiency.Text.ToString()) < 15)
                {
                    MessageBox.Show("the efficiency cannot be lower than 15%");
                    inv_efficiency.Text = "";
                }


            }

        }


        //Output Groupbox 

        //phase (can either be 1 or 3 ) 
        private async void Ph_output_TextChanged(object sender, EventArgs e)
        {


            if (Ph_output.Text.ToString() != "")
            {
                //make sure that the phase is either be 1 or 3 
                if (Ph_output.Text.ToString() == "1" || Ph_output.Text.ToString() == "3")
                {
                    P850Controller.InputVerification(Ph_output);

                    //GetModelOnTextChange();

                    P850Controller.It3pCalculs(Kvat3, Vt3p, It3p, Ph_output, Ft3);
                    P850Controller.It3sCalculs(Kvat3, Vt3s, It3s, Ph_output);
                    //dynamic calculs depending on the text change
                    PHcb7.Text = Ph_output.Text.ToString();
                    PHcb4.Text = Ph_output.Text.ToString();
                    PHcb5.Text = Ph_output.Text.ToString();

                    //
                    P850Controller.KwbpCalculs(KW_bypass_input, KVAbp, Ph_output);


                    PH_bypass_input.Text = Ph_output.Text;
                    await P850SQLController.getVacValues(V_output, Ph_output.Text);
                    if (Ph_output.Text == "1")
                    {
                        V_output.SelectedIndex = 1;
                    }

                    var controls = CreateControlDictionary(KVA_output, V_output, Ph_output, I_output, Icb7, Fcb7);
                    P850Controller.I9OutputCalculs(controls);

                    PHcb7.Text = Ph_output.Text.ToString();
                }
                else
                {
                    MessageBox.Show("the phase can only be be 1 or 3");
                    Ph_output.Text = "";
                }
            }
        }


        private void KW_Output_TextChanged(object sender, EventArgs e)
        {
            //Ib Calculs
            //P850Controller.IbCalculs(I_battery, Ah_Battery, T_Battery, KW_Output, inv_efficiency, F_Battery, Vdc_min);
            P850Controller.IbChLogic(VdcComboBox, T_Battery, KW_Output, DCLoad, Ah_Battery, F_Battery, IbchNew, IbchStart);

            P850Controller.KWbInvCalculs(KWb, KW_Output, inv_efficiency);

            P850Controller.IdcInverterCalculs(Idc_inverter, KW_Output, Vdc_min, inv_efficiency);
        }

        private async void KVA_output_TextChanged(object sender, EventArgs e)
        {
            debounceTokenSource?.Cancel();
            debounceTokenSource = new CancellationTokenSource();

            try
            {
                // Wait for 300 milliseconds
                await Task.Delay(300, debounceTokenSource.Token);

                //performAction
                if (!string.IsNullOrWhiteSpace(KVA_output.Text))
                {
                    P850Controller.InputVerification(KVA_output);

                    GetModelOnTextChange();

                    //Dynamic variable calculs 
                    P850Controller.KVAt3Calculs(KVA_output, Kvat3, Ft3);

                    if (!input_Vac.Text.Equals(""))
                    {
                        String VacLookupValue = P850Controller.VACLookupValue(Double.Parse(input_Vac.Text));
                        var controls = CreateControlDictionary(Kacb7, KVA_output, V_output, Icb7);
                        P850Controller.Kacb7Calculs(controls,VacLookupValue);
                    }


                    KVAbp.Text = KVA_output.Text.ToString();

                    if (V_output.Text != "" && Ph_output.Text != "")
                    {
                        var controls = CreateControlDictionary(KVA_output, V_output, Ph_output, I_output, Icb7, Fcb7);
                        //P850Controller.I9OutputCalculs(KVA_output, V_output, Ph_output, I_output, Icb7, Fcb7);
                        P850Controller.I9OutputCalculs(controls);
                    }

                    //verification for KW9
                    if (PF_output.Text != "")
                    {
                        P850Controller.KW9OutputCalculs(KVA_output, PF_output, KW_Output);
                    }
                }

            }
            catch (TaskCanceledException)
            {
                await Console.Out.WriteLineAsync("Task canceled...");
            }

        }

        private void PF_output_TextChanged(object sender, EventArgs e)
        {
            P850Controller.InputVerification(PF_output);

            Pft3.Text = PF_output.Text.ToString();
            PF_bypass_input.Text = PF_output.Text.ToString();
            P850Controller.Kwt3Calculs(Kvat3, PF_bypass_input, KWt3);


            //verification for KW9
            if (KVA_output.Text != "")
            {
                P850Controller.KW9OutputCalculs(KVA_output, PF_output, KW_Output);
            }

        }

        //charger model label onlick
        private void lChrgREF_Click(object sender, EventArgs e)
        {
            UPSInverter.ShowDialog();
            if (UPSInverter.upsModel != "")
            {
                P850Model.Text = UPSInverter.upsModel;
                KVA_output.Text = UPSInverter.Kvao;

                // V_Inverter = Vdc_charger
                VdcComboBox.Text = UPSInverter.Vdc;
                V_Inverter.Text = UPSInverter.Vdc;

                V_output.Text = UPSInverter.Vo;
                Ph_output.Text = UPSInverter.Pho;
            }

        }


        // I_output (Output groupbox)
        private void Ibp_TextChanged(object sender, EventArgs e)
        {
            if (T3_No.Checked)
            {
                I_bypass_input.Text = I_output.Text.ToString();
                P850Controller.Icb4T3UncheckedCalculs(Icb4, I_output, Fcb4);
            }

            //Icb5 lookup
            P850Controller.Icb5Calculs(Icb5, Fcb5, I_output);
        }

        private void BatteryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            P850SQLController.getBatteryTypeValue(BatteryComboBox.Text.ToString(), F_Battery);
        }


        //Battery groupbox 
        private void Tbat_TextChanged(object sender, EventArgs e)
        {
            P850Controller.InputVerification(T_Battery);
            //Ib Calculs
            //P850Controller.IbCalculs(I_battery, Ah_Battery, T_Battery, KW_Output, inv_efficiency, F_Battery, Vdc_min);
            P850Controller.IbChLogic(VdcComboBox, T_Battery, KW_Output, DCLoad, Ah_Battery, F_Battery, IbchNew, IbchStart);
        }



        private void Ahb_TextChanged(object sender, EventArgs e)
        {
            P850Controller.InputVerification(Ah_Battery);
            //Ib Calculs
            //P850Controller.IbCalculs(I_battery, Ah_Battery, T_Battery, KW_Output, inv_efficiency, F_Battery, Vdc_min);
            P850Controller.IbChLogic(VdcComboBox, T_Battery, KW_Output, DCLoad, Ah_Battery, F_Battery, IbchNew, IbchStart);
        }

        private async void kAb_TextChanged(object sender, EventArgs e)
        {
            P850Controller.InputVerification(kA_battery);

            if (!input_Vac.Text.Equals(""))
            {
                String VacLookupValue = P850Controller.VACLookupValue(Double.Parse(input_Vac.Text));
                P850Controller.KAcb3Calculs(KAcb3, kA_battery, Idc_charger, VdcComboBox.Text, Icb3, UpsOrInverterParams);
                P850Controller.KAcb2Calculs(kA_battery, VacLookupValue, Icb1, KAcb2);
                P850Controller.KAcb6Calculs(kA_battery, Idc_charger, KAcb6, VacLookupValue, Icb6);
            }

            //verify if KA is not empty 
            if (kA_battery.Text != "" && input_Vac.Text != "" && IbchNew.Text != "")
            {
                (string, string) resultKa = ("", "");
                resultKa = await P850SQLController.KALookUp(kA_battery.Text, IbchNew.Text, VdcComboBox.Text);
                KAcb2.Text = resultKa.Item2;
            }
        }

        private void F_Battery_TextChanged(object sender, EventArgs e)
        {
            //Ib Calculs
            //P850Controller.IbCalculs(I_battery, Ah_Battery, T_Battery, KW_Output, inv_efficiency, F_Battery, Vdc_min);
            P850Controller.IbChLogic(VdcComboBox, T_Battery, KW_Output, DCLoad, Ah_Battery, F_Battery, IbchNew, IbchStart);
        }

        private void kabp_TextChanged(object sender, EventArgs e)
        {
            P850Controller.InputVerification(kA_bypass_input);
            KaCb4.Text = kA_bypass_input.Text.ToString();
        }

        private async void PHbp_TextChanged(object sender, EventArgs e)
        {
            //P850Controller.InputVerification(PH_bypass_input);

            if (PH_bypass_input.Text != "")
            {
                if (PH_bypass_input.Text == "1" || PH_bypass_input.Text == "3")
                {
                    Pht3.Text = PH_bypass_input.Text.ToString();

                    //calculs
                    P850Controller.KAt3Calculs(KAt3, Kvat3, Vt3s, Pht3);
                    await P850SQLController.getVacValues(V_bypass_input, PH_bypass_input.Text);
                }
                else
                {
                    MessageBox.Show("the phase can only be be 1 or 3");
                    PH_bypass_input.Text = "";
                }
            }
        }

        private void KVAbp_TextChanged(object sender, EventArgs e)
        {
            //dynamic calculs depending on the text change
            P850Controller.KwbpCalculs(KW_bypass_input, KVAbp, Ph_output);
        }

        private async void input_PH1_TextChanged(object sender, EventArgs e)
        {
            P850Controller.InputVerification(input_PH1);
            if (input_PH1.Text != "")
            {
                if (input_PH1.Text.ToString() == "1" || input_PH1.Text.ToString() == "3")
                {
                    PHcb1.Text = input_PH1.Text;
                    PHcb2.Text = input_PH1.Text;

                    //recalculate Vac values if the phase change
                    input_Vac.Items.Clear();
                    await P850SQLController.getVacValues(input_Vac, input_PH1.Text);

                    P850Controller.Icb1Calculs(input_PH1.Text, Fcb1.Text, Idc_charger.Text, Icb1, Vdc_max.Text, Vin, input_I1);
                    P850Controller.ChargerModelGenerate(charger_model, ChargerType, input_PH1, VdcComboBox, Idc_charger);
                }

                else
                {
                    MessageBox.Show("The phase can only be 1 or 3 ");
                    input_PH1.Text = "";
                }

                //update the Fcb1 depending on the phase
                if (Ph_output.Text.ToString() == "3")
                {
                    Fcb1.Text = Fcb1Phase3;
                }
                else
                {
                    Fcb1.Text = Fcb1Phase1;
                }

            }
            else PHcb1.Text = "";
        }

        private async void input_KA1_TextChanged(object sender, EventArgs e)
        {
            // Cancel the previous token if it's still running
            debounceTokenSource?.Cancel();
            debounceTokenSource = new CancellationTokenSource();

            try
            {
                // Wait for 300 milliseconds
                await Task.Delay(300, debounceTokenSource.Token);

                P850Controller.InputVerification(input_KA1);

                if (!string.IsNullOrWhiteSpace(input_KA1.Text) && !input_Vac.Text.Equals(""))
                {
                    String VacLookupValue = P850Controller.VACLookupValue(Double.Parse(input_Vac.Text));
                    P850Controller.KAcb1Calculs(input_KA1, VacLookupValue, Icb1, KAcb1);
                }

            } catch(TaskCanceledException)
            {
                // Ignore cancellation
            }
        }

        private void MBS_groupbox_Enter(object sender, EventArgs e)
        {
            P850xx_MBS mydlg = new P850xx_MBS();
            this.Hide();
            mydlg.ShowDialog();
            this.Visible = true;
        }

        private void It3p_TextChanged(object sender, EventArgs e)
        {
            if (T3_Yes.Checked)
            {
                P850Controller.Icb4T3CheckedCalculs(Icb4, It3p, Fcb4);
                I_bypass_input.Text = It3p.Text;
            }
        }

        private void KWb_TextChanged(object sender, EventArgs e)
        {

        }

        private void Idc_TextChanged(object sender, EventArgs e)
        {

            //lookup Icb6
            string vacLookupValue = "";
            if (!input_Vac.Text.Equals(""))
            {
                vacLookupValue = P850Controller.VACLookupValue(Double.Parse(input_Vac.Text));
            }
            P850Controller.KAcb3Calculs(KAcb3, kA_battery, Idc_charger, VdcComboBox.Text, Icb3, UpsOrInverterParams);
            P850Controller.KAcb6Calculs(kA_battery, Idc_charger, KAcb6, vacLookupValue, Icb6);
            P850Controller.ChargerModelGenerate(charger_model, ChargerType, input_PH1, VdcComboBox, Idc_charger);
            //Icb2 
            P850Controller.Icb2Calculs(Fcb2.Text, Idc_charger.Text, Icb2);
            //Icb1
            P850Controller.Icb1Calculs(input_PH1.Text, Fcb1.Text, Idc_charger.Text, Icb1, Vdc_max.Text, Vin, input_I1);
            //Icb3
            P850Controller.Icb3Calculs(Idc_charger, Idc_inverter, Icb3, UpsOrInverterParams);
        }

        private void Bypass_input_no_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (Bypass_input_no_checkbox.Checked)
            {
                Bypass_input_yes_checkbox.Checked = false;
            }
            else
            {
                Bypass_input_yes_checkbox.Checked = true;
                Cb4_groupbox.Visible = true;
                Bypass_input_groupbox.Visible = true;
                groupBox23.Visible = true;
                CB7_groupbox.Visible = true;
                T3_groupbox.Visible = true;
                T3_groupbox2.Visible = true;
                MBS_groupbox.Visible = true;
                T3_yes_no_groupbox.Visible = true;
            }
        }

        private void Bypass_input_yes_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (Bypass_input_yes_checkbox.Checked)
            {
                Bypass_input_no_checkbox.Checked = false;
            }
            else
            {
                Bypass_input_no_checkbox.Checked = true;
                Cb4_groupbox.Visible = false;
                Bypass_input_groupbox.Visible = false;
                groupBox23.Visible = false;
                CB7_groupbox.Visible = false;
                T3_groupbox.Visible = false;
                T3_groupbox2.Visible = false;
                MBS_groupbox.Visible = false;
                T3_yes_no_groupbox.Visible = false;
            }
        }

        private void Idc_inverter_TextChanged(object sender, EventArgs e)
        {
            P850Controller.IdcChargerCalculs(Idc_charger, Idc_inverter, IbchNew, DCLoad);
            P850Controller.IdcInverterCalculs(Idc_inverter, KW_Output, Vdc_min, inv_efficiency);

            P850Controller.Icb6Calculs(Idc_inverter, Icb6, Fcb6);

            P850Controller.Icb3Calculs(Idc_charger, Idc_inverter, Icb3, UpsOrInverterParams);
        }

        private void I_battery_TextChanged(object sender, EventArgs e)
        {
            P850Controller.IdcChargerCalculs(Idc_charger, Idc_inverter, IbchNew, DCLoad);
        }


        private void quantity_textbox_TextChanged(object sender, EventArgs e)
        {
            P850Controller.ChargerTotalPrice(UnitCost_textbox, quantity_textbox, total_textbox);
        }

        private void ChargerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            P850Controller.ChargerModelGenerate(charger_model, ChargerType, input_PH1, VdcComboBox, Idc_charger);
        }

        private void save_input_Click(object sender, EventArgs e)
        {
            // delete user old progress before s
            int deleteResult1 = P850SQLController.deleteOlddUserProgress("P850_OutputGroupbox_save", P850quoteId);
            int deleteResult2 = P850SQLController.deleteOlddUserProgress("P850_BatteryGroupbox_Save", P850quoteId);
            int deleteResult3 = P850SQLController.deleteOlddUserProgress("P850_InputGroupbox_Save", P850quoteId);
            int deleteResult4 = P850SQLController.deleteOlddUserProgress("P850_BypassInputGroupbox_Save", P850quoteId);
            int deleteResult5 = P850SQLController.deleteOlddUserProgress("Other_Inputs_Save", P850quoteId);

            Char inverterOrUPS = radioButtonUPS.Checked ? 'u' : 'i';

            int result1;
            int result2;
            int result3;
            int result4;
            int result5;
            result1 = P850SQLController.saveUserProgressOutputGroupbox(P850quoteId, V_output.Text, Ph_output.Text, KVA_output.Text, PF_output.Text);
            result2 = P850SQLController.saveUserProgressBatteryGroupbox(P850quoteId, T_Battery.Text, Ah_Battery.Text, kA_battery.Text);
            result3 = P850SQLController.saveUserProgressBypassInputGroupbox(P850quoteId, V_bypass_input.Text, kA_bypass_input.Text, PH_bypass_input.Text);
            result4 = P850SQLController.saveUserProgressInputGroupbox(P850quoteId, input_Vac.Text, input_PH1.Text, input_KA1.Text, VdcComboBox.Text);
            result5 = P850SQLController.saveUserProgressOtherInputs(P850quoteId, inverterOrUPS, PF_output.Text, F_output.Text, F_bypass_input.Text, F_Battery.Text);

            if (result1 == 1 && result2 == 1 && result3 == 1 && result4 == 1 && result5 == 1)
            {
                MessageBox.Show("progression saved successfully");
            }
            else
            {
                MessageBox.Show("An error has occured, please try again!");
            }

        }


        //clear the form and reinitialize the default values
        private async void clear_button_Click(object sender, EventArgs e)
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is System.Windows.Forms.TextBox)
                        (control as System.Windows.Forms.TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);

            //reinitialize
            await GetFactorDefaultValues();
            Dictionary<string, Control> modelDefaultValueControls = CreateControlDictionary(P850Model, Ph_output, KVA_output, V_output, VdcComboBox, V_Inverter);
            await P850SQLController.getModelDefaultValues(modelDefaultValueControls, UpsOrInverterParams);

            await P850SQLController.getBatteries(BatteryComboBox);
            await P850SQLController.getVdcValues(VdcComboBox);

            await P850SQLController.getVacValues(input_Vac, "3"); //default phase to 3
           input_Vac.SelectedIndex = 7; //put the default value to 480  
            await P850SQLController.getVacValues(V_bypass_input, "1"); //default phase to 1
            V_bypass_input.SelectedIndex = 1; //put the default value to 120
            await P850SQLController.getVacValues(V_output, "1"); //default phase to 1
            V_output.SelectedIndex = 1; //put the default value to 120

            await P850SQLController.getModelDefaultValues(modelDefaultValueControls, UpsOrInverterParams);



            //initiliaze the charger type to P4600
            ChargerType.Text = ChargerType.Items[0].ToString();


            //Fb textbox
            P850SQLController.getBatteryTypeValue(BatteryComboBox.Text.ToString(), F_Battery);
            //It3s Textbox initialization -- testing purpose
            It3p.Text = "3";
            V_bypass_input.Text = V_bypass_input.Text;

            //PHcb5 && PHcb5 default value
            PHcb5.Text = "1";
            PHcb6.Text = "1";

        }

        private void Vin_TextChanged(object sender, EventArgs e)
        {
            P850Controller.InputVerification(Vin);
            P850Controller.Icb1Calculs(input_PH1.Text, Fcb1.Text, Idc_charger.Text, Icb1, Vdc_max.Text, Vin, input_I1);
        }

        private void Kvat3_TextChanged(object sender, EventArgs e)
        {
            P850Controller.It3pCalculs(Kvat3, Vt3p, It3p, Ph_output, Ft3);
            P850Controller.KAt3Calculs(KAt3, Kvat3, Vt3s, Pht3);
            P850Controller.Kwt3Calculs(Kvat3, PF_bypass_input, KWt3);
            P850Controller.It3sCalculs(Kvat3, Vt3s, It3s, Ph_output);
        }

        private void Vt3p_TextChanged(object sender, EventArgs e)
        {
            P850Controller.It3pCalculs(Kvat3, Vt3p, It3p, Ph_output, Ft3);
        }

        private async void VdcComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            P850SQLController.getVdcMaxAndVdcMin(VdcComboBox, Vdc_max, Vdc_min, cellNumber);
            P850Controller.IdcChargerCalculs(Idc_charger, Idc_inverter, IbchNew, DCLoad);
            P850Controller.IbChLogic(VdcComboBox, T_Battery, KW_Output, DCLoad, Ah_Battery, F_Battery, IbchNew, IbchStart);

            (string, string)resultKa = await P850SQLController.KALookUp(KAcb3.Text, Icb3.Text, VdcComboBox.Text);
            KAcb3.Text = resultKa.Item2;

            GetModelOnTextChange();
            P850Controller.ChargerModelGenerate(charger_model, ChargerType, input_PH1, VdcComboBox, Idc_charger);

            var VdcList = new List<string> { "80", "125", "130", "250", "500", "600" };
            //Vcb2 = Vdc_charger 
            for (int i = 0; i < VdcList.Count; i++)
            {
                if (Double.Parse(VdcList[i]) >= Double.Parse(VdcComboBox.Text))
                {
                    Vcb2.Text = VdcList[i];
                    Vcb6.Text = VdcList[i];
                    Vcb3.Text = VdcList[i];
                    break;
                }
            }

            V_Inverter.Text = VdcComboBox.Text;

        }

        private void Vt3s_TextChanged(object sender, EventArgs e)
        {
            P850Controller.It3sCalculs(Kvat3, Vt3s, It3s, Ph_output);
        }

        private void Icb1_TextChanged(object sender, EventArgs e)
        {
            string vacLookupValue = string.Empty;
            if (!input_Vac.Text.Equals(""))
            {
                vacLookupValue = P850Controller.VACLookupValue(Double.Parse(input_Vac.Text));
                P850Controller.KAcb1Calculs(input_KA1, vacLookupValue, Icb1, KAcb1);
                P850Controller.KAcb2Calculs(kA_battery, vacLookupValue, Icb1, KAcb2);
                P850Controller.KAcb5Calculs(KaCb4, vacLookupValue, Icb1, KAcb5);
            }
        }

        private void Fcb5_TextChanged(object sender, EventArgs e)
        {
            P850Controller.InputVerification(Fcb5);
            //Icb5 lookup
            P850Controller.Icb5Calculs(Icb5, Fcb5, I_output);
        }

        private void Kacb4_TextChanged(object sender, EventArgs e)
        {
            if (!input_Vac.Text.Equals(""))
            {
                String VacLookupValue = P850Controller.VACLookupValue(Double.Parse(input_Vac.Text));
                P850Controller.KAcb5Calculs(KaCb4, VacLookupValue, Icb1, KAcb5);
            }
        }

        private void CB5_No_CheckedChanged(object sender, EventArgs e)
        {
            if (CB5_No.Checked)
            {
                CB5_Yes.Checked = false;
                Cb5_groupbox.Hide();
                CB5_groupbox2.Hide();
                CB5_No.Checked = true;
            }
            else
            {
                CB5_Yes.Checked = true;
                Cb5_groupbox.Show();
                CB5_groupbox2.Show();
                CB5_No.Checked = false;
            }
        }

        private void CB5_Yes_CheckedChanged(object sender, EventArgs e)
        {
            if (CB5_Yes.Checked)
            {
                CB5_No.Checked = false;
                Cb5_groupbox.Visible = true;
                CB5_groupbox2.Visible = true;
            }
            else
            {
                CB5_Yes.Checked = false;
                Cb5_groupbox.Hide();
                CB5_groupbox2.Hide();
                CB5_No.Checked = true;
            }
        }

        private void CB7_No_CheckedChanged(object sender, EventArgs e)
        {
            if (CB7_No.Checked)
            {
                CB7_Yes.Checked = false;
                CB7_groupbox.Visible = false;
                CB7_groupbox2.Visible = false;
            }
            else
            {
                CB7_Yes.Checked = true;
                CB7_No.Checked = false;
                CB7_groupbox.Visible = true;
            }
        }

        private void CB7_Yes_CheckedChanged(object sender, EventArgs e)
        {
            if (CB7_Yes.Checked)
            {
                CB7_No.Checked = false;
                CB7_groupbox.Visible = true;
                CB7_groupbox2.Visible = true;
            }
            else
            {
                CB7_Yes.Checked = false;
                CB7_No.Checked = true;
                CB7_groupbox.Visible = false;
            }
        }

        private void CB6_No_CheckedChanged(object sender, EventArgs e)
        {
            if (CB6_No.Checked)
            {
                CB6_Yes.Checked = false;
                CB6_groupbox.Hide();
                CB6_groupbox2.Hide();
            }
            else
            {
                CB6_Yes.Checked = true;
                CB6_No.Checked = false;
                CB6_groupbox.Show();
                CB6_groupbox2.Show();
            }
        }

        private void CB6_Yes_CheckedChanged(object sender, EventArgs e)
        {
            if (CB6_Yes.Checked)
            {
                CB6_No.Checked = false;
                CB6_groupbox.Show();
                CB6_groupbox2.Show();
            }
            else
            {
                CB6_Yes.Checked = false;
                CB6_No.Checked = true;
                CB6_groupbox.Hide();
                CB6_groupbox2.Hide();
            }
        }

        private void DCLoad_TextChanged(object sender, EventArgs e)
        {
            P850Controller.InputVerification(DCLoad);
            P850Controller.IdcChargerCalculs(Idc_charger, Idc_inverter, IbchNew, DCLoad);
            P850Controller.IbChLogic(VdcComboBox, T_Battery, KW_Output, DCLoad, Ah_Battery, F_Battery, IbchNew, IbchStart);
        }

        private void V_output_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!V_output.Text.Equals(""))
            {
                String VacLookupValue = P850Controller.VACLookupValue(Double.Parse(input_Vac.Text));
                //P850Controller.Kacb7Calculs(KAcb7, KVA_output, V_output, VacLookupValue, Icb7);
                var controls = CreateControlDictionary(Kacb7, KVA_output, V_output, Icb7);
                P850Controller.Kacb7Calculs(controls, VacLookupValue);
            }

            P850Controller.KAt3Calculs(KAt3, Kvat3, Vt3s, Pht3);

            GetModelOnTextChange();

            //text with the same value as Vo
            Vt3s.Text = V_output.Text.ToString();
            Vcb7.Text = V_output.Text.ToString();
            Vcb5.Text = V_output.Text.ToString();

            //if V_bypass_input is different than V_output  T3 no checkbox is disabled
            var t3Controls = CreateControlDictionary(V_bypass_input, V_output, T3_No, T3_Yes);
            P850Controller.T3CheckboxEnabler(t3Controls);


            //
            if (KVA_output.Text != "" && Ph_output.Text != "")
            {
                var controls = CreateControlDictionary(KVA_output, V_output, Ph_output, I_output, Icb7, Fcb7);
                P850Controller.I9OutputCalculs(controls);
            }
        }

        private void Vbp_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if V_bypass_input is different than V_output  T3 no checkbox is disabled
            var controls = CreateControlDictionary(V_bypass_input, V_output, T3_No, T3_Yes);
            P850Controller.T3CheckboxEnabler(controls);

            //input that have the same values as Vbp (V_bypass_input)
            Vt3p.Text = V_bypass_input.Text.ToString();
            Vcb4.Text = V_bypass_input.Text.ToString();
        }

        private void Fcb4_TextChanged(object sender, EventArgs e)
        {
            if (T3_No.Checked)
            {
                P850Controller.Icb4T3UncheckedCalculs(Icb4, It3p, Fcb4);
            }
            else
            {
                P850Controller.Icb4T3CheckedCalculs(Icb4, It3p, Fcb4);
            }

        }

        private void Icb3_TextChanged(object sender, EventArgs e)
        {
            if (!input_Vac.Text.Equals(""))
            {
                String VacLookupValue = P850Controller.VACLookupValue(Double.Parse(input_Vac.Text));
                P850Controller.KAcb3Calculs(KAcb3, kA_battery, Idc_charger, VdcComboBox.Text, Icb3, UpsOrInverterParams);
            }
        }

        private void Icb7_TextChanged(object sender, EventArgs e)
        {
            if (!input_Vac.Text.Equals(""))
            {
                String VacLookupValue = P850Controller.VACLookupValue(Double.Parse(input_Vac.Text));
                var controls = CreateControlDictionary(Kacb7, KVA_output, V_output, Icb7);
                P850Controller.Kacb7Calculs(controls, VacLookupValue);
            }
        }

        private async void radioButtonInverter_CheckedChanged(object sender, EventArgs e)
        {
            charger_model.Hide(); label8.Hide(); charger_groupbox1.Hide(); charger_groupbox.Text = "Input"; 
            idcLabel.Hide(); Idc_charger.Hide();
            battery_groupbox.Hide(); Cb3_groupbox.Hide(); Cb3.Hide(); battery_grpbox_red.Hide(); groupBox20.Hide();
            Cb1_groupbox.Hide(); line1.Hide(); groupBox11.Hide(); groupBox24.Hide();
            Cb2_groupbox.Hide(); CB2.Hide(); Cb2_Yes.Hide(); Cb2_No.Hide(); CB6_Yes.Hide(); CB6_No.Hide();
            Vin.Hide(); DCLoad.Hide(); Vin_label.Hide(); DcLoad_label.Hide(); input_groupbox.Hide();
            chargerType_groupbox.Hide();
            line1.Show();

            PHcb3.Text = "1";
            KAcb3.Text = "1";

            //change the state as an Inverter
            Char inverterOrUPS = radioButtonUPS.Checked ? 'u' : 'i';
            UpsOrInverterParams = inverterOrUPS;

            //reload the default values for the model
            Dictionary<string, Control> modelDefaultValueControls = CreateControlDictionary(P850Model, Ph_output, KVA_output, V_output, VdcComboBox, V_Inverter);
            await P850SQLController.getModelDefaultValues(modelDefaultValueControls, UpsOrInverterParams);
        }

        private async void radioButtonUPS_CheckedChanged(object sender, EventArgs e)
        {
            charger_model.Show(); label8.Show(); charger_groupbox1.Show(); charger_groupbox.Show();
            Cb1_groupbox.Show(); line1.Show(); groupBox11.Show(); groupBox24.Show();
            Cb2_groupbox.Show(); CB2.Show(); Cb2_Yes.Show(); Cb2_No.Show();
            Cb3_groupbox.Show(); Cb3.Show();
            CB6_Yes.Show(); CB6_No.Show();
            Vin.Show(); DCLoad.Show(); Vin_label.Show(); DcLoad_label.Show(); input_groupbox.Show();
            chargerType_groupbox.Show();
            battery_grpbox_red.Show(); battery_groupbox.Show(); 

            //change the state as an Inverter
            Char inverterOrUPS = radioButtonUPS.Checked ? 'u' : 'i';
            UpsOrInverterParams = inverterOrUPS;

            ////reload the default values for the model
            Dictionary<string, Control> modelDefaultValueControls = CreateControlDictionary(P850Model, Ph_output, KVA_output, V_output, VdcComboBox, V_Inverter);
            await P850SQLController.getModelDefaultValues(modelDefaultValueControls, UpsOrInverterParams);
        }

        private void Cb2_Yes_CheckedChanged(object sender, EventArgs e)
        {
            if (Cb2_Yes.Checked)
            {
                Cb2_No.Checked = false;
                Cb2_Yes.Checked = true;
                Cb2_groupbox.Show();
                CB2.Show();
            }
            else
            {
                Cb2_No.Checked = true;
                Cb2_Yes.Checked = false;
                Cb2_groupbox.Hide();
                CB2.Hide();
            }
        }

        private void Cb2_No_CheckedChanged(object sender, EventArgs e)
        {
            if (Cb2_No.Checked)
            {
                Cb2_Yes.Checked = false;
                Cb2_groupbox.Hide();
            }
            else
            {
                Cb2_Yes.Checked = true;
                Cb2_No.Checked = false;
                Cb2_groupbox.Show();
            }
        }

        private void MBS_Yes_CheckedChanged(object sender, EventArgs e)
        {
            if (MBS_Yes.Checked)
            {
                MBS_No.Checked = false;
                T3_groupbox.Show();
                Cb4_groupbox.Show();
                Bypass_input_groupbox.Show();
            } 
        }

        private void MBS_No_CheckedChanged(object sender, EventArgs e)
        {
            if (MBS_No.Checked)
            {
                MBS_Yes.Checked = false;
                T3_groupbox.Hide();
                Cb4_groupbox.Hide();
                Bypass_input_groupbox.Hide();
            }
        }

        private void Vdc_min_TextChanged(object sender, EventArgs e)
        {
            P850Controller.IdcInverterCalculs(Idc_inverter, KW_Output, Vdc_min, inv_efficiency);
        }

        private void Ft3_TextChanged(object sender, EventArgs e)
        {
            P850Controller.It3pCalculs(Kvat3, Vt3p, It3p, Ph_output, Ft3);
            P850Controller.KVAt3Calculs(KVA_output, Kvat3, Ft3);
        }

        private void Fcb7_TextChanged(object sender, EventArgs e)
        {
            var controls = CreateControlDictionary(KVA_output, V_output, Ph_output, I_output, Icb7, Fcb7);
            P850Controller.I9OutputCalculs(controls);
        }

        private void Fcb1_TextChanged(object sender, EventArgs e)
        {
            P850Controller.InputVerification(Fcb1);
            P850Controller.Icb1Calculs(input_PH1.Text, Fcb1.Text, Idc_charger.Text, Icb1, Vdc_max.Text, Vin, input_I1);
        }

        private void Fcb2_TextChanged(object sender, EventArgs e)
        {
            P850Controller.InputVerification(Fcb2);
            P850Controller.Icb2Calculs(Fcb2.Text, Idc_charger.Text, Icb2);
        }

        private void Fcb6_TextChanged(object sender, EventArgs e)
        {
            P850Controller.InputVerification(Fcb6);
            P850Controller.Icb6Calculs(Idc_inverter, Icb6, Fcb6);
        }

        private void Fcb3_TextChanged(object sender, EventArgs e)
        {
            P850Controller.InputVerification(Fcb3);
            P850Controller.Icb3Calculs(Idc_charger, Idc_inverter, Icb3, UpsOrInverterParams);
        }

        private void F_bypass_input_TextChanged(object sender, EventArgs e)
        {
            P850Controller.InputVerification(F_bypass_input);
            P850Controller.Kwt3Calculs(Kvat3, PF_bypass_input, KWt3);
        }

        private void F_output_TextChanged(object sender, EventArgs e)
        {
            //any logic that refers to the F_output
        }

        private void input_Vac_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (input_Vac.Text != "")
            {
                String VacLookupValue = P850Controller.VACLookupValue(Double.Parse(input_Vac.Text));
                P850Controller.KAcb1Calculs(input_KA1, VacLookupValue, Icb1, KAcb1);
                P850Controller.KAcb2Calculs(kA_battery, VacLookupValue, Icb1, KAcb2);
                P850Controller.KAcb5Calculs(KaCb4, VacLookupValue, Icb1, KAcb5);

                //Kacb7 ??
                var controls = CreateControlDictionary(Kacb7, KVA_output, V_output, Icb7);
                P850Controller.Kacb7Calculs(controls, VacLookupValue);

                //Vcb1 && Vin = VAC
                Vin.Text = input_Vac.Text;
                Vcb1.Text = input_Vac.Text;
            }
        }

    }
}

