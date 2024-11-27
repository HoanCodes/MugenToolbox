using Newtonsoft.Json;
using System.IO;

namespace IkemenToolbox.Helpers
{
    public static class Cache
    {
        public static AppSettings Settings { get; set; }
        private const string _cachePath = ".cache/";
        private const string _settingsPath = _cachePath + "settings.json";

        public static void Initialize()
        {
            if (!Directory.Exists(_cachePath))
            {
                Directory.CreateDirectory(_cachePath);
            }

            if (!File.Exists(_settingsPath))
            {
                Settings = new AppSettings();
                File.WriteAllText(_settingsPath, JsonConvert.SerializeObject(Settings));
            }
            else
            {
                Settings = JsonConvert.DeserializeObject<AppSettings>(File.ReadAllText(_settingsPath));
            }
        }

        public static void Save()
        {
            File.WriteAllText(_settingsPath, JsonConvert.SerializeObject(Settings));
        }

        public class AppSettings
        {
            public string LastDefinitionPath { get; set; }
        }
    }
}