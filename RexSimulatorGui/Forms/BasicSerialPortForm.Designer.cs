/*
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
    partial class BasicSerialPortForm
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
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.sendFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.serialLabel = new System.Windows.Forms.Label();
            this.resendFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoloadDisabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendFileToolStripMenuItem,
            this.resendFileToolStripMenuItem,
            this.autoloadDisabledToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(727, 24);
            this.mainMenuStrip.TabIndex = 1;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // sendFileToolStripMenuItem
            // 
            this.sendFileToolStripMenuItem.Name = "sendFileToolStripMenuItem";
            this.sendFileToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.sendFileToolStripMenuItem.Text = "Send File";
            this.sendFileToolStripMenuItem.Click += new System.EventHandler(this.sendFileToolStripMenuItem_Click);
            // 
            // updateTimer
            // 
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // serialLabel
            // 
            this.serialLabel.AllowDrop = true;
            this.serialLabel.BackColor = System.Drawing.SystemColors.Window;
            this.serialLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serialLabel.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serialLabel.Location = new System.Drawing.Point(0, 24);
            this.serialLabel.Name = "serialLabel";
            this.serialLabel.Size = new System.Drawing.Size(727, 500);
            this.serialLabel.TabIndex = 2;
            // 
            // resendFileToolStripMenuItem
            // 
            this.resendFileToolStripMenuItem.Name = "resendFileToolStripMenuItem";
            this.resendFileToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.resendFileToolStripMenuItem.Text = "Resend File";
            this.resendFileToolStripMenuItem.Click += new System.EventHandler(this.resendFileToolStripMenuItem_Click);
            // 
            // autoloadDisabledToolStripMenuItem
            // 
            this.autoloadDisabledToolStripMenuItem.Name = "autoloadDisabledToolStripMenuItem";
            this.autoloadDisabledToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.autoloadDisabledToolStripMenuItem.Text = "Autoload Disabled";
            this.autoloadDisabledToolStripMenuItem.Click += new System.EventHandler(this.autoloadDisabledToolStripMenuItem_Click);
            // 
            // BasicSerialPortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 524);
            this.Controls.Add(this.serialLabel);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "BasicSerialPortForm";
            this.Text = "SerialPortForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SerialPortForm_FormClosing);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.serialTextBox_KeyPress);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem sendFileToolStripMenuItem;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Label serialLabel;
        private System.Windows.Forms.ToolStripMenuItem resendFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoloadDisabledToolStripMenuItem;
    }
}