using GYMManagement.Core.Domain.Entities;
using GYMManagement.Core.Domain.Enums;
using GYMManagement.Core.Domain.Repositories;
using GYMManagement.Factories;
using GYMManagement.Settings;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMManagement
{
    public static class ApplicationContext
    {

        private static AppSettings _defaultSettings = new AppSettings
        {
            DbHost = "localhost",
            DbName = "default",
            DbPort = 1433,
            DbType = DatabaseType.SqlServer,
            Username = "",
            Password = "",
            WindowsAuthentication = true,
        };
        public static string ConfigurationPath
        {
            get
            {
                string settingsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                settingsPath = Path.Combine(settingsPath, "GYMManagement");

                if(Directory.Exists(settingsPath) == false)
                {
                    Directory.CreateDirectory(settingsPath);
                }
                return settingsPath;
            }
        }
        public static AppSettings Settings { get; private set; }
        public static  IUnitOfWork DB { get; private set; }
        public static User CurrentUsers { get;  set; }
      
        public static void Initialize()

        {
            Settings = InitializeSettings();

            DB = DbFactory.Get(Settings);

        }

        private static AppSettings InitializeSettings()
        {
            string settingsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            settingsPath = Path.Combine(settingsPath, "GYMManagement");
           AppSettingsHelper helper = new AppSettingsHelper(settingsPath);

            AppSettings appSettings = helper.GetSettings();

            if(appSettings is null)
            {
                appSettings =  _defaultSettings;
            }

            return appSettings;
        }
    }
}
