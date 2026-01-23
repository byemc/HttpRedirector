using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace HttpRedirector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            RegistryKey userKeys = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Clients\StartMenuInternet");
            RegistryKey localKeys = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Clients\StartMenuInternet");

            var browserKeys = new Dictionary<string, Browser>();
            
            foreach (var key in userKeys.GetSubKeyNames())
            {
                var reg = Registry.CurrentUser.OpenSubKey($"SOFTWARE\\Clients\\StartMenuInternet").OpenSubKey(key);
                if (reg.OpenSubKey("Capabilities") == null)
                    continue;

                var browser = new Browser(reg);
                try
                {
                    browserKeys.Add(key, browser);
                }
                catch (ArgumentException)
                {
                    continue;
                }

                browserIconList.Images.Add(browser.Icon);
                browser.IconKey = browserIconList.Images.Count - 1;
            }
            foreach (var key in localKeys.GetSubKeyNames())
            {
                var reg = Registry.LocalMachine.OpenSubKey($"SOFTWARE\\Clients\\StartMenuInternet").OpenSubKey(key);

                var browser = new Browser(reg);
                try
                {
                    browserKeys.Add(key, browser);
                }
                catch (ArgumentException)
                {
                    continue;
                }

                browser.IconKey = browserIconList.Images.Count;
                browserIconList.Images.Add(browser.Icon.ToBitmap());
            }
            
            foreach(var browser in browserKeys)
            {
                var item = new ListViewItem();
                item.Text = browser.Value.Name;
                item.ImageIndex = browser.Value.IconKey ?? 0;
                listView1.Items.Add(item);
            }
            listView1.Refresh();
            debugLabel.Text = $"Images: {browserIconList.Images.Count.ToString()}\n" +
                $"LV Items: {listView1.Items.Count}";
        }
    }
}
