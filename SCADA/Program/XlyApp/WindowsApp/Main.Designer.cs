namespace WindowsApp
{
    partial class Main
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
            this.txtSend = new DevExpress.XtraEditors.MemoEdit();
            this.btuSend = new DevExpress.XtraEditors.SimpleButton();
            this.memoReceived = new DevExpress.XtraEditors.MemoEdit();
            this.comboFunCode = new DevExpress.XtraEditors.ComboBoxEdit();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtSend.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoReceived.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboFunCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(12, 79);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(438, 38);
            this.txtSend.TabIndex = 0;
            // 
            // btuSend
            // 
            this.btuSend.Location = new System.Drawing.Point(495, 77);
            this.btuSend.Name = "btuSend";
            this.btuSend.Size = new System.Drawing.Size(75, 23);
            this.btuSend.TabIndex = 1;
            this.btuSend.Text = "发送";
            this.btuSend.Click += new System.EventHandler(this.btuSend_Click);
            // 
            // memoReceived
            // 
            this.memoReceived.Location = new System.Drawing.Point(12, 137);
            this.memoReceived.Name = "memoReceived";
            this.memoReceived.Size = new System.Drawing.Size(438, 227);
            this.memoReceived.TabIndex = 2;
            // 
            // comboFunCode
            // 
            this.comboFunCode.Location = new System.Drawing.Point(12, 53);
            this.comboFunCode.Name = "comboFunCode";
            this.comboFunCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboFunCode.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "15",
            "16"});
            this.comboFunCode.Size = new System.Drawing.Size(438, 20);
            this.comboFunCode.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(495, 202);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 376);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboFunCode);
            this.Controls.Add(this.memoReceived);
            this.Controls.Add(this.btuSend);
            this.Controls.Add(this.txtSend);
            this.Name = "Main";
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.txtSend.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoReceived.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboFunCode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit txtSend;
        private DevExpress.XtraEditors.SimpleButton btuSend;
        public DevExpress.XtraEditors.MemoEdit memoReceived;
        private DevExpress.XtraEditors.ComboBoxEdit comboFunCode;
        private System.Windows.Forms.Button button1;

    }
}