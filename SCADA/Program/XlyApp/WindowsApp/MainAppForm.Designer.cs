namespace WindowsApp
{
    partial class MainAppForm
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
            this.comboFunCode = new System.Windows.Forms.ComboBox();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.txtReceived = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnSend1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboFunCode
            // 
            this.comboFunCode.FormattingEnabled = true;
            this.comboFunCode.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "15",
            "16"});
            this.comboFunCode.Location = new System.Drawing.Point(31, 30);
            this.comboFunCode.Name = "comboFunCode";
            this.comboFunCode.Size = new System.Drawing.Size(511, 26);
            this.comboFunCode.TabIndex = 0;
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(31, 75);
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(511, 33);
            this.txtSend.TabIndex = 1;
            this.txtSend.Text = "0001000000060103006C0003 ";
            // 
            // txtReceived
            // 
            this.txtReceived.Location = new System.Drawing.Point(31, 131);
            this.txtReceived.Multiline = true;
            this.txtReceived.Name = "txtReceived";
            this.txtReceived.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReceived.Size = new System.Drawing.Size(711, 598);
            this.txtReceived.TabIndex = 2;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(615, 22);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(127, 40);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "发送固定";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnSend1
            // 
            this.btnSend1.Location = new System.Drawing.Point(615, 68);
            this.btnSend1.Name = "btnSend1";
            this.btnSend1.Size = new System.Drawing.Size(127, 40);
            this.btnSend1.TabIndex = 4;
            this.btnSend1.Text = "发送自定义";
            this.btnSend1.UseVisualStyleBackColor = true;
            this.btnSend1.Click += new System.EventHandler(this.btnSend1_Click);
            // 
            // MainAppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 741);
            this.Controls.Add(this.btnSend1);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtReceived);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.comboFunCode);
            this.Name = "MainAppForm";
            this.Text = "MainAppForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboFunCode;
        private System.Windows.Forms.TextBox txtSend;
        public System.Windows.Forms.TextBox txtReceived;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnSend1;
    }
}