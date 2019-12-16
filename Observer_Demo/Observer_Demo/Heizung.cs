using System;

namespace Observer_Demo
{
    public class Heizung
    {
        public bool IstAufgedreht { get; set; } = false;
        public void HeizungAufdrehen(object param)
        {
            if(IstAufgedreht)
                Console.WriteLine($"Heizung ist bereits aufgedreht: Temp ist {param}");
            else
            {
                IstAufgedreht = true;
                Console.WriteLine("Heizung wird aufgedreht ....");
            }
        }
    }
}