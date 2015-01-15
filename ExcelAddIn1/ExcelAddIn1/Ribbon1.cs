using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using GraphCaller;

namespace ExcelAddIn1
{
    public partial class Ribbon1
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
            // id, status, name, time updated
        }

        private void syncButton_Click(object sender, RibbonControlEventArgs e)
        {
            Excel.Window window = e.Control.Context;
            Excel.Worksheet activeWorksheet = ((Excel.Worksheet)window.Application.ActiveSheet);
            string account = this.accountNoEdit.Text;
            for (int i = 1; i <= 1; i++)
            {
                Excel.Range cell = activeWorksheet.get_Range("A" + i);
                string adgroupId = "";
                string token = "CAACZBwbJIzL0BADmeilhdiNMaavvuFCmqK3TzZBZBQbwovFVsMveiCyz2smDQHWjvuoZBht9Qz7C1f64Jzryef6H87CEXY11f3jEKYwUAVYq7KPvwAojMFkhsaByFulqwGPUKqK9oWgfchDsLJFv0DR88oZCddjWe4q2tZCtxVL9ALgaL8Q78U";
                if (cell.Value2 is Double) {
                    adgroupId = cell.Value2.ToString();
                }
                string adgroupName = activeWorksheet.get_Range("B" + i).Value2;
                if (!adgroupId.Equals(""))
                {
                    Uploader.Edit(adgroupId, token,
                      new Dictionary<string, object>() {
                        {"name", adgroupName}}
                    );
                }
            }
            MessageBox.Show("Data successfully synced!");
        }

        private void loadButton_Click(object sender, RibbonControlEventArgs e)
        {
            MessageBox.Show("Loading data for account: " + this.accountNoEdit.Text);
            Excel.Window window = e.Control.Context;
            Excel.Worksheet activeWorksheet = ((Excel.Worksheet)window.Application.ActiveSheet);
            Excel.Range firstRow = activeWorksheet.get_Range("A1");
            firstRow.Value2 = "New text";
            firstRow.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range newFirstRow = activeWorksheet.get_Range("A1");
            newFirstRow.Value2 = "This text was added by using code";
        }

    }
}
