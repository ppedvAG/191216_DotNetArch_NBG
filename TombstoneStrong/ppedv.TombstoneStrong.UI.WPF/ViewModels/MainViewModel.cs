using ppedv.TombstoneStrong.Data.EF;
using ppedv.TombstoneStrong.Domain;
using ppedv.TombstoneStrong.Logic;
using ppedv.TombstoneStrong.UI.WPF.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.TombstoneStrong.UI.WPF.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            // Kontrollfreak-Antipattern
            core = new Core(new EFRepository(new EFContext()));

            GetEmployeeCommand = new RelayCommand(GetEmployees);
        }

        private readonly Core core;

        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand GetEmployeeCommand { get; set; }
        private void GetEmployees()
        {
            Employees = core.GetAllEmployees().ToList();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Employees)));
        }
        public List<Employee> Employees { get; set; }

    }
}
