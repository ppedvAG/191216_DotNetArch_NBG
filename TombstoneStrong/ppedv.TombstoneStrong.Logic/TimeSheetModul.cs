using ppedv.TombstoneStrong.Domain;
using ppedv.TombstoneStrong.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.TombstoneStrong.Logic
{
    public class TimeSheetModul : CoreModul<TimeSheet>
    {
        public TimeSheetModul(IUnitOfWork UoW) : base(UoW){}

        public override void Add(TimeSheet item) => GetRepository().Add(item);
        public override void Delete(TimeSheet item) => GetRepository().Delete(item);
        public override IEnumerable<TimeSheet> GetAll() => GetRepository().GetAll();
        public override TimeSheet GetByID(int ID) => GetRepository().GetByID(ID);
        public override void Update(TimeSheet item) => GetRepository().Update(item);

        // Spezialbefehle des Moduls:
        public virtual IEnumerable<TimeSheet> GetAllTimeSheetsForEmployee(Employee input)
        {
            return GetRepository().Query().Where(x => x.EmployeeGuid == input.Guid);
        }
    }
}
