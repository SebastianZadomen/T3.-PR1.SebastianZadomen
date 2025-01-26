using System;
using T3Pr1SebastianZadomen;

namespace T3PR1SebastianZadomen
{
    public class Program
    {
        const string MainMenu = "1. Start simulation \n2. View simulation report \n3. Exit";
        const string SystemMenu = "This is a simulation \nChoose the energy system you want to simulate. \n1. Solar System. \n2. Wind System. \n3. Hydroelectric System.";
        const string MsgCount = "Add how many simulations you want to do";
        public static void Main()
        {
            const string WelcomeMessage = "Welcome to EcoEnergy Solutions";
            Console.WriteLine(WelcomeMessage);
            Console.WriteLine(MainMenu);
            MainMenuHandler();
        }

        public static void MainMenuHandler()
        {
            bool flag = true;
            while (flag)
            {
                try
                {
                    int option = Convert.ToInt32(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            EnergySystemMenu();
                            break;
                        case 2:

                            break;
                        case 3:
                            flag = false;
                            break;
                        default:
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Error: Invalid format, the entered value is not a number.");
                }
            }
        }

        public static void EnergySystemMenu()
        {
            Console.Write(MsgCount);
            int countLimit = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine(SystemMenu);
            bool flag = true;
            while (flag)
            {
                try
                {
                   
                    int option = Convert.ToInt32(Console.ReadLine());
                   

                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Solar System: \nEnter the available sun hours:");
                            double hoursSolar = Convert.ToDouble(Console.ReadLine());
                            SimulateSolarSystem(hoursSolar,countLimit);
                            break;
                        case 2:
                            Console.WriteLine("Wind System: \nEnter the wind speed:");
                            double windSpeed = Convert.ToDouble(Console.ReadLine());
                            SimulateWindSystem(windSpeed, countLimit);
                            break;
                        case 3:
                            Console.WriteLine("Hydroelectric System: \nEnter the water flow:");
                            double waterFlow = Convert.ToDouble(Console.ReadLine());
                            SimulateHydroelectricSystem(waterFlow, countLimit);
                            break;
                        default:
                            Console.WriteLine("Invalid option, please choose a valid one.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Error: Invalid format, the entered value is not a number.");
                }
            }
        }

        public static void SimulateSolarSystem(double hours, int countLimit)
        {
            SolarSystem solarSystem = new SolarSystem(hours);
            solarSystem.Simulate();
        }


        public static void SimulateWindSystem(double windSpeed, int countLimit)
        {
            WindSystem windSystem = new WindSystem(windSpeed);
            windSystem.Simulate();
        }


        public static void SimulateHydroelectricSystem(double waterFlow, int countLimit)
        {
            HydroelectricSystem hydroelectricSystem = new HydroelectricSystem(waterFlow);
            hydroelectricSystem.Simulate();
        }


        public static string RequestDate()
        {
            string date = "";
            bool validDate = false;

            while (!validDate)
            {
                Console.WriteLine("Please enter the date in DD/MM/YYYY format:");
                date = Console.ReadLine();

                if (ValidateDateFormat(date))
                {
                    validDate = true;
                }
                else
                {
                    Console.WriteLine("Invalid date format. Make sure to use DD/MM/YYYY format.");
                }
            }

            return date;
        }

        public static bool ValidateDateFormat(string date)
        {
            string[] parts = date.Split('/');

            if (parts.Length != 3) return false;

            if (int.TryParse(parts[0], out int day) &&
                int.TryParse(parts[1], out int month) &&
                int.TryParse(parts[2], out int year))
            {
                return day > 0 && day <= 31 && month > 0 && month <= 12 && year > 0;
            }

            return false;
        }
    }
}
