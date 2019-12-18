using ppedv.TombstoneStrong.Data.EF;
using ppedv.TombstoneStrong.Domain;
using ppedv.TombstoneStrong.Logic;
using ppedv.TombstoneStrong.UI.WPF.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.TombstoneStrong.UI.WPF.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            // Kontrollfreak-Antipattern
            core = new Core(new EFUnitOfWork());

            GetEmployeeCommand = new RelayCommand(GetEmployees);
        }

        private readonly Core core;

        public RelayCommand GetEmployeeCommand { get; set; }
        private void GetEmployees()
        {
            Employees = core.Modul<Employee>().GetAll().ToList();
        }

        private List<Employee> employees;
        public List<Employee> Employees
        {
            get => employees;
            set => SetValue(ref employees, value);
        }

    }
}
