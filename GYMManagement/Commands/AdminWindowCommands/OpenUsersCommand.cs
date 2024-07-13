using GYMManagement.ViewModel;
using GYMManagement.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GYMManagement.Commands.AdminWindowCommands
{
    public class OpenUsersCommand : ICommand
    {
        private readonly AdminWindowViewModel _viewModel;
        public OpenUsersCommand(AdminWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            UsersControl control = new UsersControl();

            UsersViewModel usersViewModel = new UsersViewModel();
            usersViewModel.Load();

            control.DataContext = usersViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(control);
        }
    }
}
