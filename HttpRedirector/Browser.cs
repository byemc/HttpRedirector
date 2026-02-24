using Microsoft.Win32;

namespace HttpRedirector
{
    internal class Browser
    {
        public string Id { get; set; }
        public string Name { get; init; }
        public string ExePath { get; init; }
        public string? IconPath { get; init; }
        public System.Drawing.Icon? Icon { get; init; }

        public static bool IsBrowser(string progId)
        {
            // Time to check RegisteredApplications!!
            // HKEY_CURRENT_USER first
            RegistryKey? userRegisteredApplications = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\RegisteredApplications");
            if (userRegisteredApplications is not null)
            { 
                string? registeredApplicationPath = (string?)userRegisteredApplications.GetValue(progId);
                if (registeredApplicationPath is not null)
                {
                    RegistryKey? userBrowserCapabilities = Registry.CurrentUser.OpenSubKey(registeredApplicationPath);
                    if (userBrowserCapabilities is not null)
                    {
                        // Check if it registers itself to HTTP.
                        var userBrowserAssociations = userBrowserCapabilities.OpenSubKey("URLAssociations");
                        if (userBrowserAssociations is not null && userBrowserAssociations.GetValueNames().Contains("http"))
                        {
                            return true;
                        }
                    }
                }
            }

            // If not... check HKEY_LOCAL_MACHINE next
            RegistryKey? machineRegisteredApplications = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\RegisteredApplications");
            if (machineRegisteredApplications is not null)
            {
                string? machineApplicationPath = (string?)machineRegisteredApplications.GetValue(progId);
                if (machineApplicationPath is not null)
                {
                    RegistryKey? machineBrowserCapabilities = Registry.LocalMachine.OpenSubKey(machineApplicationPath);
                    if (machineBrowserCapabilities is not null)
                    {
                        // Check if it registers itself to HTTP.
                        var machineBrowserAssociations = machineBrowserCapabilities.OpenSubKey("UrlAssociations");
                        if (machineBrowserAssociations is not null && machineBrowserAssociations.GetValueNames().Contains("http"))
                        {
                            return true;
                        }
                    }
                }
            }

            // Nah
            return false;
        }

        static Browser? GetBrowserFromCapabilitiesKey(RegistryKey capabilities)
        {
            var pathSplit = capabilities.Name.Split(@"\").ToList();
            var succ = pathSplit.Remove("Capabilities");
            var parentPath = Path.Join(pathSplit.ToArray());

            var id = pathSplit.Last();
            var name = Registry.GetValue(parentPath, null, "Unknown") as string;
            var execPath = Registry.GetValue(Path.Join(parentPath, "shell", "open", "command"), null, null) as string;
            var iconPath = Registry.GetValue(Path.Join(parentPath, "DefaultIcon"), null, null) as string;

            // Fallback if its an old browser (cough cough IE)
            if (execPath is null)
            {
                var smInternetKeyName = Registry.GetValue(Path.Join(parentPath, "Capabilities", "StartMenu"), "StartMenuInternet", null) as string;

                if (smInternetKeyName is null)
                    return null; // Unable to get browser details so lets pretend it doesnt exist

                var startMenuEntryLocalMachine = Registry.LocalMachine.OpenSubKey(Path.Combine(@"SOFTWARE\Clients\StartMenuInternet", smInternetKeyName));
                if (name == "Unknown")
                    name = startMenuEntryLocalMachine?.GetValue("", "Unknown") as string ?? "Unknown";
                if (execPath is null)
                    execPath = (string?)(startMenuEntryLocalMachine?.OpenSubKey(Path.Join("shell", "open", "command"))?.GetValue("", null));
                if (execPath is null) // If its STILL null then there's no saving this
                    return null;

                iconPath = (string?)(startMenuEntryLocalMachine?.OpenSubKey("DefaultIcon")?.GetValue("", null));
            }

            System.Drawing.Icon? icon=null;
            if (iconPath is not null)
            {
                var iconFile = iconPath.Split(",")[0];
                try
                {
                    if (iconPath is not null)
                        icon = System.Drawing.Icon.ExtractIcon(iconFile, int.Parse(iconPath.Split(",")[1]), false);
                }
                catch
                {
                    icon = Icon.ExtractIcon(@"C:\Windows\system32\user32.dll", 0);
                }
            }
            else
            {
                icon = Icon.ExtractIcon(@"C:\Windows\system32\user32.dll", 0);
            }

            return new Browser()
            {
                Id = id,
                Name = name,
                ExePath = execPath,
                IconPath = iconPath,
                Icon = icon
            };
        }

        public static Browser? FromProgId(string progId)
        {
            // Time to check RegisteredApplications!!
            // HKEY_CURRENT_USER first
            RegistryKey? userRegisteredApplications = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\RegisteredApplications");
            if (userRegisteredApplications is not null)
            {
                string? registeredApplicationPath = (string?)userRegisteredApplications.GetValue(progId);
                if (registeredApplicationPath is not null)
                {
                    RegistryKey? userBrowserCapabilities = Registry.CurrentUser.OpenSubKey(registeredApplicationPath);
                    if (userBrowserCapabilities is not null)
                    {
                        GetBrowserFromCapabilitiesKey(userBrowserCapabilities);
                    }
                }
            }

            // If not... check HKEY_LOCAL_MACHINE next
            RegistryKey? machineRegisteredApplications = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\RegisteredApplications");
            if (machineRegisteredApplications is not null)
            {
                string? machineApplicationPath = (string?)machineRegisteredApplications.GetValue(progId);
                if (machineApplicationPath is not null)
                {
                    RegistryKey? machineBrowserCapabilities = Registry.LocalMachine.OpenSubKey(machineApplicationPath);
                    if (machineBrowserCapabilities is not null)
                    {
                        return GetBrowserFromCapabilitiesKey(machineBrowserCapabilities);
                    }
                }
            }

            // Nah
            return null;
        }
    }
}
