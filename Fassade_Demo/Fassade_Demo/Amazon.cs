using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fassade_Demo
{
    class Amazon
    {
        public Amazon(ILagerSystem ls, IRechnungsSystem rs, IVersandSystem vs, IBenachrichtigungsSystem es)
        {
            this.ls = ls;
            this.rs = rs;
            this.vs = vs;
            this.es = es;
        }

        // Dash-Button
        private ILagerSystem ls;
        private IRechnungsSystem rs;
        private IVersandSystem vs;
        private IBenachrichtigungsSystem es;

        public void Bestellen(int KundenID,int Artikelnummer)
        {
            if (rs.HatOffeneRechnungen(KundenID) == false)
            {
                if (ls.IstProduktLagernd(Artikelnummer))
                {
                    rs.BezahlvorgangStarten(KundenID);
                    es.SendeBestätigung();
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
