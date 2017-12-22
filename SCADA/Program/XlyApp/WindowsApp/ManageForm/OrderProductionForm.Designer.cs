namespace WindowsDemo.ManageForm
{
    partial class OrderProductionForm
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
            this.gcUserControl = new DevExpress.XtraGrid.GridControl();
            this.gvUserControl = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcUserControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUserControl)).BeginInit();
            this.SuspendLayout();
            // 
            // gcUserControl
            // 
            this.gcUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcUserControl.Location = new System.Drawing.Point(0, 0);
            this.gcUserControl.MainView = this.gvUserControl;
            this.gcUserControl.Name = "gcUserControl";
            this.gcUserControl.Size = new System.Drawing.Size(793, 417);
            this.gcUserControl.TabIndex = 0;
            this.gcUserControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUserControl});
            // 
            // gvUserControl
            // 
            this.gvUserControl.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gvUserControl.GridControl = this.gcUserControl;
            this.gvUserControl.Name = "gvUserControl";
            this.gvUserControl.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "订单号";
            this.gridColumn1.FieldName = "OrderID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "配比号";
            this.gridColumn2.FieldName = "RecipeID";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "生产数量";
            this.gridColumn3.FieldName = "ProductionOutput";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "订单状态";
            this.gridColumn4.FieldName = "OrderStatus";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "生产进度";
            this.gridColumn5.FieldName = "OrderProcess";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // OrderProductionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 417);
            this.Controls.Add(this.gcUserControl);
            this.Name = "OrderProductionForm";
            this.Text = "OrderProductionForm";
            ((System.ComponentModel.ISupportInitialize)(this.gcUserControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUserControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcUserControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUserControl;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
    }
}