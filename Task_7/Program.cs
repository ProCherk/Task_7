using System;
using System.Collections.Generic;
using System.IO;

namespace Task_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            WeatherDays days = new WeatherDays();
            WeatherParametersDay day = new WeatherParametersDay();

            day.GetDayTemperature_File();
            day.OutputDayTemperature();

            days.NumberCloudyDays();
            days.OutputConsoleNumberCloudyDays();
        }
    }

    class WeatherDays
    {
        WeatherParametersDay day = new WeatherParametersDay();

        private int cloudyDays = 0;
        public int CloudyDays
        {
            get { return cloudyDays; }
            set { cloudyDays = value; }
        }

        private int percipitationDays = 0;
        public int PercipitationDays
        {
            get { return percipitationDays; }
            set { percipitationDays = value; }
        }

        public int NumberCloudyDays()
        {
            foreach (KeyValuePair<int, int> i in day.weatherTypePerDay)
            {
                if (i.Value == 7)
                    cloudyDays++; 
            }

            Console.WriteLine();
            return cloudyDays;
        }

        public void OutputConsoleNumberCloudyDays()
        {
            Console.WriteLine($"Похмурих днів у травні 2019 року було - {cloudyDays}");
            Console.WriteLine();
        }
    }


    class WeatherParametersDay
    {
        private Dictionary<int, int> temperaturePerDay = new Dictionary<int, int> { };
        public Dictionary<int, int> TemperaturePerDay
        {
            get { return temperaturePerDay; }
            set { temperaturePerDay = value; }
        }

        private Dictionary<int, int> temperaturePerNight = new Dictionary<int, int>
        {
            { 1, 9 },
            { 2, 6 },
            { 3, 10 },
            { 4, 10 },
            { 5, 9 },
            { 6, 12 },
            { 7, 12 },
            { 8, 6 },
            { 9, 6 },
            { 10, 6 },
            { 11, 9 },
            { 12, 9 },
            { 13, 10 },
            { 14, 12 },
            { 15, 13 },
            { 16, 13 },
            { 17, 17 },
            { 18, 19 },
            { 19, 15 },
            { 20, 17 },
            { 21, 18 },
            { 22, 10 },
            { 23, 14 },
            { 24, 16 },
            { 25, 13 },
            { 26, 14 },
            { 27, 15 },
            { 28, 18 },
            { 29, 16 },
            { 30, 16 },
            { 31, 15 }
        };
        public Dictionary<int, int> TemperaturePerNight
        {
            get { return temperaturePerNight; }
            set { temperaturePerNight = value; }
        }

        private Dictionary<int, int> atmospherePressurePerDay = new Dictionary<int, int>
        {
            { 1, 729 },
            { 2, 730 },
            { 3, 732 },
            { 4, 734 },
            { 5, 734 },
            { 6, 732 },
            { 7, 731 },
            { 8, 737 },
            { 9, 737 },
            { 10, 735 },
            { 11, 735 },
            { 12, 742 },
            { 13, 744 },
            { 14, 742 },
            { 15, 740 },
            { 16, 739 },
            { 17, 738 },
            { 18, 738 },
            { 19, 737 },
            { 20, 737 },
            { 21, 735 },
            { 22, 735 },
            { 23, 734 },
            { 24, 735 },
            { 25, 734 },
            { 26, 737 },
            { 27, 740 },
            { 28, 738 },
            { 29, 737 },
            { 30, 740 },
            { 31, 742 }
        };
        public Dictionary<int, int> AtmospherePressurePerDay
        {
            get { return atmospherePressurePerDay; }
            set { atmospherePressurePerDay = value; }
        }

        //--------------------------------
        private Dictionary<int, int> precipitationPerDay = new Dictionary<int, int>
        {
            {1, 0 }
        };
        public Dictionary<int, int> PrecipitationPerDay
        {
            get { return precipitationPerDay; }
            set { precipitationPerDay = value; }
        }


        public Dictionary<int, int> weatherTypePerDay = new Dictionary<int, int>
        {
            { 1, (int)Weather.Short_term_Rain },
            { 2, (int)Weather.Mainly_cloudy },
            { 3, (int)Weather.Mainly_cloudy },
            { 4, (int)Weather.Mainly_cloudy },
            { 5, (int)Weather.Mainly_cloudy },
            { 6, (int)Weather.Short_term_Rain },
            { 7, (int)Weather.Thunderstorm },
            { 8, (int)Weather.Mainly_cloudy },
            { 9, (int)Weather.Mainly_cloudy },
            { 10, (int)Weather.Mainly_cloudy },
            { 11, (int)Weather.Rain },
            { 12, (int)Weather.Mainly_cloudy },
            { 13, (int)Weather.Mainly_cloudy},
            { 14, (int)Weather.Mainly_cloudy },
            { 15, (int)Weather.Mainly_cloudy },
            { 16, (int)Weather.Mainly_cloudy },
            { 17, (int)Weather.Mainly_cloudy },
            { 18, (int)Weather.Thunderstorm },
            { 19, (int)Weather.Thunderstorm },
            { 20, (int)Weather.Sunny },
            { 21, (int)Weather.Thunderstorm },
            { 22, (int)Weather.Mainly_cloudy },
            { 23, (int)Weather.Mainly_cloudy },
            { 24, (int)Weather.Thunderstorm },
            { 25, (int)Weather.Thunderstorm },
            { 26, (int)Weather.Sunny },
            { 27, (int)Weather.Mainly_cloudy },
            { 28, (int)Weather.Sunny },
            { 29, (int)Weather.Thunderstorm },
            { 30, (int)Weather.Thunderstorm },
            { 31, (int)Weather.Mainly_cloudy }
        };
        public Dictionary<int, int> WeatherTypePerDay
        {
            get { return weatherTypePerDay; }
            set { weatherTypePerDay = value; }
        }

        public Dictionary<int, int> GetDayTemperature_File()
        {
            char[] charSeparators = new char[] { ' ' };
            string[] res;
            int t;
            int count = 0;

            FileStream file_temp_day = new FileStream("Day temperature.txt", FileMode.Open, FileAccess.Read);
            StreamReader fr = new StreamReader(file_temp_day);

            string info = fr.ReadLine();
            res = info.Split(charSeparators, StringSplitOptions.None);

            foreach (string i in res)
            {
                if (int.TryParse(i, out t))
                    temperaturePerDay.Add(count, t);
                else
                    Console.WriteLine($"У файлі є елемент не типу int - {i}");

                count++;
            }

            Console.WriteLine();
            return temperaturePerDay;
        }

        public void OutputDayTemperature()
        {
            Console.WriteLine("Щоденна температура у день за травень");
            foreach (KeyValuePair<int, int> i in temperaturePerDay)
            {
                Console.WriteLine(i.Key + " - " + i.Value);

            }
        }

    }

    enum Weather
    {
        Undefined = 1,
        Rain,
        Short_term_Rain,
        Thunderstorm,
        Snow,
        Fog,
        Mainly_cloudy,
        Sunny
    }
}
