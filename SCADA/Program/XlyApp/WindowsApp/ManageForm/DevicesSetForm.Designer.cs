namespace WindowsDemo.ManageForm
{
    partial class DevicesSetForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gcUserControl = new DevExpress.XtraGrid.GridControl();
            this.gvUserControl = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.控件名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.数据点定义 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.数据点个数 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.备注 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcUserControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUserControl)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Location = new System.Drawing.Point(2, 1);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(824, 50);
            this.panelControl1.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.Controls.Add(this.gcUserControl);
            this.panelControl2.Location = new System.Drawing.Point(2, 55);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(824, 442);
            this.panelControl2.TabIndex = 1;
            // 
            // gcUserControl
            // 
            this.gcUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcUserControl.Location = new System.Drawing.Point(2, 2);
            this.gcUserControl.MainView = this.gvUserControl;
            this.gcUserControl.Name = "gcUserControl";
            this.gcUserControl.Size = new System.Drawing.Size(820, 438);
            this.gcUserControl.TabIndex = 0;
            this.gcUserControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUserControl});
            // 
            // gvUserControl
            // 
            this.gvUserControl.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.控件名称,
            this.数据点定义,
            this.数据点个数,
            this.备注});
            this.gvUserControl.GridControl = this.gcUserControl;
            this.gvUserControl.Name = "gvUserControl";
            this.gvUserControl.OptionsView.ShowGroupPanel = false;
            // 
            // 控件名称
            // 
            this.控件名称.Caption = "控件名称";
            this.控件名称.FieldName = "UserControlName";
            this.控件名称.Name = "控件名称";
            this.控件名称.Visible = true;
            this.控件名称.VisibleIndex = 0;
            this.控件名称.Width = 100;
            // 
            // 数据点定义
            // 
            this.数据点定义.Caption = "数据点定义";
            this.数据点定义.FieldName = "UserControJson";
            this.数据点定义.Name = "数据点定义";
            this.数据点定义.Visible = true;
            this.数据点定义.VisibleIndex = 1;
            this.数据点定义.Width = 400;
            // 
            // 数据点个数
            // 
            this.数据点个数.Caption = "数据点个数";
            this.数据点个数.FieldName = "JsonLenth";
            this.数据点个数.Name = "数据点个数";
            this.数据点个数.Visible = true;
            this.数据点个数.VisibleIndex = 2;
            this.数据点个数.Width = 20;
            // 
            // 备注
            // 
            this.备注.Caption = "备注";
            this.备注.FieldName = "ReMark";
            this.备注.Name = "备注";
            this.备注.Visible = true;
            this.备注.VisibleIndex = 3;
            this.备注.Width = 20;
            // 
            // DevicesSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 499);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "DevicesSetForm";
            this.Text = "用户控件设置";
            this.Load += new System.EventHandler(this.DevicesSetForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcUserControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUserControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl gcUserControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUserControl;
        private DevExpress.XtraGrid.Columns.GridColumn 控件名称;
        private DevExpress.XtraGrid.Columns.GridColumn 数据点定义;
        private DevExpress.XtraGrid.Columns.GridColumn 数据点个数;
        private DevExpress.XtraGrid.Columns.GridColumn 备注;
    }
}