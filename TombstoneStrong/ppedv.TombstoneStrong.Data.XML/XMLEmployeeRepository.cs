using ppedv.TombstoneStrong.Domain;
using ppedv.TombstoneStrong.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ppedv.TombstoneStrong.Data.XML
{
    public class XMLEmployeeRepository : IEmployeeRepository
    {
        public XMLEmployeeRepository(ref HashSet<Employee> employees)
        {
            this.employees = employees;
        }
        private readonly HashSet<Employee> employees;

        public IEnumerable<Employee> GetAll()
        {
            return employees;
        }

        public void Add(Employee item)
        {
            employees.Add(item);
        }

        public void Delete(Employee item)
        {
            employees.Remove(item);
        }

        public TimeSheet[] GetAllTimeSheetsForEmployee(Employee input)
        {
            throw new NotImplementedException();
        }

        public Employee GetByID(int ID)
        {
            return employees.First(x => x.ID == ID);
        }

        public Employee GetEmployeeWithMostWorkhours()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Employee> Query()
        {
            return employees.AsQueryable();
        }

        public void Update(Employee item)
        {
            // ToDo IndexOf
            var dataItem = employees.FirstOrDefault(x => x.ID == item.ID);
            if (dataItem != null)
            {
                dataItem.Department = item.Department;
                dataItem.Name = item.Name;
            }
        }
    }
}
