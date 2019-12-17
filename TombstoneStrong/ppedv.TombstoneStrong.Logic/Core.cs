using ppedv.TombstoneStrong.Domain;
using ppedv.TombstoneStrong.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ppedv.TombstoneStrong.Logic
{
    public class Core
    {
        public Core(IRepository repository)
        {
            this.repository = repository;
        }
        private IRepository repository;

        public void GenerateTestData()
        {
            Employee em1 = new Employee { Name = "Tom Ate", Department = "Gemüseabteilung" };
            Employee em2 = new Employee { Name = "Anna Nass", Department = "Obstabteilung" };
            Employee em3 = new Employee { Name = "Peter Silie", Department = "Gemüseabteilung" };

            TimeSheet ts1 = new TimeSheet
            {
                Employee = em1,
                Start = new DateTime(2019, 12, 17, 9, 30, 00),
                End = new DateTime(2019, 12,17, 17, 25, 00),
            };
            TimeSheet ts2 = new TimeSheet
            {
                Employee = em1,
                Start = new DateTime(2019, 12, 16, 7, 30, 00),
                End = new DateTime(2019, 12 ,16, 12, 00, 00),
            };
            TimeSheet ts3 = new TimeSheet
            {
                Employee = em1,
                Start = new DateTime(2019, 12, 15, 8, 11, 00),
                End = new DateTime(2019, 12, 15, 15, 12, 00),
            };

            TimeSheet ts4 = new TimeSheet
            {
                Employee = em2,
                Start = new DateTime(2019, 12, 17, 20, 00, 00),
                End = new DateTime(2019, 12, 18, 6, 00, 00),
            };
            TimeSheet ts5 = new TimeSheet
            {
                Employee = em2,
                Start = new DateTime(2019, 12, 18, 19, 30, 00),
                End = new DateTime(2019, 12, 19, 4, 59, 00),
            };
            TimeSheet ts6 = new TimeSheet
            {
                Employee = em2,
                Start = new DateTime(2019, 12, 19, 23, 00, 00),
                End = new DateTime(2019, 12, 20, 9, 35, 00),
            };

            TimeSheet ts7 = new TimeSheet
            {
                Employee = em3,
                Start = new DateTime(2019, 12, 17, 12, 00, 00),
                End = new DateTime(2019, 12, 17, 14, 00, 00),
            };
            TimeSheet ts8 = new TimeSheet
            {
                Employee = em3,
                Start = new DateTime(2019, 12, 18, 15, 30, 00),
                End = new DateTime(2019, 12, 18, 17, 40, 00),
            };
            TimeSheet ts9 = new TimeSheet
            {
                Employee = em3,
                Start = new DateTime(2019, 12, 19, 8, 00, 00),
                End = new DateTime(2019, 12, 19, 9, 36, 00),
            };

            repository.Add(ts1);
            repository.Add(ts2);
            repository.Add(ts3);
            repository.Add(ts4);
            repository.Add(ts5);
            repository.Add(ts6);
            repository.Add(ts7);
            repository.Add(ts8);
            repository.Add(ts9);

            repository.Save();
        }
        public bool IsTimeSheetEmpty()
        {
            return repository.Query<TimeSheet>().Count() == 0;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return repository.GetAll<Employee>();
        }
        public IEnumerable<TimeSheet> GetAllTimeSheetsForEmployee(Employee input)
        {
            return repository.Query<TimeSheet>().Where(x => x.Employee.ID == input.ID);
        }
    }
}
