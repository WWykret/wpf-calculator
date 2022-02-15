using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace kalkualtor.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {

        private string _screenVal = "";
        public string ScreenVal
        {
            get => _screenVal;
            set
            {
                _screenVal = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public MainViewModel()
        {
            ScreenVal = "0";
        }
    }
}
