namespace WindowsDemo
{
    partial class MonitoringForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonitoringForm));
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.btn_Start2 = new System.Windows.Forms.Button();
            this.写入 = new System.Windows.Forms.Button();
            this.btn_Pump1 = new System.Windows.Forms.Button();
            this.btn_Pump2 = new System.Windows.Forms.Button();
            this.txt_RNum1 = new System.Windows.Forms.TextBox();
            this.txt_RNum2 = new System.Windows.Forms.TextBox();
            this.txt_RNum3 = new System.Windows.Forms.TextBox();
            this.txt_RNum4 = new System.Windows.Forms.TextBox();
            this.txt_RNum5 = new System.Windows.Forms.TextBox();
            this.txt_RNum6 = new System.Windows.Forms.TextBox();
            this.txt_RNum7 = new System.Windows.Forms.TextBox();
            this.txt_RNum8 = new System.Windows.Forms.TextBox();
            this.txt_WNum1 = new System.Windows.Forms.TextBox();
            this.txt_WNum2 = new System.Windows.Forms.TextBox();
            this.txt_WNum3 = new System.Windows.Forms.TextBox();
            this.txt_WNum4 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtmsg = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.button1 = new System.Windows.Forms.Button();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtPressure = new System.Windows.Forms.TextBox();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtCurrent = new System.Windows.Forms.TextBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtSpeed = new System.Windows.Forms.TextBox();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(24, 14);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(60, 27);
            this.btn_Start.TabIndex = 0;
            this.btn_Start.Text = "启动";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            this.btn_Start.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Start_MouseDown);
            this.btn_Start.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Start_MouseUp);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(211, 14);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(60, 27);
            this.btn_Stop.TabIndex = 1;
            this.btn_Stop.Text = "停止";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Stop_MouseDown);
            this.btn_Stop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Stop_MouseUp);
            // 
            // btn_Start2
            // 
            this.btn_Start2.Location = new System.Drawing.Point(116, 14);
            this.btn_Start2.Name = "btn_Start2";
            this.btn_Start2.Size = new System.Drawing.Size(60, 27);
            this.btn_Start2.TabIndex = 2;
            this.btn_Start2.Text = "启动";
            this.btn_Start2.UseVisualStyleBackColor = true;
            this.btn_Start2.Click += new System.EventHandler(this.btn_Start2_Click);
            // 
            // 写入
            // 
            this.写入.Location = new System.Drawing.Point(286, 48);
            this.写入.Name = "写入";
            this.写入.Size = new System.Drawing.Size(29, 47);
            this.写入.TabIndex = 3;
            this.写入.Text = "写入";
            this.写入.UseVisualStyleBackColor = true;
            this.写入.Click += new System.EventHandler(this.btn_Write_Click);
            // 
            // btn_Pump1
            // 
            this.btn_Pump1.Location = new System.Drawing.Point(299, 14);
            this.btn_Pump1.Name = "btn_Pump1";
            this.btn_Pump1.Size = new System.Drawing.Size(60, 27);
            this.btn_Pump1.TabIndex = 4;
            this.btn_Pump1.Text = "泵1";
            this.btn_Pump1.UseVisualStyleBackColor = true;
            // 
            // btn_Pump2
            // 
            this.btn_Pump2.Location = new System.Drawing.Point(391, 14);
            this.btn_Pump2.Name = "btn_Pump2";
            this.btn_Pump2.Size = new System.Drawing.Size(60, 27);
            this.btn_Pump2.TabIndex = 5;
            this.btn_Pump2.Text = "泵2";
            this.btn_Pump2.UseVisualStyleBackColor = true;
            // 
            // txt_RNum1
            // 
            this.txt_RNum1.Location = new System.Drawing.Point(13, 10);
            this.txt_RNum1.Name = "txt_RNum1";
            this.txt_RNum1.ReadOnly = true;
            this.txt_RNum1.Size = new System.Drawing.Size(116, 22);
            this.txt_RNum1.TabIndex = 6;
            // 
            // txt_RNum2
            // 
            this.txt_RNum2.Location = new System.Drawing.Point(13, 42);
            this.txt_RNum2.Name = "txt_RNum2";
            this.txt_RNum2.ReadOnly = true;
            this.txt_RNum2.Size = new System.Drawing.Size(116, 22);
            this.txt_RNum2.TabIndex = 7;
            // 
            // txt_RNum3
            // 
            this.txt_RNum3.Location = new System.Drawing.Point(13, 73);
            this.txt_RNum3.Name = "txt_RNum3";
            this.txt_RNum3.ReadOnly = true;
            this.txt_RNum3.Size = new System.Drawing.Size(116, 22);
            this.txt_RNum3.TabIndex = 8;
            // 
            // txt_RNum4
            // 
            this.txt_RNum4.Location = new System.Drawing.Point(13, 105);
            this.txt_RNum4.Name = "txt_RNum4";
            this.txt_RNum4.ReadOnly = true;
            this.txt_RNum4.Size = new System.Drawing.Size(116, 22);
            this.txt_RNum4.TabIndex = 9;
            // 
            // txt_RNum5
            // 
            this.txt_RNum5.Location = new System.Drawing.Point(24, 77);
            this.txt_RNum5.Name = "txt_RNum5";
            this.txt_RNum5.ReadOnly = true;
            this.txt_RNum5.Size = new System.Drawing.Size(90, 22);
            this.txt_RNum5.TabIndex = 10;
            // 
            // txt_RNum6
            // 
            this.txt_RNum6.Location = new System.Drawing.Point(24, 108);
            this.txt_RNum6.Name = "txt_RNum6";
            this.txt_RNum6.ReadOnly = true;
            this.txt_RNum6.Size = new System.Drawing.Size(90, 22);
            this.txt_RNum6.TabIndex = 11;
            // 
            // txt_RNum7
            // 
            this.txt_RNum7.Location = new System.Drawing.Point(24, 140);
            this.txt_RNum7.Name = "txt_RNum7";
            this.txt_RNum7.ReadOnly = true;
            this.txt_RNum7.Size = new System.Drawing.Size(90, 22);
            this.txt_RNum7.TabIndex = 12;
            // 
            // txt_RNum8
            // 
            this.txt_RNum8.Location = new System.Drawing.Point(24, 171);
            this.txt_RNum8.Name = "txt_RNum8";
            this.txt_RNum8.ReadOnly = true;
            this.txt_RNum8.Size = new System.Drawing.Size(90, 22);
            this.txt_RNum8.TabIndex = 13;
            // 
            // txt_WNum1
            // 
            this.txt_WNum1.Location = new System.Drawing.Point(164, 10);
            this.txt_WNum1.Name = "txt_WNum1";
            this.txt_WNum1.Size = new System.Drawing.Size(116, 22);
            this.txt_WNum1.TabIndex = 14;
            this.txt_WNum1.Text = "0";
            // 
            // txt_WNum2
            // 
            this.txt_WNum2.Location = new System.Drawing.Point(164, 42);
            this.txt_WNum2.Name = "txt_WNum2";
            this.txt_WNum2.Size = new System.Drawing.Size(116, 22);
            this.txt_WNum2.TabIndex = 15;
            this.txt_WNum2.Text = "0";
            // 
            // txt_WNum3
            // 
            this.txt_WNum3.Location = new System.Drawing.Point(164, 73);
            this.txt_WNum3.Name = "txt_WNum3";
            this.txt_WNum3.Size = new System.Drawing.Size(116, 22);
            this.txt_WNum3.TabIndex = 16;
            this.txt_WNum3.Text = "0";
            // 
            // txt_WNum4
            // 
            this.txt_WNum4.Location = new System.Drawing.Point(164, 105);
            this.txt_WNum4.Name = "txt_WNum4";
            this.txt_WNum4.Size = new System.Drawing.Size(116, 22);
            this.txt_WNum4.TabIndex = 17;
            this.txt_WNum4.Text = "0";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtmsg
            // 
            this.txtmsg.Location = new System.Drawing.Point(14, 215);
            this.txtmsg.Multiline = true;
            this.txtmsg.Name = "txtmsg";
            this.txtmsg.Size = new System.Drawing.Size(456, 254);
            this.txtmsg.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.txt_RNum1);
            this.panel1.Controls.Add(this.txt_RNum2);
            this.panel1.Controls.Add(this.txt_WNum4);
            this.panel1.Controls.Add(this.txt_RNum3);
            this.panel1.Controls.Add(this.txt_WNum3);
            this.panel1.Controls.Add(this.txt_RNum4);
            this.panel1.Controls.Add(this.txt_WNum2);
            this.panel1.Controls.Add(this.txt_WNum1);
            this.panel1.Controls.Add(this.写入);
            this.panel1.Location = new System.Drawing.Point(133, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(318, 141);
            this.panel1.TabIndex = 19;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(23, 273);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(112, 40);
            this.simpleButton1.TabIndex = 20;
            this.simpleButton1.Text = "启动";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.button1);
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.textBox1);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.txtPressure);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.txtCurrent);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.txtStatus);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.txtSpeed);
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Location = new System.Drawing.Point(507, 28);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(426, 335);
            this.panelControl1.TabIndex = 21;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(222, 228);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 27);
            this.button1.TabIndex = 32;
            this.button1.Text = "设定";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // labelControl6
            // 
            this.labelControl6.LineVisible = true;
            this.labelControl6.Location = new System.Drawing.Point(15, 231);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(60, 14);
            this.labelControl6.TabIndex = 31;
            this.labelControl6.Text = "设定转速：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(91, 231);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(116, 22);
            this.textBox1.TabIndex = 30;
            this.textBox1.Text = "0";
            // 
            // labelControl5
            // 
            this.labelControl5.LineVisible = true;
            this.labelControl5.Location = new System.Drawing.Point(15, 190);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(72, 14);
            this.labelControl5.TabIndex = 29;
            this.labelControl5.Text = "空压机压力：";
            // 
            // txtPressure
            // 
            this.txtPressure.Location = new System.Drawing.Point(91, 187);
            this.txtPressure.Name = "txtPressure";
            this.txtPressure.Size = new System.Drawing.Size(116, 22);
            this.txtPressure.TabIndex = 28;
            this.txtPressure.Text = "0";
            // 
            // labelControl4
            // 
            this.labelControl4.LineVisible = true;
            this.labelControl4.Location = new System.Drawing.Point(23, 146);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 14);
            this.labelControl4.TabIndex = 27;
            this.labelControl4.Text = "电机电流：";
            // 
            // txtCurrent
            // 
            this.txtCurrent.Location = new System.Drawing.Point(91, 143);
            this.txtCurrent.Name = "txtCurrent";
            this.txtCurrent.Size = new System.Drawing.Size(116, 22);
            this.txtCurrent.TabIndex = 26;
            this.txtCurrent.Text = "0";
            // 
            // labelControl3
            // 
            this.labelControl3.LineVisible = true;
            this.labelControl3.Location = new System.Drawing.Point(23, 99);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 14);
            this.labelControl3.TabIndex = 25;
            this.labelControl3.Text = "电机状态：";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(91, 96);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(116, 22);
            this.txtStatus.TabIndex = 24;
            this.txtStatus.Text = "0";
            // 
            // labelControl2
            // 
            this.labelControl2.LineVisible = true;
            this.labelControl2.Location = new System.Drawing.Point(23, 53);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 23;
            this.labelControl2.Text = "电机转速：";
            // 
            // txtSpeed
            // 
            this.txtSpeed.Location = new System.Drawing.Point(91, 50);
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.Size = new System.Drawing.Size(116, 22);
            this.txtSpeed.TabIndex = 22;
            this.txtSpeed.Text = "0";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(176, 273);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(112, 40);
            this.simpleButton2.TabIndex = 21;
            this.simpleButton2.Text = "停止";
            // 
            // labelControl1
            // 
            this.labelControl1.LineVisible = true;
            this.labelControl1.Location = new System.Drawing.Point(23, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "空压机";
            // 
            // MonitoringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 483);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtmsg);
            this.Controls.Add(this.txt_RNum8);
            this.Controls.Add(this.txt_RNum7);
            this.Controls.Add(this.txt_RNum6);
            this.Controls.Add(this.txt_RNum5);
            this.Controls.Add(this.btn_Pump2);
            this.Controls.Add(this.btn_Pump1);
            this.Controls.Add(this.btn_Start2);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.btn_Start);
            this.Name = "MonitoringForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Button btn_Start2;
        private System.Windows.Forms.Button 写入;
        private System.Windows.Forms.Button btn_Pump1;
        private System.Windows.Forms.Button btn_Pump2;
        private System.Windows.Forms.TextBox txt_RNum1;
        private System.Windows.Forms.TextBox txt_RNum2;
        private System.Windows.Forms.TextBox txt_RNum3;
        private System.Windows.Forms.TextBox txt_RNum4;
        private System.Windows.Forms.TextBox txt_RNum5;
        private System.Windows.Forms.TextBox txt_RNum6;
        private System.Windows.Forms.TextBox txt_RNum7;
        private System.Windows.Forms.TextBox txt_RNum8;
        private System.Windows.Forms.TextBox txt_WNum1;
        private System.Windows.Forms.TextBox txt_WNum2;
        private System.Windows.Forms.TextBox txt_WNum3;
        private System.Windows.Forms.TextBox txt_WNum4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtmsg;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.TextBox txtSpeed;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.TextBox txtStatus;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.TextBox txtPressure;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.TextBox txtCurrent;
        private System.Windows.Forms.Button button1;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private System.Windows.Forms.TextBox textBox1;
    }
}

