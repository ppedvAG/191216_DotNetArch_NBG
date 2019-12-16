using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dekorator_Demo
{
    public interface IComponent // Basis für alle Element
    {
        decimal Price { get;  }
        string Description { get; }
    }

    // Hilfsklasse für die "Wrapper-Klassen" : Dekorator
    public abstract class Dekorator : IComponent
    {
        public Dekorator(IComponent parent)
        {
            this.parent = parent;
        }
        protected IComponent parent;

        public abstract decimal Price { get; }
        public abstract string Description { get; }
    }



    // Root-Element
    public class Pizza : IComponent
    {
        public decimal Price => 6.00m;
        public string Description => "Pizza ";
    }


    // Dekoratoren -> Wrapper für die Pizza:

    public class Käse : Dekorator
    {
        public Käse(IComponent parent) : base(parent)
        {
        }

        public override decimal Price => parent.Price + 0.50m;

        public override string Description => parent.Description + "Käse ";
    }
    public class Salami : Dekorator
    {
        public Salami(IComponent parent) : base(parent)
        {
        }

        public override decimal Price => parent.Price + 0.75m;

        public override string Description => parent.Description + "Salami ";
    }

    public class Schinken : Dekorator
    {
        public Schinken(IComponent parent) : base(parent)
        {
        }

        public override decimal Price => parent.Price + 0.80m;

        public override string Description => parent.Description + "Schinken ";
    }

    public class Trüffel : Dekorator
    {
        public Trüffel(IComponent parent) : base(parent)
        {
        }

        public override decimal Price => parent.Price + 8.0m;

        public override string Description => parent.Description + "Trüffel ";
    }
    public class Goldplättchen : Dekorator
    {
        public Goldplättchen(IComponent parent) : base(parent)
        {
        }

        public override decimal Price => parent.Price + 28.50m;

        public override string Description => parent.Description + "Goldplättchen ";
    }

    public class Ananas : Dekorator
    {
        public Ananas(IComponent parent) : base(parent)
        {
        }

        public override decimal Price => parent.Price + 280000.50m;

        public override string Description => parent.Description + "Hawaii  ";
    }


}
