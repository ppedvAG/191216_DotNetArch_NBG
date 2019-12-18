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
        public Core(params IUnitOfWork[] UoW)
        {
            this.UoW = UoW;
        }
        private readonly IUnitOfWork[] UoW;

        // Factory-Method
        private IUnitOfWork GetUnitOfWorkFor<T>() where T : Entity
        {
            // ToDo: Was wenn es 2 UoWs für "Employee" gibt ?
            // Entweder beides (MergedUoW)
            // Oder Attributen "Priority"
            var result = UoW.FirstOrDefault(x => x.SupportedEntities.Contains(typeof(T)));

            if (result == null)
                throw new InvalidOperationException($"Es gibt kein UoW für den Datentyp {typeof(T)}");
            else
                return result;
        }

        public void GenerateTestData()
        {
            // XML
            Employee em1 = new Employee { ID = 1, Name = "Tom Ate", Department = "Gemüseabteilung",Guid = Guid.NewGuid().ToString() };
            Employee em2 = new Employee { ID = 2, Name = "Anna Nass", Department = "Obstabteilung", Guid = Guid.NewGuid().ToString() };
            Employee em3 = new Employee { ID = 3, Name = "Peter Silie", Department = "Gemüseabteilung", Guid = Guid.NewGuid().ToString() };

            // EF
            TimeSheet ts1 = new TimeSheet
            {
                // Employee = em1,
                EmployeeGuid = em1.Guid,
                Start = new DateTime(2019, 12, 17, 9, 30, 00),
                End = new DateTime(2019, 12, 17, 17, 25, 00),
            };
            TimeSheet ts2 = new TimeSheet
            {
                //Employee = em1,
                EmployeeGuid = em1.Guid,
                Start = new DateTime(2019, 12, 16, 7, 30, 00),
                End = new DateTime(2019, 12, 16, 12, 00, 00),
            };
            TimeSheet ts3 = new TimeSheet
            {
                //Employee = em1,
                EmployeeGuid = em1.Guid,
                Start = new DateTime(2019, 12, 15, 8, 11, 00),
                End = new DateTime(2019, 12, 15, 15, 12, 00),
            };

            TimeSheet ts4 = new TimeSheet
            {
                // Employee = em2,
                EmployeeGuid = em2.Guid,

                Start = new DateTime(2019, 12, 17, 20, 00, 00),
                End = new DateTime(2019, 12, 18, 6, 00, 00),
            };
            TimeSheet ts5 = new TimeSheet
            {
                EmployeeGuid = em2.Guid,
                //Employee = em2,
                Start = new DateTime(2019, 12, 18, 19, 30, 00),
                End = new DateTime(2019, 12, 19, 4, 59, 00),
            };
            TimeSheet ts6 = new TimeSheet
            {
                EmployeeGuid = em2.Guid,
                // Employee = em2,
                Start = new DateTime(2019, 12, 19, 23, 00, 00),
                End = new DateTime(2019, 12, 20, 9, 35, 00),
            };

            TimeSheet ts7 = new TimeSheet
            {
                EmployeeGuid = em3.Guid,
                // Employee = em3,
                Start = new DateTime(2019, 12, 17, 12, 00, 00),
                End = new DateTime(2019, 12, 17, 14, 00, 00),
            };
            TimeSheet ts8 = new TimeSheet
            {
                EmployeeGuid = em3.Guid,
                // Employee = em3,
                Start = new DateTime(2019, 12, 18, 15, 30, 00),
                End = new DateTime(2019, 12, 18, 17, 40, 00),
            };
            TimeSheet ts9 = new TimeSheet
            {
                EmployeeGuid = em3.Guid,
                // Employee = em3,
                Start = new DateTime(2019, 12, 19, 8, 00, 00),
                End = new DateTime(2019, 12, 19, 9, 36, 00),
            };

            var timeSheetRepo = GetUnitOfWorkFor<TimeSheet>().GetRepository<TimeSheet>();

            timeSheetRepo.Add(ts1);
            timeSheetRepo.Add(ts2);
            timeSheetRepo.Add(ts3);
            timeSheetRepo.Add(ts4);
            timeSheetRepo.Add(ts5);
            timeSheetRepo.Add(ts6);
            timeSheetRepo.Add(ts7);
            timeSheetRepo.Add(ts8);
            timeSheetRepo.Add(ts9);

            GetUnitOfWorkFor<TimeSheet>().SaveAll();

            GetUnitOfWorkFor<Employee>().EmployeeRepository.Add(em1);
            GetUnitOfWorkFor<Employee>().EmployeeRepository.Add(em2);
            GetUnitOfWorkFor<Employee>().EmployeeRepository.Add(em3);

            GetUnitOfWorkFor<Employee>().SaveAll();
        }
        public bool IsTimeSheetEmpty()
        {
            return GetUnitOfWorkFor<TimeSheet>().GetRepository<TimeSheet>().Query().Count() == 0;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return GetUnitOfWorkFor<Employee>().EmployeeRepository.GetAll();
        }
        public Employee GetEmployeeByID(int id) => GetUnitOfWorkFor<Employee>().EmployeeRepository.GetByID(id);
        public void DeleteEmployee(Employee deleteMe) => GetUnitOfWorkFor<Employee>().EmployeeRepository.Delete(deleteMe);
        public void UpdateEmployee(Employee updateMe) => GetUnitOfWorkFor<Employee>().EmployeeRepository.Update(updateMe);
        public void AddEmployee(Employee addMe) => GetUnitOfWorkFor<Employee>().EmployeeRepository.Add(addMe);

        public void SaveAllUoW()
        {
            foreach (var item in UoW)
                item.SaveAll();
        }
        public IEnumerable<TimeSheet> GetAllTimeSheetsForEmployee(Employee input)
        {
            return GetUnitOfWorkFor<TimeSheet>().GetRepository<TimeSheet>().Query().Where(x => x.EmployeeGuid == input.Guid);
        }

        public TimeSheet[] GetAllTimeSheets()
        {
            var timeSheets = GetUnitOfWorkFor<TimeSheet>().GetRepository<TimeSheet>().GetAll();
            return timeSheets.ToArray();
        }
    }
}
