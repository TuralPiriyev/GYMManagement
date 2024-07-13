using GYMManagement.ViewModel;
using System;
using System.Windows;
using System.Windows.Input;


namespace GYMManagement.Commands.ConfigurationCommands
{
    public class CancelCommand : ICommand
    {
        private readonly ConfigurationViewModel _viewModel;

        public CancelCommand(ConfigurationViewModel viewModel)
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
            _viewModel.Window.Close();

            Application.Current.Shutdown();
        }
    }
}
