﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RexSimulatorGui.Forms
{
    class Utils
    {
        public static string InputBox(string title, string promptText)
        {
            Form promptForm = new Form();
            Label label = new Label();
            TextBox tBox = new TextBox();
            Button okButton = new Button();
            Button cancelButton = new Button();

            promptForm.Text = title;
            label.Text = promptText;

            okButton.Text = "OK";
            cancelButton.Text = "Cancel";
            okButton.DialogResult = DialogResult.OK;
            cancelButton.DialogResult = DialogResult.Cancel;

            label.SetBounds(10, 10, 350, 20);
            tBox.SetBounds(10, 30, 350, 20);
            okButton.SetBounds(220, 60, 70, 25);
            cancelButton.SetBounds(290, 60, 70, 25);

            label.AutoSize = true;
            tBox.Anchor = tBox.Anchor | AnchorStyles.Right;
            okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            promptForm.ClientSize = new System.Drawing.Size(370, 95);
            promptForm.Controls.AddRange(new Control[] { label, tBox, okButton, cancelButton });

            promptForm.ClientSize = new System.Drawing.Size(Math.Max(300, label.Right + 10), promptForm.ClientSize.Height);
            promptForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            promptForm.StartPosition = FormStartPosition.CenterScreen;
            promptForm.MinimizeBox = false;
            promptForm.MaximizeBox = false;
            promptForm.AcceptButton = okButton;
            promptForm.CancelButton = cancelButton;

            DialogResult dlgResult = promptForm.ShowDialog();
            if (dlgResult == DialogResult.OK)
                return tBox.Text;
            else
                return null;
        }
    }
}
