using ppedv.TombstoneStrong.Domain;
using ppedv.TombstoneStrong.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.TombstoneStrong.Data.EF
{
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
