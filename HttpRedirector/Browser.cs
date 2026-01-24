using Microsoft.Win32;
using System.Resources;
namespace HttpRedirector
{
    internal class Browser
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public string ExePath { get; init; }
        public string? IconPath { get; init; }
        public System.Drawing.Icon? Icon { get; init; }

        public Browser(RegistryKey key)
        {
            Id = key.Name;
            Name = key.GetValue("").ToString();
            ExePath = key.OpenSubKey("shell")?.OpenSubKey("open")?.OpenSubKey("command")?.GetValue("")?.ToString();
            IconPath = key.OpenSubKey("DefaultIcon")?.GetValue("")?.ToString();

            if (IconPath is not null)
            {
                var iconFile = IconPath.Split(",")[0];
                try
                {
                    if (IconPath is not null)
                        Icon = System.Drawing.Icon.ExtractIcon(iconFile, int.Parse(IconPath.Split(",")[1]), false);
                }
                catch
                {
                    Icon = Icon.ExtractIcon(@"C:\Windows\system32\user32.dll", 0);
                }
            } else
            {
                Icon = Icon.ExtractIcon(@"C:\Windows\system32\user32.dll", 0);

            }
        }
    }
}
