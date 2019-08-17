using System;
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

            label.SetBounds(9, 20, 372, 13);
            tBox.SetBounds(12, 36, 372, 20);
            okButton.SetBounds(228, 72, 75, 23);
            cancelButton.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            tBox.Anchor = tBox.Anchor | AnchorStyles.Right;
            okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            promptForm.ClientSize = new System.Drawing.Size(396, 107);
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
