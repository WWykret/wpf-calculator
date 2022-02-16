using kalkualtor.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Data;

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
            DataTable dataTable = new DataTable();
            double result = Convert.ToDouble(dataTable.Compute(ScreenVal, ""));
            ScreenVal = result.ToString().Replace(',', '.');
        }

        private void ClearScreen(object obj)
        {
            ScreenVal = "0";
        }

        private void AddComma(object obj)
        {
            bool isAfrerDigit = int.TryParse(ScreenVal.AsSpan(ScreenVal.Length - 1), out _);
            int lastCommaIndex = ScreenVal.LastIndexOf(".");
            bool isCommaInNumber = lastCommaIndex != -1 && !new[] { '+', '-', '*', '/' }.Any(o => ScreenVal.AsSpan(lastCommaIndex).Contains(o));
        
            if (isAfrerDigit && !isCommaInNumber)
            {
                ScreenVal += ".";
            }
        }

        private void AddNumber(object obj)
        {
            if (obj is not string number) return;

            if (ScreenVal == "0")
            {
                ScreenVal = number;
            }
            else
            {
                ScreenVal += number;
            }
        }

        private void AddOperation(object obj)
        {
            if (obj is not string operation) return;

            if (int.TryParse(ScreenVal.AsSpan(ScreenVal.Length - 1), out _))
            {
                ScreenVal += operation;
            }
        }
    }
}
