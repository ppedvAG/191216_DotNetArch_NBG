using System;

namespace ppedv.TombstoneStrong.Domain.Interfaces
{
    public interface ITimeSheetRepository : IUniversalRepository<TimeSheet>
    {
        TimeSpan AvarageWorkingHoursForWorkday(DateTime workday);
        TimeSheet[] GetAllTimeSheetsForWorkday(DateTime workday);
    }
}
