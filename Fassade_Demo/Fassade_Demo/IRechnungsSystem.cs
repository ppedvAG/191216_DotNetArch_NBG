namespace Fassade_Demo
{
    interface IRechnungsSystem
    {
        bool HatOffeneRechnungen(int id);
        void BezahlvorgangStarten(int id);
    }
}
