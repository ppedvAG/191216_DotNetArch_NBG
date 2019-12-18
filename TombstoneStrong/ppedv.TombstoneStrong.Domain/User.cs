using System;
using System.Collections.Generic;
using System.Text;

namespace ppedv.TombstoneStrong.Domain
{
    [Flags]
    public enum User
    {
        CanRead = 1,
        CanWrite = 2,
        CanDelete = 4,
        CanExecute = 8, // z.B. für remote proc
    }
}
