using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using GraphCaller;
using System.Net;
using Microsoft.Office.Interop.Excel;
using System.Drawing;

namespace ExcelAddIn1
{
    
    public partial class Ribbon1
    {
        private string token = "";
        private long account = 299668039;
        private const int StartingRow = 2;  // 1 for header

        private AdgroupResults adgroupResults;

        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
            // remove proxy - a great slowness source
            WebRequest.DefaultWebProxy = null;
            
        }

        private void setStatusFormatCondition (Range range) {
            Dictionary<string,Color> status_to_color = new Dictionary<string,Color>(){
                {"ACTIVE", Color.DarkGreen},
                {"PAUSED", Color.DarkGray},
                {"PENDING_REVIEW", Color.DarkMagenta},
                {"CAMPAIGN_PAUSED", Color.Gray},
                {"DISAPPROVED", Color.DarkSalmon},
                {"CAMPAIGN_GROUP_PAUSED", Color.LightGray},
            };

            Dictionary<string, Color> status_to_color_background = new Dictionary<string, Color>(){
                {"ACTIVE", Color.LightGreen},
                {"PAUSED", Color.WhiteSmoke},
                {"PENDING_REVIEW", Color.LightGray},
                {"CAMPAIGN_PAUSED", Color.WhiteSmoke},
                {"DISAPPROVED", Color.LightPink},
                {"CAMPAIGN_GROUP_PAUSED", Color.WhiteSmoke},
            };
            foreach( var kvp in status_to_color) {
                var paused_cond = range.FormatConditions.Add(
                    XlFormatConditionType.xlCellValue,
                    XlFormatConditionOperator.xlEqual, 
                    kvp.Key);
                paused_cond.Font.Color = System.Drawing.ColorTranslator.ToOle(kvp.Value);
                if (status_to_color_background.ContainsKey(kvp.Key)) { 
                     paused_cond.Interior.Color
                         = System.Drawing.ColorTranslator.ToOle(status_to_color_background[kvp.Key]);
                }
            }
        }

        private void syncButton_Click(object sender, RibbonControlEventArgs e)
        {
            Excel.Window window = e.Control.Context;
            Excel.Worksheet activeWorksheet = ((Excel.Worksheet)window.Application.ActiveSheet);
            string account = this.accountNoEdit.Text;
            for (int i = 0; i < adgroupResults.Adgroups.Count; i++)
            {
                int row = Ribbon1.StartingRow + i;
                Dictionary<string, object> changes = new Dictionary<string, object>();
                char col = 'A';
                HashSet<string> fields = adgroupResults.Fields;
                 string adgroupId = "";
                if (fields.Contains("id")) {
                    Excel.Range cell = activeWorksheet.get_Range(col.ToString() + row);
                  if (cell.Value2 is Double) {
                    adgroupId = cell.Value2.ToString();
                  }
                  col++;
                }

                if (fields.Contains("name")) {
                  Excel.Range cell = activeWorksheet.get_Range(col.ToString() + row);
                  changes.Add("name", cell.Value2);
                  col++;
                }

                if (fields.Contains("adgroup_status")) {
                  Excel.Range cell = activeWorksheet.get_Range(col.ToString() + row);
                  changes.Add("adgroup_status", cell.Value2);
                  col++;
                }
                if (!adgroupId.Equals(""))
                {
                    Uploader.Edit(adgroupId, token, changes);
                }
            }
            MessageBox.Show("Data successfully synced!");
        }

