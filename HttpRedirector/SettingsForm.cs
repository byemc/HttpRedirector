
using System.Data;
using Microsoft.Win32;

namespace HttpRedirector
{
    public partial class SettingsForm : Form
    {
        private bool Initialising = false;
        public SettingsForm()
        {
            InitializeComponent();
            comboBox1.DataSource = Form1.GetBrowsers();

            if (Program.Settings.DefaultBrowser is not null)
                comboBox1.SelectedIndex = comboBox1.Items.Cast<Browser>().ToList().FindIndex(b => b.Id == Program.Settings.DefaultBrowser);

            checkBox1.Checked = Program.Settings.AutoLaunchBrowser;
            numericUpDown1.Value = Program.Settings.AutoLaunchSeconds;

            // Check if the default browser settings needs updating
            if (Program.AssociationsNeedUpdating())
            {
                var dlg = new UpdateBrowserForm();
                if (!dlg.IsDisposed)
                    dlg.ShowDialog();
            }

            UpdateDefaultBrowserText();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            Program.Settings.DefaultBrowser = (string)comboBox1.SelectedValue;
            Program.Settings.AutoLaunchBrowser = checkBox1.Checked;
            Program.Settings.AutoLaunchSeconds = (int)numericUpDown1.Value;

            Program.Settings.Save();
            Close();
        }

        // "Set as default" button
        private async void button1_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            // Technically, this should only work on Windows 11. But I don't have time to fix it for Windows 10 /shrug
            await Windows.System.Launcher.LaunchUriAsync(
                new System.Uri("ms-settings:defaultapps?registeredAppUser=ByespaceHttpRedirector")
            );
            UseWaitCursor = false;
        }

        private void UpdateDefaultBrowserText()
        {
            if (Settings.IsDefaultBrowser())
            {
                label6.Text = "HTTP Redirector is already your default browser!!";
                button1.Enabled = false;
            }
            else
            {
                label6.Text = "HTTP Redirector is not your default browser.";
                button1.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var dlg = MessageBox.Show("Would you like to delete HTTP Redirector's file associations (removing it as a default app) and erase its settings?", "HTTP Redirector", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
            {
                Program.RemoveAssociations();
                Program.Settings.Delete();

                MessageBox.Show("HTTP Redirector's associations have been removed. You may now delete HTTP Redirector.\nTo use HTTP Redirector again, simply open it again.", "HTTP Redirector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Environment.Exit(0);
                return;
            }
        }
    }
}
