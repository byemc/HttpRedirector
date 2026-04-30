
using Microsoft.Win32;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace HttpRedirector
{
    public class Settings
    {
        public string? DefaultBrowser { get; set; }
        public bool AutoLaunchBrowser { get; set; } = true;
        public int AutoLaunchSeconds { get; set; } = 5;

        public static Settings Get()
        {
            // Load self from an XML file
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "byespace", "HttpRedirector", "Settings.xml");
            Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "byespace", "HttpRedirector"));
            using var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
            XmlSerializer serializer = new(typeof(Settings));

            Settings? settings = default;
            try
            {
                settings = (Settings?)serializer.Deserialize(fs);
            } catch (InvalidOperationException)
            {
                settings = null;
            }

            if (settings is null)
            {
                settings = new();
                fs.SetLength(0);
                serializer.Serialize(fs, settings);
            }

            return settings;
        }

        public void Save()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "byespace", "HttpRedirector", "Settings.xml");
            using var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
            XmlSerializer serializer = new(typeof(Settings));
            fs.SetLength(0); // Fixes a bug where the </Settings> at the end of the file stays because the file is never deleted
            serializer.Serialize(fs, this);
        }

        public void Delete()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "byespace", "HttpRedirector", "Settings.xml");
            File.Delete(path);
        }

        // Not really related to Settings but i guess it belongs here
        public static bool IsDefaultBrowser()
        {
            var path = @"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\Shell\Associations\UrlAssociations\http\UserChoice";
            var progId = Registry.GetValue(path, "ProgId", null) as string;
            if (progId == "HttpRedirectorUrl")
                return true;
            return false;
        }

        //internal enum Errors : ulong
        //{
        //    ERR_CONFIG_FOLDER_NOT_EXISTING
        //}
    }
}
