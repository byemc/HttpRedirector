
using System.Data;

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
    }
}
