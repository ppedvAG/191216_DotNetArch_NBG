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
        public Core(IUnitOfWork UoW)
        {
            this.UoW = UoW;
        }
        private IUnitOfWork UoW;

        public void GenerateTestEmployees()
        {
            Employee em1 = new Employee { ID = 0, Name = "Tom Ate", Department = "Gemüseabteilung" };
            Employee em2 = new Employee { ID = 1, Name = "Anna Nass", Department = "Obstabteilung" };
            Employee em3 = new Employee { ID = 2, Name = "Peter Silie", Department = "Gemüseabteilung" };
            Employee em4 = new Employee { ID = 3, Name = "Franz Ose", Department = "Travel" };
            Employee em5 = new Employee { ID = 4, Name = "Martha Pfahl", Department = "Travel" };

            UoW.EmployeeRepository.Add(em1);
            UoW.EmployeeRepository.Add(em2);
            UoW.EmployeeRepository.Add(em3);
            UoW.EmployeeRepository.Add(em4);
            UoW.EmployeeRepository.Add(em5);

            UoW.SaveAll();
        }
        public void GenerateTestData()
        {
            Employee em1 = new Employee { Name = "Tom Ate", Department = "Gemüseabteilung" };
            Employee em2 = new Employee { Name = "Anna Nass", Department = "Obstabteilung" };
            Employee em3 = new Employee { Name = "Peter Silie", Department = "Gemüseabteilung" };

            TimeSheet ts1 = new TimeSheet
            {
                Employee = em1,
                Start = new DateTime(2019, 12, 17, 9, 30, 00),
                End = new DateTime(2019, 12, 17, 17, 25, 00),
            };
            TimeSheet ts2 = new TimeSheet
            {
                Employee = em1,
                Start = new DateTime(2019, 12, 16, 7, 30, 00),
                End = new DateTime(2019, 12, 16, 12, 00, 00),
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

            var timeSheetRepo = UoW.GetRepository<TimeSheet>();

            timeSheetRepo.Add(ts1);
            timeSheetRepo.Add(ts2);
            timeSheetRepo.Add(ts3);
            timeSheetRepo.Add(ts4);
            timeSheetRepo.Add(ts5);
            timeSheetRepo.Add(ts6);
            timeSheetRepo.Add(ts7);
            timeSheetRepo.Add(ts8);
            timeSheetRepo.Add(ts9);

            UoW.SaveAll();
        }
        public bool IsTimeSheetEmpty()
        {
            return UoW.GetRepository<TimeSheet>().Query().Count() == 0;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return UoW.EmployeeRepository.GetAll();
        }
        public Employee GetEmployeeByID(int id) => UoW.EmployeeRepository.GetByID(id);
        public void DeleteEmployee(Employee deleteMe) => UoW.EmployeeRepository.Delete(deleteMe);
        public void UpdateEmployee(Employee updateMe) => UoW.EmployeeRepository.Update(updateMe);
        public void AddEmployee(Employee addMe) => UoW.EmployeeRepository.Add(addMe);

        public void SaveRepository() => UoW.SaveAll();
        public IEnumerable<TimeSheet> GetAllTimeSheetsForEmployee(Employee input)
        {
            return UoW.GetRepository<TimeSheet>().Query().Where(x => x.Employee.ID == input.ID);
        }
    }
}
