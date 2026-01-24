
using System.Runtime.Versioning;

namespace HttpRedirector
{
    [SupportedOSPlatform("windows")]
    internal static class Program
    {
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

            if (args.Count() >= 1)
                Application.Run(new Form1(args));

            else
                Application.Run(new SettingsForm());
        }
    }
}
