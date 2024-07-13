using GYMManagement.Commands.UsersCommand;
using GYMManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GYMManagement.ViewModel
{
    public class SaveUsersWindowViewModel : BaseWindowViewModel
    {
        public SaveUsersWindowViewModel(Window window, UsersViewModel parent) : base(window)
        {
            this.UsersModel = new UsersModel();
            this.Parent = parent;
            this.SaveUsers = new SaveUsersCommand(this);
        }

        public UsersModel UsersModel { get; set; }

        public ICommand SaveUsers { get; set; }
        public UsersViewModel Parent { get; set; }
    }
}
