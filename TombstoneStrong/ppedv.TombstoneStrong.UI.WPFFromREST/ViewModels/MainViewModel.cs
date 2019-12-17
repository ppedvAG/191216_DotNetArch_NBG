using Newtonsoft.Json;
using ppedv.TombstoneStrong.Domain;
using ppedv.TombstoneStrong.UI.WPF.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
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
            GetTimeSheetsCommand = new RelayCommand(GetTimeSheets);
        }

        public RelayCommand GetTimeSheetsCommand { get; set; }
        private async void GetTimeSheets()
        {
            string json;
            using(HttpClient client = new HttpClient())
            {
                json = await client.GetStringAsync("https://localhost:44338/api/timesheets/");
            }
            TimeSheets = JsonConvert.DeserializeObject<List<TimeSheet>>(json); // core.GetAllEmployees().ToList();
        }

        private List<TimeSheet> timeSheets;
        public List<TimeSheet> TimeSheets
        {
            get => timeSheets;
            set => SetValue(ref timeSheets, value);
        }

    }
}
