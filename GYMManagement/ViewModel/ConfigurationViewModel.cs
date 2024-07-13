using GYMManagement.Commands.ConfigurationCommands;
using GYMManagement.Core.Domain.Enums;
using GYMManagement.Models;
using GYMManagement.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GYMManagement.ViewModel
{
    public class ConfigurationViewModel : BaseWindowViewModel
    {
        public ConfigurationViewModel(Window window) : base(window) 
        { 

           

            AppSettings currentSettings = ApplicationContext.Settings;

            Configuration = new ConfigurationModel
            {
                WindowsAuthentication = currentSettings.WindowsAuthentication,
                DbHost = currentSettings.DbHost,
                DbPort = currentSettings.DbPort,
                DbName = currentSettings.DbName,
                DbType = currentSettings.DbType,
                Username = currentSettings.Username,

               // Password = currentSettings.Password, burda binding yoxdu

            };
            
            SupportedDbTypes =  Enum.GetValues(typeof(DatabaseType)).Cast<DatabaseType>().ToList();
            Save = new SaveCommand(this);

            Cancel = new CancelCommand(this);
                }
        public ConfigurationModel Configuration { get; set; }
        public List<DatabaseType> SupportedDbTypes { get; set; }

        
        public ICommand Cancel { get; set; }
        public ICommand Save { get; set; }
    }
}
