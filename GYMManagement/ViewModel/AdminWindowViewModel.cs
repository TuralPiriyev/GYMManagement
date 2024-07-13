using GYMManagement.Commands.AdminWindowCommands;
using GYMManagement.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GYMManagement.ViewModel
{
    public class AdminWindowViewModel : BaseWindowViewModel
    {
        public AdminWindowViewModel(AdminWindow window) : base(window)
        {
            OpenUsers = new OpenUsersCommand(this);
        }
        public ICommand OpenUsers { get; set; }
        public Grid CenterGrid { get; set; }
    }
}
