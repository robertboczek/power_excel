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
            this.excelAdsGroup = this.Factory.CreateRibbonGroup();
            this.accountEditBox = this.Factory.CreateRibbonEditBox();
            this.syncButton = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.excelAdsGroup.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.excelAdsGroup);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // excelAdsGroup
            // 
            this.excelAdsGroup.Items.Add(this.accountEditBox);
            this.excelAdsGroup.Items.Add(this.syncButton);
            this.excelAdsGroup.Label = "AdManager";
            this.excelAdsGroup.Name = "excelAdsGroup";
            // 
            // accountEditBox
            // 
            this.accountEditBox.Label = "Account number:";
            this.accountEditBox.MaxLength = 20;
            this.accountEditBox.Name = "accountEditBox";
            this.accountEditBox.Text = null;
            // 
            // syncButton
            // 
            this.syncButton.Label = "Sync account";
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
            this.excelAdsGroup.ResumeLayout(false);
            this.excelAdsGroup.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup excelAdsGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox accountEditBox;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton syncButton;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon1 Ribbon1
        {
            get { return this.GetRibbon<Ribbon1>(); }
        }
    }
}
