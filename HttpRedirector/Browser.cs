using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRedirector
{
    internal class Browser
    {
        public string Name { get; init; }
        public string ExePath { get; init; }
        public string? IconPath { get; init; }
        public System.Drawing.Icon? Icon { get; init; }

        public int? IconKey { get; set; }

        public Browser(RegistryKey key)
        {
            Name = key.GetValue("").ToString();
            ExePath = key.OpenSubKey("shell")?.OpenSubKey("open")?.OpenSubKey("command")?.GetValue("")?.ToString();
            IconPath = key.OpenSubKey("DefaultIcon")?.GetValue("")?.ToString();
            if (IconPath is not null)
                Icon = System.Drawing.Icon.ExtractIcon(IconPath.Split(",")[0], int.Parse(IconPath.Split(",")[1]), false);
        }
    }
}
