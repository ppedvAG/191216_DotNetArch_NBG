namespace Observer_Demo
{
    public class TempSensor
    {
        public TempSensor(double min, double max)
        {
            this.min = min;
            this.max = max;
        }
        private double min;
        private double max;

        private double currentTemp;
        public double CurrentTemp
        {
            get => currentTemp;
            set
            {
                if (value > max)
                    Observer.Publish("Heiß", value);
                else if (value < min)
                    Observer.Publish("Kalt", value);

                currentTemp = value;

            }

        }

    }
}