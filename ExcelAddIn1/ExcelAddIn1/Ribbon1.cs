using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;

namespace ExcelAddIn1
{
    public partial class Ribbon1
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void helloButton_Click(object sender, RibbonControlEventArgs e)
        {
            MessageBox.Show("Hello, world of Ads");
        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            MessageBox.Show("Hello, world of Ads, v2");
        }
    }
}
