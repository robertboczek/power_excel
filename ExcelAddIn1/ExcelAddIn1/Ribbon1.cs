using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

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
