namespace Fassade_Demo
{
    interface ILagerSystem
    {
        bool IstProduktLagernd(int id);
        void ProduktNachbestellen(int id);
    }
}
