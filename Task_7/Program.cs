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
            //Console.WriteLine(param_day.WeatherTypePerDay[4]);
            
            days.NumberCloudyDays();
            days.OutputConsoleNumberCloudyDays();

            days.NumberRainyDays();
            days.OutputConsoleNumberRainyDays();
        }
    }

    class WeatherDays
    {
        WeatherParametersDay a = new WeatherParametersDay();

        private int cloudyDays;
        public int CloudyDays
        {
            get { return cloudyDays; }
            set { cloudyDays = value; }
        }

        private int precipitationDays;
        public int PrecipitationDays
        {
            get { return precipitationDays; }
            set { precipitationDays = value; }
        }

        public int NumberCloudyDays()
        {
            foreach (int i in a.WeatherTypePerDay)
            {
                if (i == 7 )
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
            foreach(int i in a.PrecipitationPerDay)
            {
                if (i == 2 || i == 3 || i == 4)
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
        private List<int> temperaturePerDay = new List<int>();
        public List<int> TemperaturePerDay
        {
            get { return temperaturePerDay; }
            set { temperaturePerDay = value; }
        }

        private List<int> temperaturePerNight = new List<int>();
        public List<int> TemperaturePerNight
        {
            get { return temperaturePerNight; }
            set { temperaturePerNight = value; }
        }

        private List<int> atmospherePressurePerDay = new List<int>();
        public List<int> AtmospherePressurePerDay
        {
            get { return atmospherePressurePerDay; }
            set { atmospherePressurePerDay = value; }
        }

        private List<int> precipitationPerDay = new List<int>();
        public List<int> PrecipitationPerDay
        {
            get { return precipitationPerDay; }
            set { precipitationPerDay = value; }
        }

        private List<int> weatherTypePerDay = new List<int>();
        public List<int> WeatherTypePerDay
        {
            get { return weatherTypePerDay; }
            set { weatherTypePerDay = value; }
        }

        public List<int> GetDayTemperature_File()
        {
            char[] charSeparators = new char[] { ' ' };
            string[] res;

            FileStream file_temp_day = new FileStream("Day temperature.txt", FileMode.Open, FileAccess.Read);
            StreamReader fr = new StreamReader(file_temp_day);

            string info = fr.ReadLine();
            res = info.Split(charSeparators, StringSplitOptions.None);

            foreach (string i in res)
            {
                if (int.TryParse(i, out int t))
                    temperaturePerDay.Add( t);
                else
                    Console.WriteLine($"У файлі є елемент не типу int - {i}");

                
            }
            fr.Close();
            file_temp_day.Close();

            Console.WriteLine();
            return temperaturePerDay;
        }

        public void OutputDayTemperature()
        {
            int count = 1;
            Console.WriteLine("Щоденна температура у день за травень");
            foreach ( int i in temperaturePerDay)
            {
                Console.WriteLine(count + " - " + i);
                count++;
            }
        }

        public List<int> GetNightTemperature_File()
        {
            char[] charSeparators = new char[] { ' ' };
            string[] res;

            FileStream file_temp_night = new FileStream("Night temperature.txt", FileMode.Open, FileAccess.Read);
            StreamReader fr = new StreamReader(file_temp_night);

            string info = fr.ReadLine();
            res = info.Split(charSeparators, StringSplitOptions.None);

            foreach (string i in res)
            {
                if (int.TryParse(i, out int t))
                    temperaturePerNight.Add(t);
                else
                    Console.WriteLine($"У файлі є елемент не типу int - {i}");

            }
            fr.Close();
            file_temp_night.Close();

            Console.WriteLine();
            return temperaturePerNight;
        }

        public void OutputNightTemperature()
        {
            int count = 1;
            Console.WriteLine("Щоденна температура вночі за травень");
            foreach (int i in temperaturePerNight)
            {
                Console.WriteLine(count + " - " + i);
                count++;
            }
        }

        public List<int> GetAtmospherePressure_File()
        {
            char[] charSeparators = new char[] { ' ' };
            string[] res;

            FileStream file_atm = new FileStream("Atmosphere pressure.txt", FileMode.Open, FileAccess.Read);
            StreamReader fr = new StreamReader(file_atm);

            string info = fr.ReadLine();
            res = info.Split(charSeparators, StringSplitOptions.None);

            foreach (string i in res)
            {
                if (int.TryParse(i, out int t))
                    atmospherePressurePerDay.Add( t);
                else
                    Console.WriteLine($"У файлі є елемент не типу int - {i}");

            }
            fr.Close();
            file_atm.Close();

            Console.WriteLine();
            return atmospherePressurePerDay;
        }

        public void OutputAtmospherePressure()
        {
            int count = 1;
            Console.WriteLine("Щоденний тиск за травень");
            foreach (int i in atmospherePressurePerDay)
            {
                Console.WriteLine(count + " - " + i);
                count++;
            }
        }

        public List<int> GetPrecipitation()
        {
            char[] charSeparators = new char[] { ' ' };
            string[] res;

            FileStream file_prp = new FileStream("Precipitation.txt", FileMode.Open, FileAccess.Read);
            StreamReader fr = new StreamReader(file_prp);

            string info = fr.ReadLine();
            res = info.Split(charSeparators, StringSplitOptions.None);

            foreach (string i in res)
            {
                if (int.TryParse(i, out int t))
                    precipitationPerDay.Add(t);
                else
                    Console.WriteLine($"У файлі є елемент не типу int - {i}");

            }
            fr.Close();
            file_prp.Close();

            Console.WriteLine();
            return precipitationPerDay;
        }

        public void OutputPrecipitation()
        {
            int count = 1;
            Console.WriteLine("Щоденні опади за травень");
            foreach (int i in precipitationPerDay)
            {
                Console.WriteLine(count + " - " + i);
                count++;
            }
        }

        public List<int> GetWeatherType()
        {
            char[] charSeparators = new char[] { ' ' };
            string[] res;

            FileStream file_wt = new FileStream("Weather type.txt", FileMode.Open, FileAccess.Read);
            StreamReader fr = new StreamReader(file_wt);

            string info = fr.ReadLine();
            res = info.Split(charSeparators, StringSplitOptions.None);

            foreach (string i in res)
            {
                if (int.TryParse(i, out int t))
                    weatherTypePerDay.Add(t);
                else
                    Console.WriteLine($"У файлі є елемент не типу int - {i}");

            }
            fr.Close();
            file_wt.Close();

            Console.WriteLine();
            return weatherTypePerDay;
        }

        public void OutputWeatherType()
        {
            int count = 1;
            Console.WriteLine("Щоденна погода за травень");
            foreach (int i in weatherTypePerDay)
            {
                string a = Enum.GetName(typeof(Weather), i);

                Console.WriteLine(count + " - " + a);
                count++;
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
