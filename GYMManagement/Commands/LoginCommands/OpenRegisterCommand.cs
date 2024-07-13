using GYMManagement.ViewModel;
using GYMManagement.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GYMManagement.Commands.LoginCommands
{
    public class OpenRegisterCommand : ICommand
    {
        private readonly LoginWindowViewModel _viewModel;

        public OpenRegisterCommand(LoginWindowViewModel viewModel)
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
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.DataContext = new RegisterWindowViewModel(registerWindow);

            registerWindow.Show();
            _viewModel.Window.Close();


        }
    }
}
