using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Demo
{
    public abstract class Aufgabe
    {
        public string Titel { get; set; }
        public abstract TimeSpan Dauer { get; set; }
        public abstract bool IstErledigt { get; set; }
    }

    public class Einzelaufgabe : Aufgabe
    {
        public string Person { get; set; }
        public override bool IstErledigt { get; set; }
        public override TimeSpan Dauer { get; set; }
    }

    public class Aufgabenliste : Aufgabe
    {
        public List<Aufgabe> Unteraufgaben { get; set; } = new List<Aufgabe>();

        public string[] Personen
        {
            get => Unteraufgaben.Where(x => x is Einzelaufgabe)
                                .Cast<Einzelaufgabe>()
                                .Select(x => x.Person)
                                .Distinct()
                                .ToArray();
        }
        public override bool IstErledigt
        {
            get
            {
                return Unteraufgaben.All(x => x.IstErledigt == true);
            }
            set
            {
                foreach (Aufgabe unerledigt in Unteraufgaben.Where(x => x.IstErledigt == false))
                {
                    unerledigt.IstErledigt = true;
                }
            }
        }

        public override TimeSpan Dauer
        {
            get
            {
               return TimeSpan.FromSeconds(Unteraufgaben.Select(x => x.Dauer.TotalSeconds)
                                                        .Sum());
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }

}
