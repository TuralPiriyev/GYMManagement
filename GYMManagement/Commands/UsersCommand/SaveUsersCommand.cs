using GYMManagement.Core.Domain.Entities;
using GYMManagement.Models;
using GYMManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GYMManagement.Commands.UsersCommand
{
    public class SaveUsersCommand : ICommand
    {
        private readonly SaveUsersWindowViewModel _viewModel;
       

        public SaveUsersCommand(SaveUsersWindowViewModel viewModel)
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
            UsersModel model = _viewModel.UsersModel;

           Users users = new Users
            {
                Id = model.Id,
                Name = model.Name,
                SurName = model.SurName,
                PhoneNumber = model.PhoneNumber,
                RegistrationStartDate = model.RegistrationStartDate,
                RegistrationFinalDate = model.RegistrationFinalDate,
            };
            if(users.Id>0)
            {
                ApplicationContext.DB.UsersRepository.Update(users);
            }
            else
            {
                ApplicationContext.DB.UsersRepository.Add(users);
                model.Id = users.Id;

                _viewModel.Parent.UsersModel.Add(model);
            }
            _viewModel.Window.Close();
        }
    }
}
