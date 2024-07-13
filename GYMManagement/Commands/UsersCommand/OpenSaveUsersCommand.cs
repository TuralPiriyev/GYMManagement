using GYMManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GYMManagement.Views;

namespace GYMManagement.Commands.UsersCommand
{
    public class OpenSaveUsersCommand : ICommand
    {
        private readonly UsersViewModel  _viewModel;
        private bool _isUpdate;
        

        public OpenSaveUsersCommand(UsersViewModel viewModel)
        {
            _viewModel = viewModel;
            
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }
        public OpenSaveUsersCommand SetAsUpdate()
        {
            _isUpdate = true;
            return this;
        }

        public void Execute(object? parameter)
        {
            SaveUsersWindow window = new SaveUsersWindow();
            SaveUsersWindowViewModel viewModel = new SaveUsersWindowViewModel(window, _viewModel);

            window.DataContext = viewModel;

            if (_isUpdate)
            {
                int selectedIndex = _viewModel.SelectedUsersIndex;

                viewModel.UsersModel = _viewModel.UsersModel[selectedIndex];
            }

            window.Show();
        }

    }
}
