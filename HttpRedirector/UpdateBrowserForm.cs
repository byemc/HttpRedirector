
using static System.Net.WebRequestMethods;

namespace HttpRedirector
{
    public partial class UpdateBrowserForm : Form
    {
        public UpdateBrowserForm()
        {
            InitializeComponent();

            replacementTextBox.Text = Application.ExecutablePath;
            replacementVersion.Text = Program.RunningVersion.ToString();
            currentTextBox.Text = Program.CurrentHTTPRedirectorPath ?? "Not Installed";
            currentVersionBox.Text = Program.CurrentHTTPRedirectorVersion is not null
                ? Program.CurrentVersion.ToString()
                : "-";

            if (Program.CurrentHTTPRedirectorPath is null)
            {
                label1.Text = @"HTTP Redirector isn't configured to be a default browser on this computer.
Would you like to add the system associations for HTTP Redirector?";
            }


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

            //if (Program.CurrentHTTPRedirectorPath is null)
            //{
            //    Program.UpdateAssociations();
            //    Close();
            //}
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
