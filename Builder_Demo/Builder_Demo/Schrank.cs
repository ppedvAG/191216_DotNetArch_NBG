using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Demo
{
    public enum Oberflächenart { Unbehandelt, Gewachst, Lackiert }
    public class Schrank
    {
        private Schrank()
        {

        }

        public int AnzahlTüren { get; set; }
        public int AnzahlBöden { get; set; }
        public Oberflächenart Oberfläche { get; set; }
        public string Farbe { get; set; }
        public bool Kleiderstange { get; set; }

        public static Builder BaueSchrank() => new Builder();

        public class Builder
        {
            public Builder()
            {
                zuBauenderSchrank = new Schrank();
            }
            private Schrank zuBauenderSchrank;

            public Builder MitTüren(int AnzahlTüren)
            {
                if (AnzahlTüren >= 2 && AnzahlTüren <= 7)
                    zuBauenderSchrank.AnzahlTüren = AnzahlTüren;
                else
                    throw new ArgumentException("Die Anzahl der Türen ist ungültig");

                return this;
            }
            public Builder MitBöden(int AnzahlBöden)
            {
                if (AnzahlBöden >= 0 && AnzahlBöden <= 6)
                    zuBauenderSchrank.AnzahlBöden = AnzahlBöden;
                else
                    throw new ArgumentException("Die Anzahl der Böden ist ungültig");

                return this;
            }
            public Builder MitOberfläche(Oberflächenart Oberfläche)
            {
                zuBauenderSchrank.Oberfläche = Oberfläche;
                return this;
            }
            public Builder InFarbe(string Farbe)
            {
                if (zuBauenderSchrank.Oberfläche == Oberflächenart.Lackiert)
                    zuBauenderSchrank.Farbe = Farbe;
                else
                    throw new InvalidOperationException("Nur ein lackierter Schrank darf eine Oberflächenfarbe haben");
                return this;
            }
            public Builder MitKleiderstange(bool Kleiderstange)
            {
                if (zuBauenderSchrank.AnzahlBöden >= 1 && Kleiderstange == true)
                    zuBauenderSchrank.Kleiderstange = true;
                else if (zuBauenderSchrank.AnzahlBöden < 1)
                    zuBauenderSchrank.Kleiderstange = false;
                else if (Kleiderstange == false)
                    zuBauenderSchrank.Kleiderstange = false;
                else
                    throw new InvalidOperationException("In der aktuellen Konfiguration ist das Einbauen der Kleiderstange nicht erlaubt !");
                return this;
            }

            public Schrank Erstellen()
            {
                // ToDo: abschließende Validierung
                return zuBauenderSchrank;
            }
        }


    }
}
