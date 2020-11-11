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

            WeatherParametersDay param_day = new WeatherParametersDay();
            WeatherDays days = new WeatherDays();

            param_day.GetDayTemperature_File();
            param_day.OutputDayTemperature();

            param_day.GetNightTemperature_File();
            param_day.OutputNightTemperature();
            
            param_day.GetAtmospherePressure_File();
            param_day.OutputAtmospherePressure();
            
            param_day.GetPrecipitation();
            param_day.OutputPrecipitation();

            param_day.GetWeatherType();
            param_day.OutputWeatherType();
            
            
            days.NumberCloudyDays();
            days.OutputConsoleNumberCloudyDays();

            days.NumberRainyDays();
            days.OutputConsoleNumberRainyDays();
        }
    }

    class WeatherDays : WeatherParametersDay
    {
        //readonly WeatherParametersDay day = new WeatherParametersDay();

        private int cloudyDays = 0;
        public int CloudyDays
        {
            get { return cloudyDays; }
            set { cloudyDays = value; }
        }

        private int precipitationDays = 0;
        public int PrecipitationDays
        {
            get { return precipitationDays; }
            set { precipitationDays = value; }
        }

        public int NumberCloudyDays()
        {
            foreach (KeyValuePair<int, int> i in WeatherTypePerDay)
            {
                if (i.Value == 7 )
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

        public int NumberRainyDays()
        {
            foreach(KeyValuePair<int, int> i in PrecipitationPerDay)
            {
                if (i.Value == 2 || i.Value == 3 || i.Value == 4)
                    precipitationDays++;
            }

            Console.WriteLine();
            return precipitationDays;
        }

        public void OutputConsoleNumberRainyDays()
        {
            Console.WriteLine($"Дощових днів у травні 2019 року було - {precipitationDays}");
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

        private Dictionary<int, int> precipitationPerDay = new Dictionary<int, int> { };
        public Dictionary<int, int> PrecipitationPerDay
        {
            get { return precipitationPerDay; }
            set { precipitationPerDay = value; }
        }

        public Dictionary<int, int> weatherTypePerDay = new Dictionary<int, int> { };
        public Dictionary<int, int> WeatherTypePerDay
        {
            get { return weatherTypePerDay; }
            set { weatherTypePerDay = value; }
        }

        public Dictionary<int, int> GetDayTemperature_File()
        {
            char[] charSeparators = new char[] { ' ' };
            string[] res;
            int count = 1;

            FileStream file_temp_day = new FileStream("Day temperature.txt", FileMode.Open, FileAccess.Read);
            StreamReader fr = new StreamReader(file_temp_day);

            string info = fr.ReadLine();
            res = info.Split(charSeparators, StringSplitOptions.None);

            foreach (string i in res)
            {
                if (int.TryParse(i, out int t))
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
            int count = 1;

            FileStream file_temp_night = new FileStream("Night temperature.txt", FileMode.Open, FileAccess.Read);
            StreamReader fr = new StreamReader(file_temp_night);

            string info = fr.ReadLine();
            res = info.Split(charSeparators, StringSplitOptions.None);

            foreach (string i in res)
            {
                if (int.TryParse(i, out int t))
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
            int count = 1;

            FileStream file_atm = new FileStream("Atmosphere pressure.txt", FileMode.Open, FileAccess.Read);
            StreamReader fr = new StreamReader(file_atm);

            string info = fr.ReadLine();
            res = info.Split(charSeparators, StringSplitOptions.None);

            foreach (string i in res)
            {
                if (int.TryParse(i, out int t))
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
            int count = 1;

            FileStream file_prp = new FileStream("Precipitation.txt", FileMode.Open, FileAccess.Read);
            StreamReader fr = new StreamReader(file_prp);

            string info = fr.ReadLine();
            res = info.Split(charSeparators, StringSplitOptions.None);

            foreach (string i in res)
            {
                if (int.TryParse(i, out int t))
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
            Console.WriteLine("Щоденні опади за травень");
            foreach (KeyValuePair<int, int> i in precipitationPerDay)
            {
                Console.WriteLine(i.Key + " - " + i.Value);

            }
        }

        public Dictionary<int, int> GetWeatherType()
        {
            char[] charSeparators = new char[] { ' ' };
            string[] res;
            int count = 1;

            FileStream file_wt = new FileStream("Weather type.txt", FileMode.Open, FileAccess.Read);
            StreamReader fr = new StreamReader(file_wt);

            string info = fr.ReadLine();
            res = info.Split(charSeparators, StringSplitOptions.None);

            foreach (string i in res)
            {
                if (int.TryParse(i, out int t))
                    weatherTypePerDay.Add(count, t);
                else
                    Console.WriteLine($"У файлі є елемент не типу int - {i}");

                count++;
            }
            fr.Close();
            file_wt.Close();

            Console.WriteLine();
            return weatherTypePerDay;
        }

        public void OutputWeatherType()
        {
            Console.WriteLine("Щоденна погода за травень");
            foreach (KeyValuePair<int, int> i in weatherTypePerDay)
            {
                string a = Enum.GetName(typeof(Weather), i.Value);

                Console.WriteLine(i.Key + " - " + a);
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
