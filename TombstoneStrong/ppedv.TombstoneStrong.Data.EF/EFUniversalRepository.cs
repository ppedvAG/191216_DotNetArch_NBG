using ppedv.TombstoneStrong.Domain;
using ppedv.TombstoneStrong.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ppedv.TombstoneStrong.Data.EF
{
    public class EFUniversalRepository<T> : IUniversalRepository<T> where T : Entity
    {
        public EFUniversalRepository(EFContext context)
        {
            this.context = context;
        }
        protected readonly EFContext context;

        public void Add(T item)
        {
            context.Set<T>().Add(item);
        }

        public void Delete(T item)
        {
            context.Set<T>().Remove(item);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToArray();
        }

        public T GetByID(int ID)
        {
            return context.Set<T>().Find(ID);
        }

        public IQueryable<T> Query()
        {
            return context.Set<T>();
        }

        public void Update(T item)
        {
            context.Set<T>().Update(item);
        }
    }

    public class EFEmployeeRepository : EFUniversalRepository<Employee>, IEmployeeRepository
    {
        public EFEmployeeRepository(EFContext context) : base(context){}

        public TimeSheet[] GetAllTimeSheetsForEmployee(Employee input)
        {
            return context.TimeSheet.Where(x => x.Employee.ID == input.ID).ToArray();
        }

        public Employee GetEmployeeWithMostWorkhours()
        {
            // ToDO: alles zu einem einzigen LINQ - Befehl verarbeiten 😎
            double maxWorkHours = 0;
            Employee result = null;

            foreach (Employee employee in context.TimeSheet.Select(x => x.Employee)
                                                           .Distinct())
            {
                var totalWorkHours = GetAllTimeSheetsForEmployee(employee).Sum(x => (x.End - x.Start).TotalMinutes);
                if(totalWorkHours > maxWorkHours)
                {
                    maxWorkHours = totalWorkHours;
                    result = employee;
                }
            }

            return result;
        }
    }
}
