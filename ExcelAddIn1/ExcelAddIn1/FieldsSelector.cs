using GraphCaller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelAddIn1
{
    public partial class FieldsSelector : Form
    {
        public static HashSet<string> selectedFields = AdGroups.defaultFields;

        private string access_token = String.Empty;

        private long account_id = 0;

        public static List<AdGroups> Adgroups { get; private set; }

        public FieldsSelector()
        {
            InitializeComponent();
            foreach(var field in AdGroups.knownFields) {
                var item = new ListViewItem(field);
                item.Selected = FieldsSelector.selectedFields.Contains(field);
                this.listView1.Items.Add(item);
            }
        }

        public FieldsSelector(long account, string token) : this()
        {
            this.access_token = token;
            this.account_id = account;
        }

        private void FieldsSelector_Load(object sender, EventArgs e)
        {

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FieldsSelector.selectedFields = new HashSet<string>(
               this.listView1.SelectedItems.Cast<ListViewItem>().Select(i => i.Text)
            );
            // Load it

            var old_cursor = this.Cursor;
            try
            {
                var fields = FieldsSelector.selectedFields;
                FieldsSelector.Adgroups = AdGroups.getAdGroup(this.access_token, this.account_id, fields);

                this.Cursor = Cursors.WaitCursor;
            }
            finally {
                this.Cursor = old_cursor;
            }
            // close it 
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
