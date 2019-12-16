using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Demo
{
    public interface IEssen
    {
        void Beschreibung();
    }

    public class Restaurant
    {
        public IEssen GibEssen()
        {
            return GibEssen(DateTime.Now);
        }

        public IEssen GibEssen(DateTime uhrzeit)
        {
            switch (uhrzeit.Hour)
            {
                case int h when h >= 6 && h < 11:
                    return new Frühstück();
                case int h when h >= 11 && h < 16:
                    return new Mittagessen();
                case int h when h >= 16 && h < 22:
                    return new Abendessen();
                default:
                    return new KeinEssen();
            }
        }
    }
}
