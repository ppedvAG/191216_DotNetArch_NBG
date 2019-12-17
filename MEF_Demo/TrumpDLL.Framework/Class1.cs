using Domain.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrumpDLL.Framework
{
    [Export(typeof(IRechner))]
    public class TrumpRechner : IRechner
    {
        public int Add(int z1, int z2) => z1 + z2 + 5;
    }
}