        private async void loadButton_Click(object sender, RibbonControlEventArgs e)
        {
            GetAdgroups(out adgroupResults);
            List<AdGroups> adgroups = adgroupResults.Adgroups;
            HashSet<string> fields = adgroupResults.Fields;

            Excel.Window window = e.Control.Context;
            Excel.Worksheet activeWorksheet = ((Excel.Worksheet)window.Application.ActiveSheet);
            
            // Add header
            if (Ribbon1.StartingRow > 1) { 
                char col = 'A';
                var headerRow = (Ribbon1.StartingRow - 1).ToString();
                foreach (var f in new List<string>() { "id", "name", "adgroup_status", "account_id" })
                {
                    if (fields.Contains(f)) {
                        Excel.Range headerColumn = activeWorksheet.get_Range(col.ToString() + headerRow);
                        headerColumn.Value2 = f;
                        col++;
                    }
                }
            }
            
            int i = Ribbon1.StartingRow;
            string adgroupStatusRangeStart = "";
            string adgroupStatusRangeEnd = "";
            foreach (var adgroup in adgroups)
            {
                char col = 'A';
                if (fields.Contains("id")) {
                  string column = col.ToString() + i;
                  Excel.Range adgroupId = activeWorksheet.get_Range(column);
                  adgroupId.Value2 = adgroup.AdgroupId;
                  // set style, no commas
                  activeWorksheet.Range[column].NumberFormat = "0"; 
                  col++;
                }

                if (fields.Contains("name")) {
                  string column = col.ToString() + i;
                  Excel.Range adgroupName = activeWorksheet.get_Range(column);
                  adgroupName.Value2 = adgroup.AdgroupName;
                  col++;
                }

                if (fields.Contains("adgroup_status"))
                {
                  string column = col.ToString() + i;
                  if (i == 1) {
                    adgroupStatusRangeStart = column;
                  }
                  Excel.Range adgroupStatus = activeWorksheet.get_Range(column);
                  adgroupStatus.Value2 = adgroup.Status;
                  this.setStatusFormatCondition(adgroupStatus);
                  col++;
                  adgroupStatusRangeEnd = column;
                }
                 
                if (fields.Contains("account_id")) {
                  string column = col.ToString() + i;
                  Excel.Range adgroupAccount = activeWorksheet.get_Range(column);
                  adgroupAccount.Value2 = adgroup.AdgroupAccontID;
                  col++;
                }
                i++;
            }

            var client = new ServiceReference1.Service1Client();
            FBAdAccount accountDetails = await client.GetAdAccountAsync(token, account);

            Excel.Range accountIdDesc = activeWorksheet.get_Range("L1");
            accountIdDesc.Value2 = "Account ID";
            Excel.Range accountId = activeWorksheet.get_Range("M1");
            accountId.Value2 = accountDetails.AccountId;

            Excel.Range accountdStatusDesc = activeWorksheet.get_Range("L2");
            accountdStatusDesc.Value2 = "Account Status";
            Excel.Range accountStatus = activeWorksheet.get_Range("M2");
            accountStatus.Value2 = accountDetails.AccountStatus;

            Excel.Range ageDesc = activeWorksheet.get_Range("L3");
            ageDesc.Value2 = "Age";
            Excel.Range age = activeWorksheet.get_Range("M3");
            age.Value2 = accountDetails.Age;

            Excel.Range currencyDesc = activeWorksheet.get_Range("L4");
            currencyDesc.Value2 = "Currency";
            Excel.Range currency = activeWorksheet.get_Range("M4");
            currency.Value2 = accountDetails.Currency;

            Excel.Range nameDesc = activeWorksheet.get_Range("L5");
            nameDesc.Value2 = "Name";
            Excel.Range name = activeWorksheet.get_Range("M5");
            name.Value2 = accountDetails.Name;

            Excel.Range businessCityDesc = activeWorksheet.get_Range("L6");
            businessCityDesc.Value2 = "Business City";
            Excel.Range businessCity = activeWorksheet.get_Range("M6");
            businessCity.Value2 = accountDetails.BusinessCity;

            Excel.Range spendCapDesc = activeWorksheet.get_Range("L7");
            spendCapDesc.Value2 = "Spend Cap";
            Excel.Range spendCap = activeWorksheet.get_Range("M7");
            spendCap.Value2 = accountDetails.SpendCap;
        }

        private void GetAdgroups(out AdgroupResults adgroupResults)
        {
            adgroupResults = new AdgroupResults();
            List<AdGroups> adgroups = new List<AdGroups>();
            HashSet<string> fields = new HashSet<string>();
            FieldsSelector selector = new FieldsSelector(account, token);
            selector.Text  = "Loading data for account: " + this.accountNoEdit.Text;
            var result = selector.ShowDialog();
            if (result == DialogResult.OK)
            {
                adgroups = FieldsSelector.Adgroups;
                fields = FieldsSelector.selectedFields;
            }
            adgroupResults.Adgroups = adgroups;
            adgroupResults.Fields = fields;
        }

        private void accountNoEdit_TextChanged(object sender, RibbonControlEventArgs e)
        {

        }

    }
}
