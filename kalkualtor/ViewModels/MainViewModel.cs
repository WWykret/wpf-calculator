using kalkualtor.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace kalkualtor.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {

        public ICommand AddNumberCommand { get; set; }

        public ICommand AddOperationCommand { get; set; }

        public ICommand AddCommaCommand { get; set; }

        public ICommand ClearScreenCommand { get; set; }

        public ICommand GetResultCommand { get; set; }

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
            AddNumberCommand = new RelayCommand(AddNumber);
            AddOperationCommand = new RelayCommand(AddOperation);
            AddCommaCommand = new RelayCommand(AddComma);
            ClearScreenCommand = new RelayCommand(ClearScreen);
            GetResultCommand = new RelayCommand(GetResult);
        }

        private void GetResult(object obj)
        {
            throw new NotImplementedException();
        }

        private void ClearScreen(object obj)
        {
            throw new NotImplementedException();
        }

        private void AddComma(object obj)
        {
            throw new NotImplementedException();
        }

        private void AddNumber(object obj)
        {
            throw new NotImplementedException();
        }

        private void AddOperation(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
