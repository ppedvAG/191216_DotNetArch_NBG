using Domain;
using System;
using System.Composition;

namespace MEF_Demo
{
    [Export(typeof(IRechner))]
    public class TrumpRechner : IRechner
    {
        public int Add(int z1, int z2) => z1 + z2 + 5;
    }
}
