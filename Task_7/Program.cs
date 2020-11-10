﻿using System;
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

            day.GetNightTemperature_File();
            day.OutputNightTemperature();
            
            day.GetAtmospherePressure_File();
            day.OutputAtmospherePressure();
            
            day.GetPrecipitation();
            day.OutputPrecipitation();


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

        private Dictionary<int, int> temperaturePerNight = new Dictionary<int, int> { };
        public Dictionary<int, int> TemperaturePerNight
        {
            get { return temperaturePerNight; }
            set { temperaturePerNight = value; }
        }

        private Dictionary<int, int> atmospherePressurePerDay = new Dictionary<int, int> { };
        public Dictionary<int, int> AtmospherePressurePerDay
        {
            get { return atmospherePressurePerDay; }
            set { atmospherePressurePerDay = value; }
        }

        //--------------------------------
        private Dictionary<int, int> precipitationPerDay = new Dictionary<int, int> { };
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
            int count = 1;

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
            fr.Close();
            file_temp_day.Close();

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

        public Dictionary<int, int> GetNightTemperature_File()
        {
            char[] charSeparators = new char[] { ' ' };
            string[] res;
            int t;
            int count = 1;

            FileStream file_temp_night = new FileStream("Night temperature.txt", FileMode.Open, FileAccess.Read);
            StreamReader fr = new StreamReader(file_temp_night);

            string info = fr.ReadLine();
            res = info.Split(charSeparators, StringSplitOptions.None);

            foreach (string i in res)
            {
                if (int.TryParse(i, out t))
                    temperaturePerNight.Add(count, t);
                else
                    Console.WriteLine($"У файлі є елемент не типу int - {i}");

                count++;
            }
            fr.Close();
            file_temp_night.Close();

            Console.WriteLine();
            return temperaturePerNight;
        }

        public void OutputNightTemperature()
        {
            Console.WriteLine("Щоденна температура вночі за травень");
            foreach (KeyValuePair<int, int> i in temperaturePerNight)
            {
                Console.WriteLine(i.Key + " - " + i.Value);

            }
        }

        public Dictionary<int, int> GetAtmospherePressure_File()
        {
            char[] charSeparators = new char[] { ' ' };
            string[] res;
            int t;
            int count = 1;

            FileStream file_atm = new FileStream("Atmosphere pressure.txt", FileMode.Open, FileAccess.Read);
            StreamReader fr = new StreamReader(file_atm);

            string info = fr.ReadLine();
            res = info.Split(charSeparators, StringSplitOptions.None);

            foreach (string i in res)
            {
                if (int.TryParse(i, out t))
                    atmospherePressurePerDay.Add(count, t);
                else
                    Console.WriteLine($"У файлі є елемент не типу int - {i}");

                count++;
            }
            fr.Close();
            file_atm.Close();

            Console.WriteLine();
            return atmospherePressurePerDay;
        }

        public void OutputAtmospherePressure()
        {
            Console.WriteLine("Щоденний тиск за травень");
            foreach (KeyValuePair<int, int> i in atmospherePressurePerDay)
            {
                Console.WriteLine(i.Key + " - " + i.Value);

            }
        }

        public Dictionary<int, int> GetPrecipitation()
        {
            char[] charSeparators = new char[] { ' ' };
            string[] res;
            int t;
            int count = 1;

            FileStream file_prp = new FileStream("Precipitation.txt", FileMode.Open, FileAccess.Read);
            StreamReader fr = new StreamReader(file_prp);

            string info = fr.ReadLine();
            res = info.Split(charSeparators, StringSplitOptions.None);

            foreach (string i in res)
            {
                if (int.TryParse(i, out t))
                    precipitationPerDay.Add(count, t);
                else
                    Console.WriteLine($"У файлі є елемент не типу int - {i}");

                count++;
            }
            fr.Close();
            file_prp.Close();

            Console.WriteLine();
            return precipitationPerDay;
        }

        public void OutputPrecipitation()
        {
            Console.WriteLine("Щоденны опади за травень");
            foreach (KeyValuePair<int, int> i in precipitationPerDay)
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
