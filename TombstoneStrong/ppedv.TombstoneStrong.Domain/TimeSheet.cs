using System;

namespace ppedv.TombstoneStrong.Domain
{
    public class TimeSheet : Entity
    {
        public virtual Employee Employee { get; set; }
        public string EmployeeGuid { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
