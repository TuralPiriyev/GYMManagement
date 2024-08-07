﻿using GYMManagement.Core.Domain.Entities;
using GYMManagement.Utils;
using GYMManagement.ViewModel;
using GYMManagement.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GYMManagement.Commands.RegisterCommands
{
    public class RegisterCommand : ICommand
    {
        private readonly RegisterWindowViewModel _windowViewModel;

        public RegisterCommand(RegisterWindowViewModel windowViewModel)
        {
            _windowViewModel = windowViewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            string password = ((PasswordBox)parameter).Password;

            User user = new User
            {
                Username = _windowViewModel.RegisterModel.Username,
                Email = _windowViewModel.RegisterModel.Email,
                PasswordHash = HashHelper.Hash(password)
            };


            ApplicationContext.DB.UserRepository.Add(user);

            LoginWindow window = new LoginWindow();
            window.DataContext = new LoginWindowViewModel(window);


            window.Show();
            _windowViewModel.Window.Close();


        }
    }
}
  
        



    

