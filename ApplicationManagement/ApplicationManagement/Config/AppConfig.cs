using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationManagement.Config
{
    internal class AppConfig
    {

        private static Configuration GetConfig()
        {
            var configFileMap = new ExeConfigurationFileMap
            {
                ExeConfigFilename = "App.config" // Đảm bảo đường dẫn đúng
            };
            return ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
        }

        public static string Server = "Server";
        public static string Database = "Database";
        //public static string UsernameSQL = "UsernameSQL";
        //public static string PasswordSQL = "PasswordSQL";
        public static string NumberProductPerPage = "NumberProductPerPage";
        //public static string StartUpPage = "StartUpPage";

        public static string? GetValue(string key)
        {
            var config = GetConfig();
            ConfigurationManager.RefreshSection("appSettings");
            string? value = config.AppSettings.Settings[key]?.Value;
            return value;
        }


        public static void SetValue(string key, string value)
        {
            var config = GetConfig();
            //var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = config.AppSettings.Settings;

            if (settings[key] == null)
            {
                settings.Add(key, value);
            }
            else
            {
                settings[key].Value = value;
            }

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            //ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
        }

        public static string? ConnectionString()
        {
            string? result = "";

            var builder = new SqlConnectionStringBuilder();
            string? server = AppConfig.GetValue(AppConfig.Server);
            string? database = AppConfig.GetValue(AppConfig.Database);
            string? numProductPerPage = AppConfig.GetValue(AppConfig.NumberProductPerPage);
            //string? UsernameSQL = AppConfig.GetValue(AppConfig.UsernameSQL);
            //string? PasswordSQL = AppConfig.GetValue(AppConfig.PasswordSQL);


            builder.DataSource = $"{server}";
            builder.InitialCatalog = database;
            builder.TrustServerCertificate = true;
            //builder.UserID = UsernameSQL;
            //builder.Password = PasswordSQL;   
            //builder.IntegratedSecurity = true;
            builder.MultipleActiveResultSets = true;
            //builder.ConnectTimeout = 3; // s

            result = builder.ToString();
            return result;
        }
    }
}
