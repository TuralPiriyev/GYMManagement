using GYMManagement.Commands.UsersCommand;
using GYMManagement.Core.Domain.Entities;
using GYMManagement.Models;
using GYMManagement.ViewModel.Abstract;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;


namespace GYMManagement.ViewModel
{
    public class UsersViewModel : IDataLoader
    {
        public UsersViewModel()
        {
            this.OpenAddUsers = new OpenSaveUsersCommand(this);
            this.OpenUpdateUsers = new OpenSaveUsersCommand(this).SetAsUpdate();
            this.OpenDeleteUsers = new OpenDeleteUsersCommand(this);
        }

      public ObservableCollection<UsersModel> UsersModel { get; set; }
        public ICommand OpenAddUsers { get; set; }
        public ICommand OpenUpdateUsers { get; set; }   
        public ICommand OpenDeleteUsers { get; set; }   
        public int SelectedUsersIndex { get; set; }
        public void Load()
        {
            List<Users> users = ApplicationContext.DB.UsersRepository.Get();

            UsersModel = new ObservableCollection<UsersModel>();

            foreach(var u in users)
            {
                UsersModel model = new UsersModel
                {
                    Id = u.Id,
                    Name = u.Name,
                    SurName = u.SurName,
                    PhoneNumber = u.PhoneNumber,
                    RegistrationStartDate = u.RegistrationStartDate,
                    RegistrationFinalDate = u.RegistrationFinalDate
                };

                UsersModel.Add(model); 

            }
             


        }
    }
}
