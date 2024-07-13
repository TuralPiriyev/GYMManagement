using GYMManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GYMManagement.ViewModel
{
    public class BaseWindowViewModel : INotifyPropertyChanged
    {
        public BaseWindowViewModel(Window window) 
        {
            Window = window ?? throw new ArgumentNullException(nameof(window));
        }    
        public Window Window { get; set; }
       
       
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void NotifyChange(string name)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); 
        }
    }
}
