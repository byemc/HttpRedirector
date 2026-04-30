
using Microsoft.Win32;
using System.Reflection;
using System.Security.Policy;
using Windows.UI.Popups;

namespace HttpRedirector
{
    internal static class Program
    {
        internal static string? CurrentHTTPRedirectorPath => Registry.GetValue(@"HKEY_CURRENT_USER\Software\byespace\HttpRedirector\shell\open\command", null, "") as string;
        internal static string? CurrentHTTPRedirectorVersion => Registry.GetValue(@"HKEY_CURRENT_USER\Software\byespace\HttpRedirector", "InstalledVersion", "") as string;

        internal static Version RunningVersion => new Version((Application.ProductVersion ?? "0.0.0").Split("+")[0]);
        internal static Version CurrentVersion => new Version((CurrentHTTPRedirectorVersion ?? "0.0.0").Split("+")[0]);

        internal static int IsCurrentNewer()
        {
            var running = RunningVersion;
            var current = CurrentVersion;

            if (running > current)
                return 1;
            if (running < current)
                return -1;

            return 0;
        }

        internal static bool AssociationsNeedUpdating()
        {
            // Only checks if an installed version of HTTP Redirector already exists and returns the version number if it does.
            string me = Application.ExecutablePath;

            var capabilitiesShellCommand = Registry.GetValue(@"HKEY_CURRENT_USER\Software\byespace\HttpRedirector\shell\open\command", null, "") as string;
            var redirectorOpenCommand = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Classes\HttpRedirectorFile\shell\open\command", null, "") as string;
            var redirectorHttpCommand = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Classes\HttpRedirectorUrl\shell\open\command", null, "") as string;
            if (me != capabilitiesShellCommand || $"{me} \"%1\"" != redirectorOpenCommand || $"{me} \"%1\"" != redirectorHttpCommand)
            {
                return true;
            }

            return false;
        }

        internal static void UpdateAssociations()
        {
            // Update the HKEY_CURRENT_USER\Software\byespace\HttpRedirector key to use the currently
            //      executing executable as the default. It shouldn't be set during installation.
            string me = Application.ExecutablePath;
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\byespace\HttpRedirector", "", "HTTP Redirector");
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\byespace\HttpRedirector", "InstalledVersion", Application.ProductVersion);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\byespace\HttpRedirector\Capabilities", "ApplicationName", "HTTP Redirector");
            //Registry.SetValue(@"HKEY_CURRENT_USER\Software\byespace\HttpRedirector\Capabilities", "ApplicationIcon", $"{me},0");
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\byespace\HttpRedirector\Capabilities", "ApplicationDescription", "Helper application that redirects HTTP requests to other installed web browsers.");
            //Registry.SetValue(@"HKEY_CURRENT_USER\Software\byespace\HttpRedirector\DefaultIcon", "", $"{me},0");
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\byespace\HttpRedirector\shell\open\command", "", me);

            // File associations
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Classes\HttpRedirectorFile", "", "HTML File");
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Classes\HttpRedirectorFile", "URL Protocol", "");
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Classes\HttpRedirectorFile\DefaultIcon", "", "C:\\Windows\\System32\\url.dll,5"); // TODO: Use something else!!!
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Classes\HttpRedirectorFile\shell\open\command", "", $"{me} \"%1\"");

            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Classes\HttpRedirectorURL", "", "HTML File");
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Classes\HttpRedirectorURL", "URL Protocol", "");
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Classes\HttpRedirectorURL\DefaultIcon", "", "C:\\Windows\\System32\\url.dll,5"); // TODO: Use something else!!!
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Classes\HttpRedirectorURL\shell\open\command", "", $"{me} \"%1\"");
        
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\byespace\HttpRedirector\Capabilities\FileAssociations", ".htm", "HttpRedirectorFile");
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\byespace\HttpRedirector\Capabilities\FileAssociations", ".html", "HttpRedirectorFile");
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\byespace\HttpRedirector\Capabilities\FileAssociations", ".xhtml", "HttpRedirectorFile");
            
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\byespace\HttpRedirector\Capabilities\URLAssociations", "http", "HttpRedirectorUrl");
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\byespace\HttpRedirector\Capabilities\URLAssociations", "https", "HttpRedirectorUrl");
            //Registry.SetValue(@"HKEY_CURRENT_USER\Software\byespace\HttpRedirector\Capabilities\URLAssociations", "ftp", "HttpRedirectorUrl");

            Registry.SetValue(@"HKEY_CURRENT_USER\Software\RegisteredApplications", "ByespaceHttpRedirector", "Software\\byespace\\HttpRedirector\\Capabilities");
        }

        internal static void RemoveAssociations()
        {
            var regKeyA = Registry.CurrentUser.OpenSubKey(@"Software\byespace", true);
            regKeyA?.DeleteSubKeyTree("HttpRedirector", false);

            var regKeyB = Registry.CurrentUser.OpenSubKey(@"Software\Classes", true);
            regKeyB?.DeleteSubKeyTree("HttpRedirectorFile", false);
            regKeyB?.DeleteSubKeyTree("HttpRedirectorURL", false);

            var regKeyC = Registry.CurrentUser.OpenSubKey(@"Software\RegisteredApplications", true);
            regKeyC?.DeleteValue("ByespaceHttpRedirector", false);
        }

        internal static Settings Settings;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Settings = Settings.Get();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetHighDpiMode(HighDpiMode.PerMonitor);

            if (args.Count() >= 1)
                Application.Run(new Form1(args));

            else
                Application.Run(new SettingsForm());
        }
    }
}
