namespace ExcelAddIn1
{
    partial class Ribbon1 : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon1()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.accountNoEdit = this.Factory.CreateRibbonEditBox();
            this.button1 = this.Factory.CreateRibbonButton();
            this.buttonGroup1 = this.Factory.CreateRibbonButtonGroup();
            this.loadButton = this.Factory.CreateRibbonButton();
            this.syncButton = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.buttonGroup1.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.accountNoEdit);
            this.group1.Items.Add(this.buttonGroup1);
            this.group1.Label = "AdManager";
            this.group1.Name = "group1";
            // 
            // accountNoEdit
            // 
            this.accountNoEdit.Label = "Account number:";
            this.accountNoEdit.Name = "accountNoEdit";
            this.accountNoEdit.Text = null;
            // 
            // button1
            // 
            this.button1.Label = "";
            this.button1.Name = "button1";
            // 
            // buttonGroup1
            // 
            this.buttonGroup1.Items.Add(this.button1);
            this.buttonGroup1.Items.Add(this.loadButton);
            this.buttonGroup1.Items.Add(this.syncButton);
            this.buttonGroup1.Name = "buttonGroup1";
            // 
            // loadButton
            // 
            this.loadButton.Label = "Load";
            this.loadButton.Name = "loadButton";
            this.loadButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.loadButton_Click);
            // 
            // syncButton
            // 
            this.syncButton.Label = "Sync";
            this.syncButton.Name = "syncButton";
            this.syncButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.syncButton_Click);
            // 
            // Ribbon1
            // 
            this.Name = "Ribbon1";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.buttonGroup1.ResumeLayout(false);
            this.buttonGroup1.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox accountNoEdit;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton syncButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButtonGroup buttonGroup1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton loadButton;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon1 Ribbon1
        {
            get { return this.GetRibbon<Ribbon1>(); }
        }
    }
}
