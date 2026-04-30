using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Windows.UI.Popups;

namespace HttpRedirector
{
    public partial class UpdateBrowserForm : Form
    {
        public UpdateBrowserForm()
        {
            InitializeComponent();

            replacementTextBox.Text = Application.ExecutablePath;
            replacementVersion.Text = Application.ProductVersion;
            currentTextBox.Text = Program.CurrentHTTPRedirectorPath ?? "Not Installed";
            currentVersionBox.Text = Program.CurrentHTTPRedirectorVersion ?? "";

            var rel = Program.IsCurrentNewer();
            switch (rel)
            {
                case 1:
                    relativeVersion.Text = string.Format(relativeVersion.Text, "NEWER than");
                    break;
                case -1:
                    relativeVersion.Text = string.Format(relativeVersion.Text, "OLDER than");
                    break;
                default:
                    relativeVersion.Text = string.Format(relativeVersion.Text, "the SAME as");
                    break;
            }

            if (Program.CurrentHTTPRedirectorPath is null)
            {
                Program.UpdateAssociations();
                Close();
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Program.UpdateAssociations();
            MessageBox.Show("Updated file associations", "HTTP Redirector", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
