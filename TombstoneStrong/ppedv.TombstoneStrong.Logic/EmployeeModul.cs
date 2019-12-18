using ppedv.TombstoneStrong.Domain;
using ppedv.TombstoneStrong.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ppedv.TombstoneStrong.Logic
{
    public class EmployeeModul : CoreModul<Employee>
    {
        public EmployeeModul(IUnitOfWork UoW) : base(UoW){}

        public override void Add(Employee item)
        {
            UoW.EmployeeRepository.Add(item);
        }

        public override void Delete(Employee item)
        {
            UoW.EmployeeRepository.Delete(item);
        }

        public override IEnumerable<Employee> GetAll()
        {
            return UoW.EmployeeRepository.GetAll();
        }

        public override Employee GetByID(int ID)
        {
            return UoW.EmployeeRepository.GetByID(ID);
        }

        public override void Update(Employee item)
        {
            UoW.EmployeeRepository.Update(item);
        }
    }
}
