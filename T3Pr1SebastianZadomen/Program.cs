using System;
using T3Pr1SebastianZadomen;

namespace T3PR1SebastianZadomen
{
    public static class Program
    {
        const string MainMenu = "1. Start simulation \n2. View simulation report \n3. Exit";
        const string SystemMenu = "This is a simulation \nChoose the energy system you want to simulate. \n1. Solar System. \n2. Wind System. \n3. Hydroelectric System.";
        const string MsgCount = "Add how many simulations you want to do";


        private static SimulationResult[]? simulationResults;
        private static int simulationCount = 0;
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
                            ShowSimulationResults();
                            break;
                        case 3:
                            Console.WriteLine("\nThank you for using me");
                            flag = false;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please choose a valid one.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Invalid format, the entered value is not a number.");
                }
            }
        }

        public static void EnergySystemMenu()
        {
            Console.WriteLine("\n" + MsgCount + "\n");
            int countLimit = Convert.ToInt16(Console.ReadLine());
            simulationResults = new SimulationResult[countLimit];

            Console.WriteLine("\n" + SystemMenu + "\n");
            bool flag = true;
            while (flag)
            {
                try
                {
                    if (simulationCount >= countLimit)
                    {
                        Console.WriteLine("\nSimulation limit reached. Returning to the main menu...\n");
                        Console.WriteLine(MainMenu + "\n");
                        flag = false;
                        continue;
                    }

                    int option = Convert.ToInt32(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("\nSolar System: \nEnter the available sun hours:");
                            double hoursSolar = Convert.ToDouble(Console.ReadLine());
                            SimulateSolarSystem(hoursSolar, countLimit);
                            break;
                        case 2:
                            Console.WriteLine("\nWind System: \nEnter the wind speed:");
                            double windSpeed = Convert.ToDouble(Console.ReadLine());
                            SimulateWindSystem(windSpeed, countLimit);
                            break;
                        case 3:
                            Console.WriteLine("\nHydroelectric System: \nEnter the water flow:");
                            double waterFlow = Convert.ToDouble(Console.ReadLine());
                            SimulateHydroelectricSystem(waterFlow, countLimit);
                            break;
                        default:
                            Console.WriteLine("\nInvalid option, please choose a valid one.\n");
                            Console.WriteLine(SystemMenu);
                            break;
                    }

                    if (simulationCount < countLimit)
                    {
                        Console.WriteLine("\n" + SystemMenu + "\n");
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("\nError: Invalid format, the entered value is not a number.\n");
                    Console.WriteLine("\n" + SystemMenu + "\n");
                }
            }
        }

        public static void SimulateSolarSystem(double hours, int countLimit)
        {
            if (simulationCount >= countLimit)
            {
                Console.WriteLine("\nSimulation limit reached. Returning to the main menu...\n");
                Console.WriteLine(MainMenu + "\n");
                return;
            }

            string date = RequestDate();
            string time = RequestTime();
            SolarSystem solarSystem = new SolarSystem(hours);
            double energyGenerated = solarSystem.SolarEnergyGenerated(hours);
            simulationResults[simulationCount] = new SimulationResult("Solar System", date, energyGenerated,time);
            simulationCount++;
        }

        public static void SimulateWindSystem(double windSpeed, int countLimit)
        {
            if (simulationCount >= countLimit)
            {
                Console.WriteLine("\nSimulation limit reached. Returning to the main menu...\n");
                Console.WriteLine(MainMenu + "\n");
                return;
            }

            string date = RequestDate();
            string time = RequestTime();
            WindSystem windSystem = new WindSystem(windSpeed);
            double energyGenerated = windSystem.WindEnergyGenerated(windSpeed);
            simulationResults[simulationCount] = new SimulationResult("Wind System", date, energyGenerated, time);
            simulationCount++;
        }

        public static void SimulateHydroelectricSystem(double waterFlow, int countLimit)
        {
            if (simulationCount < countLimit)
            {
                Console.WriteLine("\nYou have exceeded the simulation limit. Back to the main menu...\n");
                Console.WriteLine(MainMenu + "\n");
                return;
            }

            string date = RequestDate();
            string time = RequestTime();
            HydroelectricSystem hydroelectricSystem = new HydroelectricSystem(waterFlow);
            double energyGenerated = hydroelectricSystem.HydroelectricEnergyGenerated(waterFlow);
            simulationResults[simulationCount] = new SimulationResult("Hydroelectric System", date, energyGenerated, time);
            simulationCount++;
        }

        public static string RequestDate()
        {
            string date = "";
            bool validDate = false;

            while (!validDate)
            {
                Console.WriteLine("\nPlease enter the date in DD/MM/YYYY format:");
                date = Console.ReadLine();

                if (date != null && date.Length == 10 && date[2] == '/' && date[5] == '/')
                {
                    validDate = true;
                }
                else
                {
                    Console.WriteLine("\nInvalid date format. Make sure to use DD/MM/YYYY format.\n");
                }
            }

            return date;
        }
        public static string RequestTime()
        {
            string time = "";
            bool validTime = false;

            while (!validTime)
            {
                Console.WriteLine("\nPlease enter the time in HH:MM format (24-hour):");
                time = Console.ReadLine();

                //Substring retorna en este caso las posiciones marcadas , esta en la pagina de teoria 
                if (time != null && time.Length == 5 && time[2] == ':' &&
                    int.TryParse(time.Substring(0, 2), out int hours) && hours >= 0 && hours < 24 &&
                    int.TryParse(time.Substring(3, 2), out int minutes) && minutes >= 0 && minutes < 60)
                {
                    validTime = true;
                }
                else
                {
                    Console.WriteLine("\nInvalid time format. Make sure to use HH:MM (24-hour format).\n");
                }
            }

            return time;
        }


        public static void ShowSimulationResults()
        {
            if (simulationCount == 0)
            {
                Console.WriteLine("\nNo simulations have been performed yet.\n");
            }
            else
            {
                Console.WriteLine("\nSimulation Results:\n");

                Console.WriteLine($"{"System",-20} {"Date",-15} {"Time",-15}{"Energy Generated (kWh)",-20}");
                Console.WriteLine(new string('-', 80));

                for (int i = 0; i < simulationCount; i++)
                {
                    Console.WriteLine($"{simulationResults[i].SystemType,-20} {simulationResults[i].Date,-15}{simulationResults[i].Time,-15} {simulationResults[i].EnergyGenerated,-20:F2}");
                }

                Console.WriteLine(new string('-', 80)); 
            }

            Console.WriteLine("\n" + MainMenu);
        }
    }
}