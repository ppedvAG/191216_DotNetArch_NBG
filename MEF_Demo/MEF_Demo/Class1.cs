using System;

namespace MEF_Demo
{
    public class Taschenrechner
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
