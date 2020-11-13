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

            WeatherParametersDay.GetDayTemperature_File();
            WeatherParametersDay.OutputDayTemperature();

            WeatherParametersDay.GetNightTemperature_File();
            WeatherParametersDay.OutputNightTemperature();

            WeatherParametersDay.GetAtmospherePressure_File();
            WeatherParametersDay.OutputAtmospherePressure();

            WeatherParametersDay.GetPrecipitation();
            WeatherParametersDay.OutputPrecipitation();

            WeatherParametersDay.GetWeatherType();
            WeatherParametersDay.OutputWeatherType();

            WeatherDays.NumberCloudyDays();
            WeatherDays.OutputConsoleNumberCloudyDays();

            WeatherDays.NumberRainyDays();
            WeatherDays.OutputConsoleNumberRainyDays();

            WeatherDays.MidPrecipitation();
            WeatherDays.OutputConsoleMidPrecipitation();
        }
    }

    class WeatherDays
    {

        private static int cloudyDays;
        public static int CloudyDays
        {
            get { return cloudyDays; }
            set { cloudyDays = value; }
        }

        private static int precipitationDays;
        public static int PrecipitationDays
        {
            get { return precipitationDays; }
            set { precipitationDays = value; }
        }

        private static double midPrecipitationMonth = 0;
        public static double PrecipitationMonth
        {
            get { return midPrecipitationMonth; }
            set { midPrecipitationMonth = value; }
        }

        private static List<double> prDays = new List<double> ();
        public static List<double> PrDays
        {
            get { return prDays; }
            set { prDays = value; }
        }

        //Метод обраховує к-сть хмарних днів
        public static int NumberCloudyDays()
        {
            foreach (int i in WeatherParametersDay.WeatherTypePerDay)
            {
                if (i == 7 )
                    cloudyDays++; 
            }

            Console.WriteLine();
            return cloudyDays;
        }

        public static void OutputConsoleNumberCloudyDays()
        {
            Console.WriteLine($"Похмурих днів у травні 2019 року було - {cloudyDays}");
            Console.WriteLine();
        }
        //Метод обраховує к-сть дощових днів
        public static int NumberRainyDays()
        {
            int count = 0;
            foreach(int i in WeatherParametersDay.PrecipitationPerDay)
            {
                if (i > 0)
                {
                    precipitationDays++;
                    prDays.Add(count);
                }
                count++;
            }
            Console.WriteLine();
            return precipitationDays;
        }

        public static void OutputConsoleNumberRainyDays()
        {
            Console.WriteLine($"Дощових днів у травні 2019 року було - {precipitationDays}");
            Console.WriteLine();
        }
        //Метод обраховує середню к-сть опадів за місяць
        public static double MidPrecipitation()
        {
            int count = 0;
            foreach (int i in prDays)
            {
                count++;
                midPrecipitationMonth += WeatherParametersDay.PrecipitationPerDay[i];
            }
            midPrecipitationMonth /= count;
            midPrecipitationMonth = Math.Round(midPrecipitationMonth, 2);

            Console.WriteLine();
            return midPrecipitationMonth;
        }

        public static void OutputConsoleMidPrecipitation()
        {
            Console.WriteLine($"Середня к-сть опадів у травні 2019 року  - {midPrecipitationMonth} мм.");
            Console.WriteLine();
        }
    }

    class WeatherParametersDay
    {
        private static List<double> temperaturePerDay = new List<double>();
        public static List<double> TemperaturePerDay
        {
            get { return temperaturePerDay; }
            set { temperaturePerDay = value; }
        }

        private static List<double> temperaturePerNight = new List<double>();
        public static List<double> TemperaturePerNight
        {
            get { return temperaturePerNight; }
            set { temperaturePerNight = value; }
        }

        private static List<double> atmospherePressurePerDay = new List<double>();
        public static List<double> AtmospherePressurePerDay
        {
            get { return atmospherePressurePerDay; }
            set { atmospherePressurePerDay = value; }
        }

        private static List<double> precipitationPerDay = new List<double>();
        public static List<double> PrecipitationPerDay
        {
            get { return precipitationPerDay; }
            set { precipitationPerDay = value; }
        }

        private static List<double> weatherTypePerDay = new List<double>();
        public static List<double> WeatherTypePerDay
        {
            get { return weatherTypePerDay; }
            set { weatherTypePerDay = value; }
        }
        //Методи Get - отримання данних з файлів
        //Методи Output - вивід данних у консоль

        public static List<double> GetDayTemperature_File()
        {
            char[] charSeparators = new char[] { ' ' };
            string[] res;

            FileStream file_temp_day = new FileStream("Day temperature.txt", FileMode.Open, FileAccess.Read);
            StreamReader fr = new StreamReader(file_temp_day);

            string info = fr.ReadLine();
            res = info.Split(charSeparators, StringSplitOptions.None);

            foreach (string i in res)
            {
                if (double.TryParse(i, out double t))
                    temperaturePerDay.Add( t);
                else
                    Console.WriteLine($"У файлі є елемент не типу int - {i}");

                
            }
            fr.Close();
            file_temp_day.Close();

            Console.WriteLine();
            return temperaturePerDay;
        }

        public static void OutputDayTemperature()
        {
            int count = 1;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Щоденна температура у день за травень");
            Console.ResetColor();

            foreach ( int i in temperaturePerDay)
            {
                Console.WriteLine(count + " - " + i);
                count++;
            }
        }

        public static List<double> GetNightTemperature_File()
        {
            char[] charSeparators = new char[] { ' ' };
            string[] res;

            FileStream file_temp_night = new FileStream("Night temperature.txt", FileMode.Open, FileAccess.Read);
            StreamReader fr = new StreamReader(file_temp_night);

            string info = fr.ReadLine();
            res = info.Split(charSeparators, StringSplitOptions.None);

            foreach (string i in res)
            {
                if (double.TryParse(i, out double t))
                    temperaturePerNight.Add(t);
                else
                    Console.WriteLine($"У файлі є елемент не типу int - {i}");

            }
            fr.Close();
            file_temp_night.Close();

            Console.WriteLine();
            return temperaturePerNight;
        }

        public static void OutputNightTemperature()
        {
            int count = 1;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Щоденна температура вночі за травень");
            Console.ResetColor();

            foreach (int i in temperaturePerNight)
            {
                Console.WriteLine(count + " - " + i);
                count++;
            }
        }

        public static List<double> GetAtmospherePressure_File()
        {
            char[] charSeparators = new char[] { ' ' };
            string[] res;

            FileStream file_atm = new FileStream("Atmosphere pressure.txt", FileMode.Open, FileAccess.Read);
            StreamReader fr = new StreamReader(file_atm);

            string info = fr.ReadLine();
            res = info.Split(charSeparators, StringSplitOptions.None);

            foreach (string i in res)
            {
                if (double.TryParse(i, out double t))
                    atmospherePressurePerDay.Add( t);
                else
                    Console.WriteLine($"У файлі є елемент не типу int - {i}");

            }
            fr.Close();
            file_atm.Close();

            Console.WriteLine();
            return atmospherePressurePerDay;
        }

        public static void OutputAtmospherePressure()
        {
            int count = 1;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Щоденний тиск за травень");
            Console.ResetColor();

            foreach (int i in atmospherePressurePerDay)
            {
                Console.WriteLine(count + " - " + i);
                count++;
            }
        }
         
        public static List<double> GetPrecipitation()
        {
            char[] charSeparators = new char[] { ' ' };
            string[] res;

            FileStream file_prp = new FileStream("Precipitation.txt", FileMode.Open, FileAccess.Read);
            StreamReader fr = new StreamReader(file_prp);

            string info = fr.ReadLine();
            res = info.Split(charSeparators, StringSplitOptions.None);

            foreach (string i in res)
            {
                if (double.TryParse(i, out double t))
                    precipitationPerDay.Add(t);
                else
                    Console.WriteLine($"У файлі є елемент не типу int - {i}");

            }
            fr.Close();
            file_prp.Close();

            Console.WriteLine();
            return precipitationPerDay;
        }

        public static void OutputPrecipitation()
        {
            int count = 1;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Щоденні опади за травень");
            Console.ResetColor();

            foreach (int i in precipitationPerDay)
            {
                Console.WriteLine(count + " - " + i);
                count++;
            }
        }

        public static List<double> GetWeatherType()
        {
            char[] charSeparators = new char[] { ' ' };
            string[] res;

            FileStream file_wt = new FileStream("Weather type.txt", FileMode.Open, FileAccess.Read);
            StreamReader fr = new StreamReader(file_wt);

            string info = fr.ReadLine();
            res = info.Split(charSeparators, StringSplitOptions.None);

            foreach (string i in res)
            {
                if (double.TryParse(i, out double t))
                    weatherTypePerDay.Add(t);
                else
                    Console.WriteLine($"У файлі є елемент не типу int - {i}");

            }
            fr.Close();
            file_wt.Close();

            Console.WriteLine();
            return weatherTypePerDay;
        }

        public static void OutputWeatherType()
        {
            int count = 1;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Щоденна погода за травень");
            Console.ResetColor();

            foreach (int i in weatherTypePerDay)
            {
                string a = Enum.GetName(typeof(Weather), i);

                Console.WriteLine(count + " - " + a);
                count++;
            }
        }
    }
    //Перебір можливих варіантів погоди
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
