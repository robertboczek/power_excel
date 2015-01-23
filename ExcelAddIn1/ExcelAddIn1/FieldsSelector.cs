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

        private List<ListViewItem> readOnlyFields = new List<ListViewItem>();

        private string access_token = String.Empty;

        private long account_id = 0;

        public static List<AdGroups> Adgroups { get; private set; }

        public FieldsSelector()
        {
            InitializeComponent();
            foreach(var field in AdGroups.knownFields) {
                var item = new ListViewItem(field);
                //item.Selected = FieldsSelector.selectedFields.Contains(field);
                item.Checked = FieldsSelector.selectedFields.Contains(field);
                if(String.Equals(field,"id",StringComparison.InvariantCultureIgnoreCase)) {
                    this.readOnlyFields.Add(item);
                    item.Font = new Font(item.Font, FontStyle.Bold | FontStyle.Italic);
                    item.ForeColor = Color.Gray;
                }
                this.listView1.Items.Add(item);
            }

            // register for the field check events 
            this.listView1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listView1_ItemCheck);
            this.DisableReadOnlyValidation = true;
            
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
               this.listView1.CheckedItems.Cast<ListViewItem>().Select(i => i.Text)
            );
            // Load data
            loadData();

            // close it 
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        public void loadData()
        {
            var old_cursor = this.Cursor;
            try
            {
                var fields = FieldsSelector.selectedFields;
                FieldsSelector.Adgroups = AdGroups.getAdGroup(this.access_token, this.account_id, fields);

                this.Cursor = Cursors.WaitCursor;
            }
            finally
            {
                this.Cursor = old_cursor;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (this.DisableReadOnlyValidation) {
                return; // no checks just pure good looks 
            }
            var item = this.readOnlyFields.FirstOrDefault(i=>i.Index == e.Index);
            if(null!= item){
                MessageBox.Show(
                        "Field "+item.Text+" cannot be changed in the graph query",
                        "Field Read Only:"+ item.Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                e.NewValue = e.CurrentValue;
            }
        }

        public bool DisableReadOnlyValidation { get; set; }

        private void FieldsSelector_Shown(object sender, EventArgs e)
        {
            this.DisableReadOnlyValidation = false;
        }
    }
}
