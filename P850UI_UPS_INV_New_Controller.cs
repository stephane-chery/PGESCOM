//using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PGESCOM
{
    internal class P850UI_UPS_INV_New_Controller
    {
        P850UI_UPS_INV_New_SQL_Controller P850SQLController = new P850UI_UPS_INV_New_SQL_Controller();
        const double It3Const = 1.732;

        /*
        //I_output calculs 
        public async void I9OutputCalculs(System.Windows.Forms.TextBox KVA_Output, System.Windows.Forms.TextBox V_Output,
            System.Windows.Forms.TextBox Ph_Output, System.Windows.Forms.TextBox I_Output,
            System.Windows.Forms.TextBox Icb7, System.Windows.Forms.TextBox Fcb7)
        {
            if (KVA_Output.Text != "" && V_Output.Text != "" && Ph_Output.Text != "" && Fcb7.Text != "")
            {
                // I_Output = kVA9 / V_Output / sqrt(ph9)
                double i9 = 0;
                i9 = Double.Parse(KVA_Output.Text.ToString()) / Double.Parse(V_Output.Text.ToString()) / Math.Sqrt(Double.Parse(Ph_Output.Text.ToString()));
                double finalResult = i9 * 1000;
                I_Output.Text = Math.Round(finalResult,2).ToString();
                double Icb7Value = Double.Parse(Fcb7.Text) * finalResult;
                double Icb7Lookup = await P850SQLController.IcbLookup(Icb7Value, "1");
                Icb7.Text = Icb7Lookup.ToString();

            }
            else
            {
                I_Output.Text = "";
                Icb7.Text = "";
            }
        }
        */
        public async void I9OutputCalculs(Dictionary<string, Control> controls)
        {
            if (controls["KVA_output"] is System.Windows.Forms.TextBox KVA_Output &&
                controls["V_output"] is System.Windows.Forms.ComboBox V_Output &&
                controls["Ph_output"] is System.Windows.Forms.TextBox Ph_Output &&
                controls["I_output"] is System.Windows.Forms.TextBox I_Output &&
                controls["Icb7"] is System.Windows.Forms.TextBox Icb7 &&
                controls["Fcb7"] is System.Windows.Forms.TextBox Fcb7)
            {
                if (!string.IsNullOrEmpty(KVA_Output.Text) && !string.IsNullOrEmpty(V_Output.Text) &&
                    !string.IsNullOrEmpty(Ph_Output.Text) && !string.IsNullOrEmpty(Fcb7.Text))
                {
                    // I_Output = kVA9 / V_Output / sqrt(ph9)
                    double i9 = 0;
                    i9 = double.Parse(KVA_Output.Text) / double.Parse(V_Output.Text) / Math.Sqrt(double.Parse(Ph_Output.Text));
                    double finalResult = i9 * 1000;
                    I_Output.Text = Math.Round(finalResult, 2).ToString();
                    double Icb7Value = double.Parse(Fcb7.Text) * finalResult;
                    double Icb7Lookup = await P850SQLController.IcbLookup(Icb7Value, "1");
                    Icb7.Text = Icb7Lookup.ToString();
                }
                else
                {
                    I_Output.Text = "";
                    Icb7.Text = "";
                }
            }
        }


        //Kw9 Ouput calculs 
        public void KW9OutputCalculs(System.Windows.Forms.TextBox KVA9, System.Windows.Forms.TextBox PF9, System.Windows.Forms.TextBox KW9)
        {
            if (KVA9.Text != "" && PF9.Text != "")
            {
                double kw9 = 0;
                // KW9 = KVA_Output * PF9
                kw9 = Double.Parse(KVA9.Text.ToString()) * Double.Parse(PF9.Text.ToString());
                KW9.Text = kw9.ToString();
            }
            else
            {
                KW9.Text = "";
            }
        }


        public async void Kacb7Calculs(Dictionary<string, Control> controls, string input_Vac)
        {
            if (controls["Kacb7"] is System.Windows.Forms.TextBox KAcb7 &&
                controls["KVA_output"] is System.Windows.Forms.TextBox KVA_Output &&
                controls["V_output"] is System.Windows.Forms.ComboBox V_Output &&
                controls["Icb7"] is System.Windows.Forms.TextBox Icb7)
            {
                if (!string.IsNullOrEmpty(KVA_Output.Text) &&
                    !string.IsNullOrEmpty(V_Output.Text) &&
                    !string.IsNullOrEmpty(Icb7.Text))
                {
                    double finalResult = Math.Round(double.Parse(KVA_Output.Text) / double.Parse(V_Output.Text), 2);

                    // Prepare the Vac string
                    string Vac = $"{input_Vac}Vac";

                    // Perform async lookup
                    var resulLookup = await P850SQLController.KALookUp(finalResult.ToString(), Icb7.Text, Vac);

                    // Update the KAcb7 textbox
                    KAcb7.Text = resulLookup.Item2;
                }
                else
                {
                    KAcb7.Text = "";
                }
            }
        }


        //verify if a letter or any other character than a number was inserted in a textbox which is supposed to receive a number
        public void InputVerification(System.Windows.Forms.TextBox input)
        {
            if (input.Text.Length == 1)
            {
                if (input.Text == ".")
                {
                    MessageBox.Show("Please insert a number first");
                    input.Text = input.Text.Remove(input.Text.Length - 1);
                }
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(input.Text, "[^0-9.]"))
            {
                MessageBox.Show("Please enter a number.");
                input.Text = input.Text.Remove(input.Text.Length - 1);
            }
        }


        // KWbp calculs
        public void KwbpCalculs(System.Windows.Forms.TextBox Kwbp, System.Windows.Forms.TextBox KVAbp, System.Windows.Forms.TextBox Pho)
        {
            if (KVAbp.Text != "" && Pho.Text != "")
            {
                //Kwbp = KVAbp * Pho
                double finalResult = Double.Parse((KVAbp.Text).ToString()) * Double.Parse(Pho.Text.ToString());
                Kwbp.Text = finalResult.ToString();
            }
            else
            {
                Kwbp.Text = "";
            }
        }


        //generate the right charger model 
        public void ChargerModelGenerate(Label charger_model, ComboBox ChargerType, 
            System.Windows.Forms.TextBox input_Ph1, ComboBox Vdc_charger, System.Windows.Forms.TextBox Idc_charger)
        {
            if (ChargerType.Text.ToString() != "" && input_Ph1.Text.ToString() != "" && Vdc_charger.Text.ToString() != "" && Idc_charger.Text.ToString() != "")
            {
                charger_model.Text = $"{ChargerType.Text}-{input_Ph1.Text}-{Vdc_charger.Text}-{Idc_charger.Text}";
            } else
            {
                charger_model.Text = "";
            }
            
        }

        //calculate the charger price 
        public async Task<String> CalculateChargerPrice(Char UpsOrInverterParams, TextBox KW_Output, ComboBox VdcComboBox, double IbchNew, double IbchStart, TextBox input_PH1, TextBox Idc_charger)
        {

            //Calculate Charger price
            String chargerPrice = "";
            if (UpsOrInverterParams == 'u')
            {
                if (Double.Parse(Idc_charger.Text) <= (Double.Parse(KW_Output.Text) / Double.Parse(VdcComboBox.Text)))
                {
                    chargerPrice = "0";
                    MessageBox.Show("Please upgrade cabinet size");
                }
                else
                {
                    if (IbchNew <= IbchStart * 1.05)
                    {
                        chargerPrice = "0";
                    }

                    // calculate the charger Price if the required conditions have been met.
                    else
                    {
                        Double newIdc = IbchNew - IbchStart;
                        if (input_PH1.Text.Equals("3") && newIdc < 25)
                        {
                            Double newIdcValue = 25;
                            chargerPrice = await P850SQLController.getChargerPrice($"P4500F-{input_PH1.Text}-{VdcComboBox.Text}", newIdcValue.ToString());
                        } else
                        {
                            Double IdcLookup = await P850SQLController.IdcLookup(newIdc);
                            chargerPrice = await P850SQLController.getChargerPrice($"P4500F-{input_PH1.Text}-{VdcComboBox.Text}", IdcLookup.ToString());
                        }
                        

                    }

                    //if we couldn't find a charger for the client
                    if (chargerPrice.Equals(""))
                    {
                        if (Double.Parse(chargerPrice) == -1)
                        {
                            MessageBox.Show("We couldn't find the right charger for this. Try upgrading the phase to 3 or talk to an admin.");
                            chargerPrice = (1000000).ToString();
                        }
                    }

                    if (!chargerPrice.Equals(""))
                    {
                        chargerPrice = Math.Round(Double.Parse(chargerPrice), 2).ToString();
                    }
                    

                }
            }

            return chargerPrice;
        }



        //Kvat3 calculs
        public void KVAt3Calculs(System.Windows.Forms.TextBox KVAo, System.Windows.Forms.TextBox Kvat3, System.Windows.Forms.TextBox Ft3)
        {

            if (!KVAo.Text.Equals("") && !Ft3.Text.Equals(""))
            {

                // Ktva3 = KVAo x Ft3
                double ktva3 = Double.Parse(KVAo.Text.ToString()) * Double.Parse(Ft3.Text);
                Kvat3.Text = ktva3.ToString();

            }
            else
            {
                Kvat3.Text = "";
            }

        }

        //T3 Groupbox. KAt3 cacluls
        public void KAt3Calculs(
            System.Windows.Forms.TextBox KAt3,
            System.Windows.Forms.TextBox KVAt3, //battery groupbox input Ahrem -- Ah_Battery
            System.Windows.Forms.TextBox Vt3s, // Kw_Output
            System.Windows.Forms.TextBox pht3) // inv_efficiency
        {
            // KAt3 = KVAt3/Imp./Vt3s/pht3
            //KVAt3/Imp./Vt3s/SQRT(pht3)
            if (KVAt3.Text.ToString() != "" && Vt3s.Text.ToString() != "" && pht3.Text.ToString() != "")
            {
                double KVAt3Double = Double.Parse(KVAt3.Text.ToString());
                double ImpDouble = 0.05;
                double Vt3sDouble = Double.Parse(Vt3s.Text.ToString());
                int Pht3Int = Int32.Parse(pht3.Text.ToString());

                double finalResult = KVAt3Double / ImpDouble / Vt3sDouble / Math.Sqrt(Pht3Int);
                KAt3.Text = Math.Round(finalResult,2).ToString();
            }
            else
            {
                KAt3.Text = "";
            }
        }

        public void Kwt3Calculs(System.Windows.Forms.TextBox KVAt3, System.Windows.Forms.TextBox PFbp, System.Windows.Forms.TextBox Kwt3)
        {
            if (KVAt3.Text != "" && PFbp.Text != "")
            {
                // KVAt3 x PHbp
                double result = Double.Parse(KVAt3.Text) * Double.Parse(PFbp.Text);
                Kwt3.Text = result.ToString();
            }
            else
            {
                Kwt3.Text = "";
            }
        }

        public void It3sCalculs(System.Windows.Forms.TextBox KVAt3, System.Windows.Forms.TextBox Vt3s, System.Windows.Forms.TextBox It3s, System.Windows.Forms.TextBox PH_outut)
        {
            if (KVAt3.Text != "" && Vt3s.Text != "")
            {
                double result = 0;
                if (PH_outut.Text.Equals("1"))
                {
                    result =( Double.Parse(KVAt3.Text) / Double.Parse(Vt3s.Text)) * 1000  ;
                } else if (PH_outut.Text.Equals("3"))
                {
                    result = Double.Parse(KVAt3.Text) / Double.Parse(Vt3s.Text) / It3Const;
                    result *= 1000;
                }

                It3s.Text = Math.Round(result, 2).ToString();
            }
            else
            {
                It3s.Text = "";
            }
        }

        public void It3pCalculs(System.Windows.Forms.TextBox KVAt3, System.Windows.Forms.TextBox Vt3p, System.Windows.Forms.TextBox It3p, System.Windows.Forms.TextBox PH_output, System.Windows.Forms.TextBox Ft3)
        {
            if (KVAt3.Text != "" && Vt3p.Text != "")
            {
                double result = 0;

                if (PH_output.Text.Equals("1"))
                {
                    result = (Double.Parse(KVAt3.Text) / Double.Parse(Vt3p.Text)) * 1000;
                } else if (PH_output.Text.Equals("3"))
                {
                    result = Double.Parse(KVAt3.Text) / Double.Parse(Vt3p.Text) / It3Const;
                    result *= 1000;
                }

                It3p.Text = Math.Round(result, 2).ToString();
            } else
            {
                It3p.Text = "";
            }
        }


        //Ib calculs 
        public void IbCalculs(
            System.Windows.Forms.TextBox Ib,
            System.Windows.Forms.TextBox Ahrem, //battery groupbox input Ahrem -- Ah_Battery
            System.Windows.Forms.TextBox Trech, //battery groupbox input Trech -- T_Battery
            System.Windows.Forms.TextBox kWo, // Kw_Output
            System.Windows.Forms.TextBox Finv,  // inv_efficiency
            System.Windows.Forms.TextBox Fbat, //F_Battery
            System.Windows.Forms.TextBox VdcMin

            )
        {
            //Ib = max(AHbxFbat/Tbat,kWoxF2inv)

            if (Ahrem.Text != "" && Trech.Text != "" && kWo.Text != "" && Finv.Text != "" && Fbat.Text != "" && !VdcMin.Text.Equals(""))
            {
                //conversion 
                double ahb_double = Double.Parse(Ahrem.Text);
                double trech_double = Double.Parse(Trech.Text);
                double fbat_double = Double.Parse(Fbat.Text);
                double finv_double = Double.Parse(Finv.Text) / 100; //-- /100 because it's a %
                double kwo_double = Double.Parse(kWo.Text);


                //AHbxFbat/Tbat
                double firstResult = ahb_double * fbat_double / trech_double;
                Math.Round(firstResult, 2);

                double secondResult =( kwo_double * 0.15) / Double.Parse(VdcMin.Text);
                secondResult *= 1000;
                Math.Round(secondResult,2);

                double finalResult = Math.Max(firstResult, secondResult);
                Ib.Text = Math.Round(finalResult,2).ToString();
            }
            else
            {
                Ib.Text = "";
            }
        }

        public void IbChLogic(

        ComboBox Vdc, // Vdc (charger)
        System.Windows.Forms.TextBox Trech, //battery groupbox input Trech -- T_Battery
        System.Windows.Forms.TextBox kWo, // Kw_Output
        System.Windows.Forms.TextBox DcLoad,//Idc charger),
        System.Windows.Forms.TextBox Ahrem, //battery groupbox input Ahrem -- Ah_Battery
        System.Windows.Forms.TextBox Fbat, //F_Battery
        System.Windows.Forms.TextBox Ibch,
        System.Windows.Forms.TextBox IbchStart
    )
        {
           // (Double, Double) IbchStartAndNew = (0, 0);

            if (Ahrem.Text != "" && Trech.Text != "" && kWo.Text != "" && DcLoad.Text != "" && Fbat.Text != "" && Vdc.Text != "")
            {
                double ahb_double = Double.Parse(Ahrem.Text);

                //Ibch Start
                Double IbchStartCalculs = 0.15 * Double.Parse(kWo.Text) * 1000 / Double.Parse(Vdc.Text);               
                IbchStart.Text = Math.Round(IbchStartCalculs, 2).ToString();
                //Ibch New 
                Double IbchNew = ahb_double * (Double.Parse(Fbat.Text) / Double.Parse(Trech.Text)) + Double.Parse(DcLoad.Text);


                if ( IbchNew <= IbchStartCalculs)
                {
                    Ibch.Text = Math.Round(IbchStartCalculs, 2).ToString();
                } else
                {
                    Ibch.Text = Math.Round(IbchNew,2).ToString();
                    Double IdcCharger = IbchNew - IbchStartCalculs;
                }
            }

        }

        // Kwb Inverter calculs
        public void KWbInvCalculs(System.Windows.Forms.TextBox KWb, System.Windows.Forms.TextBox KWo, System.Windows.Forms.TextBox EffInv)
        {
            if (KWo.Text.ToString() != "" && EffInv.Text.ToString() != "")
            {
                double effInv = Double.Parse(EffInv.Text.ToString()) / 100;
                double finalResult = Math.Round(Double.Parse(KWo.Text.ToString()) / effInv, 2);
                KWb.Text = finalResult.ToString();
            } else
            {
                KWb.Text = "";
            }
        }

        //IDC Inverter Calculs
        public void IdcInverterCalculs(System.Windows.Forms.TextBox IdcInverter, System.Windows.Forms.TextBox KWb, System.Windows.Forms.TextBox Vdc_min, System.Windows.Forms.TextBox eff_Inv)
        {
            if (!KWb.Text.Equals("") && !Vdc_min.Text.Equals(""))
            {
                double eff_Inv_double = Double.Parse(eff_Inv.Text) / 100;
                //Vdcmin
                double result = Double.Parse(KWb.Text.ToString()) * 1000 / Double.Parse(Vdc_min.Text) / eff_Inv_double;
                IdcInverter.Text = Math.Round(result,2).ToString();
                Console.WriteLine(result);
            } else
            {
                IdcInverter.Text = "";
            }
        }

        //Charger Idc calculs
        public async void IdcChargerCalculs(System.Windows.Forms.TextBox IdcCharger, System.Windows.Forms.TextBox IdcInverter, System.Windows.Forms.TextBox Ib, TextBox DCLoad)
        {
            //ajouter Dc load puis le mettre en vert
            if (IdcInverter.Text.ToString() != "" && Ib.Text.ToString() != "" && DCLoad.Text.ToString() != "")
            {
                double finalResult = Math.Round(Double.Parse(IdcInverter.Text.ToString()) + Double.Parse(Ib.Text.ToString()) + Double.Parse(DCLoad.Text), 2);
                Double IdcLookup = await P850SQLController.IdcLookup(finalResult);
                if (IdcLookup == 0)
                {
                    IdcCharger.Text = finalResult.ToString();
                } else
                {
                    IdcCharger.Text = IdcLookup.ToString();
                }
                
            } else
            {
                IdcCharger.Text = "";
            }
        }

        public async void Icb4T3UncheckedCalculs(
            System.Windows.Forms.TextBox Icb4,
            System.Windows.Forms.TextBox Io,
            System.Windows.Forms.TextBox Fcb4)
        {
            if (Io.Text.ToString() != "" && Fcb4.Text.ToString() != "")
            {
                //faut faire un lookup 
                double finalResult = Double.Parse(Io.Text.ToString()) * Double.Parse(Fcb4.Text.ToString());
                double result = await P850SQLController.IcbLookup(finalResult, "1");

                if (result.ToString() != "")
                {
                    Icb4.Text = Math.Round(result, 0).ToString();
                }
                
            }
        }

        public async void Icb4T3CheckedCalculs(System.Windows.Forms.TextBox Icb4,
            System.Windows.Forms.TextBox It3p,
            System.Windows.Forms.TextBox Fcb4)
        {
            if (It3p.Text.ToString() != "" && Fcb4.Text.ToString() != "")
            {
                //faut faire un lookup 
                double finalResult = Double.Parse(It3p.Text.ToString()) * Double.Parse(Fcb4.Text.ToString());
                double result = await P850SQLController.IcbLookup(finalResult, "1");
                if (result.ToString() != "")
                {
                    Icb4.Text = Math.Round(result, 0).ToString();
                }
                
            }
        }


        //CB3 

        //kacb3 calculs
        public async void KAcb3Calculs(System.Windows.Forms.TextBox KAcb3, System.Windows.Forms.TextBox KAbat, System.Windows.Forms.TextBox Idc,
            String input_Vdc, System.Windows.Forms.TextBox Icb3, Char upsOrInverter)
        {
            if (KAbat.Text.ToString() != "" && Idc.Text.ToString() != "" && Icb3.Text != "")
            {
                string Vdc = $"{input_Vdc}Vdc";

                if (upsOrInverter == 'I')
                {
                    (string, string) resulLookup = ("", "");
     
                    resulLookup = await P850SQLController.KALookUp(KAbat.Text, Icb3.Text, Vdc);

                    KAcb3.Text = resulLookup.Item2;
                } 
                else
                {
                    double calculResult = Math.Max(Double.Parse(KAbat.Text.ToString()), 10 * Double.Parse(Idc.Text) / 1000);
                    double result = Math.Round(calculResult, 2);

                    (string, string) resulLookup = ("", "");

                    resulLookup = await  P850SQLController.KALookUp(result.ToString(), Icb3.Text, Vdc);
                    Console.WriteLine(resulLookup.ToString());

                    if (string.IsNullOrEmpty(resulLookup.Item2))
                    {
                        await Console.Out.WriteLineAsync("Could't find the right KA for the Cb3 groupbox");
                    }
                    else KAcb3.Text = resulLookup.Item2;
                }

            } 
        }

        //Kacb1 calculs
        public async void KAcb1Calculs(System.Windows.Forms.TextBox input_KA1, String input_Vac, System.Windows.Forms.TextBox Icb1, System.Windows.Forms.TextBox KAcb1)
        {
            //verify if KA is not empty 
            if (input_KA1.Text != "" && input_Vac != "" && Icb1.Text != "")
            {
                (string, string) resultKa = ("", "");

                string Vac = $"{input_Vac}Vac";
                resultKa = await P850SQLController.KALookUp(input_KA1.Text, Icb1.Text, Vac);
                if (resultKa.Item2 == "")
                {
                    KAcb1.Text = "N/A";
                }
                KAcb1.Text = resultKa.Item2;
            }
        }


        //KAcb2 Calculs 
        public async void KAcb2Calculs(System.Windows.Forms.TextBox KA_battery, String input_Vac, System.Windows.Forms.TextBox Icb1, System.Windows.Forms.TextBox KAcb2)
        {
            //verify if KA is not empty 
            if (KA_battery.Text != "" && input_Vac != "" && Icb1.Text != "")
            {
                (string, string) resultKa = ("", "");

                string Vac = $"{input_Vac}Vac";
                resultKa = await P850SQLController.KALookUp(KA_battery.Text, Icb1.Text, Vac);
                if (resultKa.Item2 == "")
                {
                    KAcb2.Text = "0";
                }
                KAcb2.Text = resultKa.Item2;
            }
        }

        //KAcb2 Calculs 
        public async void KAcb5Calculs(System.Windows.Forms.TextBox KAcb4, String input_Vac, System.Windows.Forms.TextBox Icb1, System.Windows.Forms.TextBox KAcb5)
        {
            //verify if KA is not empty 
            if (KAcb4.Text != "" && input_Vac != "" && Icb1.Text != "")
            {
                (string, string) resultKa = ("", "");

                string Vac = $"{input_Vac}Vac";
                resultKa = await P850SQLController.KALookUp(KAcb4.Text, Icb1.Text, Vac);
                if (resultKa.Item2 == "")
                {
                    KAcb5.Text = "0";
                }
                KAcb5.Text = resultKa.Item2;
            }
        }

        //KAcb6 Calculs 
        public async void KAcb6Calculs(System.Windows.Forms.TextBox KA_battery, System.Windows.Forms.TextBox Idc_charger, System.Windows.Forms.TextBox KAcb6, 
            String input_Vac, System.Windows.Forms.TextBox Icb6)
        {
            if (KA_battery.Text != "" && Idc_charger.Text != "" && Icb6.Text != "")
            {
                double resultKa = Double.Parse(KA_battery.Text) + (10 * Double.Parse(Idc_charger.Text) / 1000);

                (string, string) resulLookup = ("", "");

                string Vac = $"{input_Vac}Vac";
                resulLookup = await P850SQLController.KALookUp(resultKa.ToString(), Icb6.Text, Vac);
                KAcb6.Text = resulLookup.Item2;
            }
        }

        public void T3CheckboxEnabler(Dictionary<string, Control> controls)
        {
            if (controls["V_bypass_input"] is System.Windows.Forms.ComboBox V_bypass_input &&
                controls["V_output"] is System.Windows.Forms.ComboBox V_output &&
                controls["T3_No"] is System.Windows.Forms.CheckBox T3_No &&
                controls["T3_Yes"] is System.Windows.Forms.CheckBox T3_Yes)
            {
                if (!string.IsNullOrEmpty(V_bypass_input.Text) && !string.IsNullOrEmpty(V_output.Text))
                {
                    // If V_bypass_input is different from V_output, disable T3_No checkbox
                    if (double.Parse(V_bypass_input.Text) != double.Parse(V_output.Text))
                    {
                        T3_No.Enabled = false;
                        T3_No.Checked = false;
                        T3_Yes.Checked = true;
                    }
                    else
                    {
                        T3_No.Enabled = true;
                        T3_No.Checked = true;
                        T3_Yes.Checked = false;
                    }
                }
            }
        }




        //Calculate the total price of the Charger 
        public void ChargerTotalPrice(System.Windows.Forms.TextBox UnitCost_textbox, System.Windows.Forms.TextBox quantity_textbox, System.Windows.Forms.TextBox total_textbox)
        {
            if (quantity_textbox.Text != "" && UnitCost_textbox.Text != "")
            {
                double total = Double.Parse(UnitCost_textbox.Text.ToString()) * Double.Parse(quantity_textbox.Text.ToString());
                total_textbox.Text = total.ToString();
            } 
        }

        public void GetUnitCostAndTotalPrice(System.Windows.Forms.TextBox Ph_output, System.Windows.Forms.Label P850_model, 
            System.Windows.Forms.TextBox UnitCost_textbox, System.Windows.Forms.TextBox quantity_textbox, System.Windows.Forms.TextBox KVA_output, 
            System.Windows.Forms.TextBox total_textbox)
        {
            //get additional info (unit price and total
            if (Ph_output.Text.ToString() == "1")
            {
                if (P850_model.Text.Contains("i"))
                {
                    P850SQLController.getInverterOrUpsPrice(KVA_output, "PSM_CSU_P850i_1", UnitCost_textbox);
                }
                else
                {
                    P850SQLController.getInverterOrUpsPrice(KVA_output, "PSM_CSU_P850u_1", UnitCost_textbox);
                }

                ChargerTotalPrice(UnitCost_textbox, quantity_textbox, total_textbox);
            }
            else
            {
                if (P850_model.Text.Contains("i"))
                {
                    P850SQLController.getInverterOrUpsPrice(KVA_output, "PSM_CSU_P850i_3", UnitCost_textbox);
                }
                else
                {
                    P850SQLController.getInverterOrUpsPrice(KVA_output, "PSM_CSU_P850u_3", UnitCost_textbox);
                }

                ChargerTotalPrice(UnitCost_textbox, quantity_textbox, total_textbox);
            }
        }


        // Cacluls for the charger config

        public double Vsec(String input_Phase, double VdcMax)
        {
            double Vsec = 0.0;
            const double Dvi = 1.12;
            int extraVariable = 0;

            if (input_Phase != "")
            {
                if (VdcMax < 150)
                {
                    extraVariable = 3;
                }

                if (input_Phase == "1")
                {
                    Vsec = 1.1 * VdcMax * Dvi + extraVariable;
                } else
                {
                    Vsec = 0.428 * 1.732 * Dvi * VdcMax + extraVariable;
                }
            }
            return Math.Round(Vsec, 2);
        }

        public double DIsec(String input_Phase)
        {
            double DIsec = 0.0;

            if (input_Phase != "")
            {
                if (input_Phase == "1")
                {
                    DIsec = 1.35;
                } else
                {
                    DIsec = 1.20;
                }
            }

            return DIsec;
        }

        public double Isec(string input_Phase, double DIsec, double Idc)
        {
            double Isec = 0.0;

            if (input_Phase != "")
            {
                if (input_Phase == "1")
                {
                    //Isec = DIsec * Idc * 1.11;
                    Isec = Idc * 1.11;
                } else
                {
                    //Isec = DIsec * Idc * 0.83;
                    Isec = Idc * 0.83;
                }
            }

            return Isec;
        }

        public double T1KVACalculs(String input_Phase, double Isec, double Vsec, double DIsec)
        {
            //If (ph=1, Isec x Vsec,Isec x Vsec x 1.732)
            double result =  0.0;
            double T1KVA;

            if (input_Phase != "")
            {
                if (input_Phase == "1")
                {
                    result = Isec * Vsec * DIsec;
                    result /= 1000;
                }
                else
                {
                    result = Isec * Vsec * 1.732 * DIsec;
                    result /= 1000;
                }
            }

            if (result < 20)
            {
                T1KVA = Math.Ceiling(result) ;
            } else
            {
                T1KVA = Math.Round(result,0);
            }

            return T1KVA;
        }


        public double IinCalculs(string input_phase, double Isec, double Vsec, string Vin)
        {

            //IF(Phi=1, T1KVA/Vin, T1KVA/Vin/1.732)
            double Iin = 0.0;
            Iin = Isec * Vsec / Double.Parse(Vin);
            return Iin;
        }

        //return the VAC value that can be used for the lookup of the KA
        public String VACLookupValue(double VACValue)
        {
            String result = "120";

            try
            {
                if (VACValue > 120 && VACValue <= 240)
                {
                    result = "240";
                }
                if (VACValue > 240 && VACValue <= 400)
                {
                    result = "400";
                }
                if (VACValue > 400 && VACValue <= 480)
                {
                    result = "480";
                }
                if (VACValue > 480 && VACValue <= 600)
                {
                    result = "600";
                }
            } catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            
            return result;  
        }

        public async void Icb1Calculs(string input_phase, string Fcb1, string IdcCharger, 
            System.Windows.Forms.TextBox Icb1, string VdcMax, System.Windows.Forms.TextBox Vin, 
            System.Windows.Forms.TextBox input_I1)
        {
            if (input_phase != "" && Fcb1 != "" && IdcCharger != "" && Vin.Text != "") {

                double VsecValue = Vsec(input_phase, Double.Parse(VdcMax));
                double DIsecValue = DIsec(input_phase);
                double IsecValue = Isec(input_phase, DIsecValue, Double.Parse(IdcCharger));
                double T1KVAValue = T1KVACalculs(input_phase, IsecValue, VsecValue, DIsecValue);
                double IinValue = IinCalculs(input_phase, IsecValue, VsecValue, Vin.Text);

                //input_I1 = Iin 
                //input_I1.Text = Math.Round(IinValue * 1000, 0).ToString();
                input_I1.Text = Math.Round(IinValue, 0).ToString();
                double firstResult = Double.Parse(input_I1.Text) * Double.Parse(Fcb1);

                var InputI = await P850SQLController.IcbLookup(firstResult, input_phase);
                Icb1.Text = InputI.ToString();


            } else
            {
                Icb1.Text = "";
            }

        }

        public async void Icb2Calculs(string Fcb2, string IdcCharger, System.Windows.Forms.TextBox Icb2)
        {
            if (Fcb2 != "" && IdcCharger != "")
            {
                double firstResult = Double.Parse(IdcCharger) * Double.Parse(Fcb2);

                var InputI = await P850SQLController.IcbLookup(firstResult, "1");
                Icb2.Text = InputI.ToString();
            }

        }

        public async void Icb3Calculs(System.Windows.Forms.TextBox Idc_charger, System.Windows.Forms.TextBox I_inverter, System.Windows.Forms.TextBox Icb3, Char UpsOrInverter)
        {
            if (Idc_charger.Text != "" && I_inverter.Text != "")
            {
                if (UpsOrInverter == 'I')
                {
                    var result =await  P850SQLController.IcbLookup(Double.Parse(I_inverter.Text), "1");
                    Icb3.Text = result.ToString();
                }else
                {
                    double Icb3Lookup = Math.Max(Double.Parse(Idc_charger.Text), Double.Parse(I_inverter.Text));
                    var result =await  P850SQLController.IcbLookup(Icb3Lookup, "1");
                    Icb3.Text = result.ToString();
                }

            }
        }

        public async void Icb5Calculs(System.Windows.Forms.TextBox Icb5, System.Windows.Forms.TextBox Fcb5, System.Windows.Forms.TextBox I_output) 
        {
            if (Fcb5.Text != "")
            {
                if (I_output.Text != "" && Fcb5.Text != "")
                {
                    //Icb5 lookup
                    double Icb5Lookup = Double.Parse(I_output.Text) * Double.Parse(Fcb5.Text);
                    var result = await P850SQLController.IcbLookup(Icb5Lookup, "1");
                    Icb5.Text = result.ToString();
                }

            }
        }



        //input verification before validation
        public bool OutputGroupboxVerification(ComboBox V_output, TextBox Ph_output, TextBox KVA_output)
        {
            bool inputVerification = false; 
            if (V_output.Text != "" && Ph_output.Text != "" && KVA_output.Text != "")
            {
                inputVerification = true;
            }

            return inputVerification;
        }

        //input verification before validation
        public bool BypassInputGroupboxVerification(System.Windows.Forms.TextBox kA_bypass_input, System.Windows.Forms.TextBox PH_bypass_input)
        {
            bool inputVerification = false;
            if (kA_bypass_input.Text != "" && PH_bypass_input.Text != "")
            {
                inputVerification = true;
            }

            return inputVerification;
        }


        //input verification before validation
        public bool BatteryGroupboxVerification(System.Windows.Forms.TextBox T_Battery, System.Windows.Forms.TextBox Ah_Battery, System.Windows.Forms.TextBox kA_battery)
        {
            bool inputVerification = false;
            if (T_Battery.Text != "" && Ah_Battery.Text != "" && kA_battery.Text != "")
            {
                inputVerification = true;
            }

            return inputVerification;
        }

        //input verification before validation
        public bool InputGroupboxVerification(System.Windows.Forms.TextBox input_PH1, System.Windows.Forms.TextBox input_KA1)
        {
            bool inputVerification = false;
            if (input_PH1.Text != "" && input_KA1.Text != "")
            {
                inputVerification = true;
            }

            return inputVerification;
        }


        public bool showCBPrice()
        {
            
            bool inputVerification = false;
            return inputVerification;
        }

        public async void Icb6Calculs(TextBox IdcInverter, TextBox Icb6, TextBox Fcb6)
        {
            //Icb 
            if (IdcInverter.Text != "")
            {
                double Icb6Factor = Double.Parse(IdcInverter.Text) * Double.Parse(Fcb6.Text);
                double result = await P850SQLController.IcbLookup(Icb6Factor, "1");
                Icb6.Text = result.ToString();
            }
        }

        /*
         * retourne true ou false si le prix du Vdc peut être 
         * vérifié selon les critères demandées ( Vdc >= 125 ) true 
         * (Vdc < 125 ) false 
         */
        public bool VdcVerification(TextBox Vdc)
        {
            bool result = true; 
            if (!string.IsNullOrEmpty(Vdc.Text))
            {
                double VdcValue = Double.Parse(Vdc.Text);
                if (VdcValue < 125)
                {
                    result = false;
                }

            }
            return result;
        }



    }
}

