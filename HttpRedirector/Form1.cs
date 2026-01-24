using Microsoft.Win32;
using System.Data;
using System.Diagnostics;

namespace HttpRedirector
{
    public partial class Form1 : Form
    {
        private List<Browser> Browsers = new();
        private int TimeLeft = int.MaxValue;
        private int TimeLeftStart = int.MaxValue;
        private bool StartAcceptingEvents = false;
        private string[] Arguments { get; init; } = [];

        public Form1(string[] args)
        {
            Arguments = args;

            InitializeComponent();

            RefreshBrowsers();

            TimeLeft = ((Program.Settings.AutoLaunchSeconds * 1000) / browserOpenTimer.Interval);
            TimeLeftStart = ((Program.Settings.AutoLaunchSeconds * 1000) / browserOpenTimer.Interval);

            progressBar1.Maximum = TimeLeftStart;
            progressBar1.Value = TimeLeftStart - TimeLeft;
            browserOpenTimer.Enabled = true;

            label1.Text = String.Format("Opening {0}", [Arguments.FirstOrDefault() ?? "null"]);
        }

        private void RefreshBrowsers()
        {
            Browsers = GetBrowsers();
            var defaultBrowser = Program.Settings.DefaultBrowser ?? Browsers.FirstOrDefault()?.Id;
            if (defaultBrowser == null)
                throw new NotImplementedException("YO! you have no browsers installed!!!");

            foreach (var browser in Browsers)
            {
                var item = new ListViewItem();

                if (browser.Icon is not null)
                {
                    var imageIndex = browserIconList.Images.Count;
                    browserIconList.Images.Add(browser.Icon.ToBitmap());
                    item.ImageIndex = imageIndex;
                }

                item.Selected = browser.Id == defaultBrowser;
                item.Focused = browser.Id == defaultBrowser;
                item.Tag = browser;
                item.Text = browser.Name;
                listView1.Items.Add(item);
            }
            listView1.Select();
            //debugLabel.Text = $"Images: {browserIconList.Images.Count.ToString()}\n" +
            //    $"LV Items: {listView1.Items.Count}";
        }

        internal static List<Browser> GetBrowsers()
        {
            RegistryKey? userKeys = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Clients\StartMenuInternet");
            RegistryKey? localKeys = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Clients\StartMenuInternet");

            bool first = true;

            if (Program.Settings.DefaultBrowser is not null)
                first = false;

            var tmp = new Dictionary<string, Browser>();

            if (userKeys is not null)
                foreach (var key in userKeys.GetSubKeyNames())
                {
                    var reg = Registry.CurrentUser.OpenSubKey($"SOFTWARE\\Clients\\StartMenuInternet")?.OpenSubKey(key);
                    if (reg.OpenSubKey("Capabilities") == null)
                        continue;

                    var browser = new Browser(reg);

                    try
                    {
                        tmp.Add(key, browser);
                    }
                    catch (ArgumentException)
                    {
                        continue;
                    }
                }
            if (localKeys is not null)
                foreach (var key in localKeys.GetSubKeyNames())
                {
                    var reg = Registry.LocalMachine.OpenSubKey($"SOFTWARE\\Clients\\StartMenuInternet")?.OpenSubKey(key);

                    var browser = new Browser(reg);

                    try
                    {
                        tmp.Add(key, browser);
                    }
                    catch (ArgumentException)
                    {
                        continue;
                    }
                }

            return tmp.Select(x => x.Value).ToList<Browser>();
        }

        private void openBrowserAndQuit()
        {
            var selectedBrowser = listView1.GetSelectedItem();
            if (selectedBrowser is null)
                throw new NotImplementedException();

            var brow = (Browser?)selectedBrowser.Tag;
            if (brow is null)
                throw new NotImplementedException();

            var pStartInfo = new ProcessStartInfo(brow.ExePath)
            {
                ArgumentList =
                {
                    Arguments.FirstOrDefault() ?? ""
                }
            };
            var p = new Process()
            {
                StartInfo = pStartInfo
            };

            p.Start();
            Close();
        }
        private void browserOpenTimer_Tick(object sender, EventArgs e)
        {
            double seconds;

            TimeLeft -= 1;

            if (!StartAcceptingEvents)
                StartAcceptingEvents = true;

            if (!Program.Settings.AutoLaunchBrowser)
                browserOpenTimer.Enabled = false;


            seconds = (TimeLeft * browserOpenTimer.Interval) / 1000.00;

            if (!browserOpenTimer.Enabled)
                label2.Text = "When you press Enter...";
            else if (seconds < 1)
                label2.Text = "In 0 seconds...";
            else if (Math.Round(seconds) == 1)
                label2.Text = String.Format("In {0} second...", Math.Round(seconds));
            else
                label2.Text = String.Format("In {0} seconds...", Math.Round(seconds));

            if (TimeLeft < 0)
            {
                openBrowserAndQuit();
                browserOpenTimer.Enabled = false;
                return;
            }
            progressBar1.Value = TimeLeftStart - TimeLeft;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openBrowserAndQuit();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label3.Text = String.Format("Using {0}", listView1.GetSelectedItem()?.Text);
            if (!StartAcceptingEvents)
                return;
            label2.Text = "When you press Enter...";
            browserOpenTimer.Enabled = false;
            progressBar1.Enabled = false;
            progressBar1.Value = 0;
        }
    }

    // https://stackoverflow.com/questions/15091400/get-single-listview-selecteditem
    internal static class ListViewEx
    {
        internal static ListViewItem GetSelectedItem(this ListView listView1)
        {
            return (listView1.SelectedItems.Count > 0 ? listView1.SelectedItems[0] : null);
        }
    }
}
