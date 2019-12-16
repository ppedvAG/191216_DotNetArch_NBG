using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fassade_Demo
{
    class Amazon
    {
        // Dash-Button
        private LagerSystem ls = new LagerSystem();
        private RechnungsSystem rs = new RechnungsSystem();
        private DHLVersandSystem vs = new DHLVersandSystem();
        private EmailSystem es = new EmailSystem();

        public void Bestellen(int KundenID,int Artikelnummer)
        {
            if (rs.HatOffeneRechnungen(KundenID) == false)
            {
                if (ls.IstProduktLagernd(Artikelnummer))
                {
                    rs.BezahlvorgangStarten(KundenID);
                    es.BestätigungsmailVersenden();
                    vs.VersendeProdukt();
                }
                else
                {
                    Console.WriteLine("Das Produkt ist in ihrem Land nicht verfügbar");
                }
            }
            else
                Console.WriteLine("BEZAHL ERST DEINEN DECKEL !!!!!!!");
        }

        // ToDo: Schicht greift auf andere Schicht zu (Strategie-Pattern)
    }
}
