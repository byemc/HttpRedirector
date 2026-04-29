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

            var current = Program.CurrentHTTPRedirectorPath;
            replacementTextBox.Text = Application.ExecutablePath;
            currentTextBox.Text = current ?? "Not Installed";

            if (Program.CurrentHTTPRedirectorPath is null)
            {
                Program.UpdateAssociations();
                Close();
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Program.UpdateAssociations();
            //var dlg = new MessageDialog("Updated file associations");
            //await dlg.ShowAsync();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
