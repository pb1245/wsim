﻿/*
########################################################################
# This file is part of wsim, a WRAMP simulator.
#
# Copyright (C) 2016 Paul Monigatti
# Copyright (C) 2019 The University of Waikato, Hamilton, New Zealand.
#
# This program is free software: you can redistribute it and/or modify
# it under the terms of the GNU General Public License as published by
# the Free Software Foundation, either version 3 of the License, or
# (at your option) any later version.
#
# This program is distributed in the hope that it will be useful,
# but WITHOUT ANY WARRANTY; without even the implied warranty of
# MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
# GNU General Public License for more details.
#
# You should have received a copy of the GNU General Public License
# along with this program.  If not, see <https://www.gnu.org/licenses/>.
########################################################################
*/
namespace RexSimulatorGui.Forms
{
    partial class RexBoardForm
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.interruptButtonCheckbox = new System.Windows.Forms.CheckBox();
            this.timerConfigCheckbox = new System.Windows.Forms.CheckBox();
            this.parallelConfigCheckbox = new System.Windows.Forms.CheckBox();
            this.serialConfig2Checkbox = new System.Windows.Forms.CheckBox();
            this.serialConfig1Checkbox = new System.Windows.Forms.CheckBox();
            this.memoryCheckbox = new System.Windows.Forms.CheckBox();
            this.sprCheckbox = new System.Windows.Forms.CheckBox();
            this.gprCheckbox = new System.Windows.Forms.CheckBox();
            this.serialForm2Checkbox = new System.Windows.Forms.CheckBox();
            this.serialForm1Checkbox = new System.Windows.Forms.CheckBox();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbFullSpeed = new System.Windows.Forms.CheckBox();
            this.stepButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.rexWidget1 = new RexSimulatorGui.Controls.RexWidget();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.interruptButtonCheckbox);
            this.groupBox1.Controls.Add(this.timerConfigCheckbox);
            this.groupBox1.Controls.Add(this.parallelConfigCheckbox);
            this.groupBox1.Controls.Add(this.serialConfig2Checkbox);
            this.groupBox1.Controls.Add(this.serialConfig1Checkbox);
            this.groupBox1.Controls.Add(this.memoryCheckbox);
            this.groupBox1.Controls.Add(this.sprCheckbox);
            this.groupBox1.Controls.Add(this.gprCheckbox);
            this.groupBox1.Controls.Add(this.serialForm2Checkbox);
            this.groupBox1.Controls.Add(this.serialForm1Checkbox);
            this.groupBox1.Location = new System.Drawing.Point(13, 585);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(689, 112);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Show Forms";
            // 
            // interruptButtonCheckbox
            // 
            this.interruptButtonCheckbox.Location = new System.Drawing.Point(377, 43);
            this.interruptButtonCheckbox.Name = "interruptButtonCheckbox";
            this.interruptButtonCheckbox.Size = new System.Drawing.Size(147, 17);
            this.interruptButtonCheckbox.TabIndex = 6;
            this.interruptButtonCheckbox.Text = "Interrupt Button";
            this.interruptButtonCheckbox.UseVisualStyleBackColor = true;
            this.interruptButtonCheckbox.CheckedChanged += new System.EventHandler(this.Checkbox_CheckedChanged);
            // 
            // timerConfigCheckbox
            // 
            this.timerConfigCheckbox.Location = new System.Drawing.Point(530, 89);
            this.timerConfigCheckbox.Name = "timerConfigCheckbox";
            this.timerConfigCheckbox.Size = new System.Drawing.Size(153, 17);
            this.timerConfigCheckbox.TabIndex = 5;
            this.timerConfigCheckbox.Text = "Timer Registers";
            this.timerConfigCheckbox.UseVisualStyleBackColor = true;
            this.timerConfigCheckbox.CheckedChanged += new System.EventHandler(this.Checkbox_CheckedChanged);
            // 
            // parallelConfigCheckbox
            // 
            this.parallelConfigCheckbox.Location = new System.Drawing.Point(530, 66);
            this.parallelConfigCheckbox.Name = "parallelConfigCheckbox";
            this.parallelConfigCheckbox.Size = new System.Drawing.Size(153, 17);
            this.parallelConfigCheckbox.TabIndex = 5;
            this.parallelConfigCheckbox.Text = "Parallel Port Registers";
            this.parallelConfigCheckbox.UseVisualStyleBackColor = true;
            this.parallelConfigCheckbox.CheckedChanged += new System.EventHandler(this.Checkbox_CheckedChanged);
            // 
            // serialConfig2Checkbox
            // 
            this.serialConfig2Checkbox.Location = new System.Drawing.Point(530, 43);
            this.serialConfig2Checkbox.Name = "serialConfig2Checkbox";
            this.serialConfig2Checkbox.Size = new System.Drawing.Size(153, 18);
            this.serialConfig2Checkbox.TabIndex = 5;
            this.serialConfig2Checkbox.Text = "Serial Port 2 Registers";
            this.serialConfig2Checkbox.UseVisualStyleBackColor = true;
            this.serialConfig2Checkbox.CheckedChanged += new System.EventHandler(this.Checkbox_CheckedChanged);
            // 
            // serialConfig1Checkbox
            // 
            this.serialConfig1Checkbox.Location = new System.Drawing.Point(530, 20);
            this.serialConfig1Checkbox.Name = "serialConfig1Checkbox";
            this.serialConfig1Checkbox.Size = new System.Drawing.Size(153, 17);
            this.serialConfig1Checkbox.TabIndex = 5;
            this.serialConfig1Checkbox.Text = "Serial Port 1 Registers";
            this.serialConfig1Checkbox.UseVisualStyleBackColor = true;
            this.serialConfig1Checkbox.CheckedChanged += new System.EventHandler(this.Checkbox_CheckedChanged);
            // 
            // memoryCheckbox
            // 
            this.memoryCheckbox.Location = new System.Drawing.Point(377, 20);
            this.memoryCheckbox.Name = "memoryCheckbox";
            this.memoryCheckbox.Size = new System.Drawing.Size(147, 17);
            this.memoryCheckbox.TabIndex = 4;
            this.memoryCheckbox.Text = "Memory (RAM)";
            this.memoryCheckbox.UseVisualStyleBackColor = true;
            this.memoryCheckbox.CheckedChanged += new System.EventHandler(this.Checkbox_CheckedChanged);
            // 
            // sprCheckbox
            // 
            this.sprCheckbox.Location = new System.Drawing.Point(162, 44);
            this.sprCheckbox.Name = "sprCheckbox";
            this.sprCheckbox.Size = new System.Drawing.Size(209, 17);
            this.sprCheckbox.TabIndex = 3;
            this.sprCheckbox.Text = "Special Purpose Registers";
            this.sprCheckbox.UseVisualStyleBackColor = true;
            this.sprCheckbox.CheckedChanged += new System.EventHandler(this.Checkbox_CheckedChanged);
            // 
            // gprCheckbox
            // 
            this.gprCheckbox.Location = new System.Drawing.Point(162, 20);
            this.gprCheckbox.Name = "gprCheckbox";
            this.gprCheckbox.Size = new System.Drawing.Size(209, 17);
            this.gprCheckbox.TabIndex = 2;
            this.gprCheckbox.Text = "General Purpose Registers";
            this.gprCheckbox.UseVisualStyleBackColor = true;
            this.gprCheckbox.CheckedChanged += new System.EventHandler(this.Checkbox_CheckedChanged);
            // 
            // serialForm2Checkbox
            // 
            this.serialForm2Checkbox.Location = new System.Drawing.Point(7, 44);
            this.serialForm2Checkbox.Name = "serialForm2Checkbox";
            this.serialForm2Checkbox.Size = new System.Drawing.Size(149, 16);
            this.serialForm2Checkbox.TabIndex = 1;
            this.serialForm2Checkbox.Text = "Serial Port 2";
            this.serialForm2Checkbox.UseVisualStyleBackColor = true;
            this.serialForm2Checkbox.CheckedChanged += new System.EventHandler(this.Checkbox_CheckedChanged);
            // 
            // serialForm1Checkbox
            // 
            this.serialForm1Checkbox.Checked = true;
            this.serialForm1Checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.serialForm1Checkbox.Location = new System.Drawing.Point(7, 20);
            this.serialForm1Checkbox.Name = "serialForm1Checkbox";
            this.serialForm1Checkbox.Size = new System.Drawing.Size(149, 17);
            this.serialForm1Checkbox.TabIndex = 0;
            this.serialForm1Checkbox.Text = "Serial Port 1";
            this.serialForm1Checkbox.UseVisualStyleBackColor = true;
            this.serialForm1Checkbox.CheckedChanged += new System.EventHandler(this.Checkbox_CheckedChanged);
            // 
            // updateTimer
            // 
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cbFullSpeed);
            this.groupBox2.Controls.Add(this.stepButton);
            this.groupBox2.Controls.Add(this.runButton);
            this.groupBox2.Location = new System.Drawing.Point(818, 585);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(108, 112);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Control";
            // 
            // cbFullSpeed
            // 
            this.cbFullSpeed.Location = new System.Drawing.Point(7, 78);
            this.cbFullSpeed.Name = "cbFullSpeed";
            this.cbFullSpeed.Size = new System.Drawing.Size(91, 17);
            this.cbFullSpeed.TabIndex = 11;
            this.cbFullSpeed.Text = "Full Speed";
            this.cbFullSpeed.UseVisualStyleBackColor = true;
            this.cbFullSpeed.CheckedChanged += new System.EventHandler(this.cbFullSpeed_CheckedChanged);
            // 
            // stepButton
            // 
            this.stepButton.Location = new System.Drawing.Point(6, 48);
            this.stepButton.Name = "stepButton";
            this.stepButton.Size = new System.Drawing.Size(96, 23);
            this.stepButton.TabIndex = 10;
            this.stepButton.Text = "Single Step";
            this.stepButton.UseVisualStyleBackColor = true;
            this.stepButton.Click += new System.EventHandler(this.stepButton_Click);
            // 
            // runButton
            // 
            this.runButton.BackColor = System.Drawing.Color.Green;
            this.runButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runButton.ForeColor = System.Drawing.Color.White;
            this.runButton.Location = new System.Drawing.Point(6, 19);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(96, 23);
            this.runButton.TabIndex = 9;
            this.runButton.Text = "Stop";
            this.runButton.UseVisualStyleBackColor = false;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 706);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(928, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabel1.Text = "wsim";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // rexWidget1
            // 
            this.rexWidget1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rexWidget1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rexWidget1.Location = new System.Drawing.Point(0, 0);
            this.rexWidget1.Name = "rexWidget1";
            this.rexWidget1.Size = new System.Drawing.Size(928, 572);
            this.rexWidget1.TabIndex = 0;
            // 
            // RexBoardForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(928, 728);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rexWidget1);
            this.MaximizeBox = false;
            this.Name = "RexBoardForm";
            this.Text = "RexBoard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RexBoardForm_FormClosing);
            this.Load += new System.EventHandler(this.RexBoardForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.RexBoardForm_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.RexWidget rexWidget1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox serialForm2Checkbox;
        private System.Windows.Forms.CheckBox serialForm1Checkbox;
        private System.Windows.Forms.CheckBox memoryCheckbox;
        private System.Windows.Forms.CheckBox sprCheckbox;
        private System.Windows.Forms.CheckBox gprCheckbox;
        private System.Windows.Forms.CheckBox timerConfigCheckbox;
        private System.Windows.Forms.CheckBox parallelConfigCheckbox;
        private System.Windows.Forms.CheckBox serialConfig2Checkbox;
        private System.Windows.Forms.CheckBox serialConfig1Checkbox;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.CheckBox interruptButtonCheckbox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button stepButton;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.CheckBox cbFullSpeed;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}