using Domain.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEF_Demo.Framework
{
    [Export(typeof(IRechner))]
    public class EchterRechner : IRechner
    {
        public int Add(int z1, int z2)
        {
            return z1 + z2;
        }

        public int Sub(int z1, int z2)
        {
            return z1 - z2;
        }

        public int Mul(int z1, int z2) => z1 * z2;
    }
}
