using ProsysTestApp.Core.Helpers;
using System.Text.Json.Serialization;

namespace ProsysTestApp.Core.Settings
{
    public class AppSettings
    {
        private static AppSettings _instance;
        public static AppSettings Instance
        {
            get
            {
                if (_instance is null)
                    _instance = CreateInstance();
                return _instance;
            }
        }
        public AppSettings()
        {

        }
        private static AppSettings CreateInstance()
        {
            const string directoryName = @"\settings\app.settings.json";
            string finalDirectory = CurrentDirectory + directoryName;
            var json = TextFileReaderHelper.ReadAsStringAsync(finalDirectory).Result;
            return JsonSerializerHelper.Deserialize<AppSettings>(json)!;
        }

        [JsonIgnore]
        public static string CurrentDirectory => AppDomain.CurrentDomain.BaseDirectory;


        public DatabaseSettings DatabaseSetting { get; set; }


        public class DatabaseSettings
        {
            public string ApiDbConnectionString { get; set; }
        }
    }
}
