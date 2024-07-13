﻿using GYMManagement.Commands.LoginCommands;
using GYMManagement.Commands.RegisterCommands;
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
    public class RegisterWindowViewModel : BaseWindowViewModel
    {
        public RegisterWindowViewModel(Window window) : base(window)
        {
            RegisterModel = new RegisterModel();

            Register = new RegisterCommand(this);
        }

        public RegisterModel RegisterModel { get; set; }
        public ICommand Register { get; set; }

    }
}
