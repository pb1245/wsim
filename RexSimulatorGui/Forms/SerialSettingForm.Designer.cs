namespace RexSimulatorGui.Forms
{
    partial class SerialSettingForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.sp1EnableCheckBox = new System.Windows.Forms.CheckBox();
            this.sp2EnableCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sp1PortNum = new System.Windows.Forms.NumericUpDown();
            this.sp2PortNum = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.sp1PortNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp2PortNum)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Telnet Port";
            // 
            // sp1EnableCheckBox
            // 
            this.sp1EnableCheckBox.AutoSize = true;
            this.sp1EnableCheckBox.Location = new System.Drawing.Point(12, 52);
            this.sp1EnableCheckBox.Name = "sp1EnableCheckBox";
            this.sp1EnableCheckBox.Size = new System.Drawing.Size(82, 17);
            this.sp1EnableCheckBox.TabIndex = 2;
            this.sp1EnableCheckBox.Text = "Enable SP1";
            this.sp1EnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // sp2EnableCheckBox
            // 
            this.sp2EnableCheckBox.AutoSize = true;
            this.sp2EnableCheckBox.Location = new System.Drawing.Point(12, 120);
            this.sp2EnableCheckBox.Name = "sp2EnableCheckBox";
            this.sp2EnableCheckBox.Size = new System.Drawing.Size(82, 17);
            this.sp2EnableCheckBox.TabIndex = 5;
            this.sp2EnableCheckBox.Text = "Enable SP2";
            this.sp2EnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Telnet Port";
            // 
            // sp1PortNum
            // 
            this.sp1PortNum.Location = new System.Drawing.Point(12, 26);
            this.sp1PortNum.Name = "sp1PortNum";
            this.sp1PortNum.Size = new System.Drawing.Size(120, 20);
            this.sp1PortNum.TabIndex = 6;
            this.sp1PortNum.Value = new decimal(new int[] {
            23,
            0,
            0,
            0});
            // 
            // sp2PortNum
            // 
            this.sp2PortNum.Location = new System.Drawing.Point(12, 94);
            this.sp2PortNum.Name = "sp2PortNum";
            this.sp2PortNum.Size = new System.Drawing.Size(120, 20);
            this.sp2PortNum.TabIndex = 7;
            this.sp2PortNum.Value = new decimal(new int[] {
            23,
            0,
            0,
            0});
            // 
            // SerialSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(166, 148);
            this.Controls.Add(this.sp2PortNum);
            this.Controls.Add(this.sp1PortNum);
            this.Controls.Add(this.sp2EnableCheckBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sp1EnableCheckBox);
            this.Controls.Add(this.label1);
            this.Name = "SerialSettingForm";
            this.Text = "SerialSettingForm";
            this.Load += new System.EventHandler(this.SerialSettingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sp1PortNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp2PortNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox sp1EnableCheckBox;
        private System.Windows.Forms.CheckBox sp2EnableCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown sp1PortNum;
        private System.Windows.Forms.NumericUpDown sp2PortNum;
    }
}