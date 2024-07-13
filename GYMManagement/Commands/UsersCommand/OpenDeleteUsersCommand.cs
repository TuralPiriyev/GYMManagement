using GYMManagement.Models;
using GYMManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GYMManagement.Commands.UsersCommand
{
    public class OpenDeleteUsersCommand : ICommand
    {
        private readonly UsersViewModel _viewModel;
        public OpenDeleteUsersCommand(UsersViewModel viewModel)
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
            int index = _viewModel.SelectedUsersIndex;
            UsersModel model = _viewModel.UsersModel[index];

            MessageBoxResult result = MessageBox.Show($"Are you sure to delete '{model.Name} {model.SurName}'?", "Delete Author", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No) 
            {
                return;
            }
            ApplicationContext.DB.UsersRepository.Delete(model.Id);
            _viewModel.UsersModel.Remove(model);

        }
    }
}
