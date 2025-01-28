using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T3Pr1SebastianZadomen
{
    public class SimulationResult
    {
        public string SystemType { get; set; }  
        public string Date { get; set; }        
        public string Time { get; set; }
        public double EnergyGenerated { get; set; } 


        public SimulationResult(string systemType, string date, double energyGenerated,string time)
        {
            SystemType = systemType;
            Date = date;
            EnergyGenerated = energyGenerated;
            Time = time;
        }

        //This method was mainly to display the results but since it was in a table format I had to discard that function.
        public override string ToString()
        {
            return $"System: {SystemType}, Date: {Date}, Time {Time} Energy Generated: {EnergyGenerated} kWh";
        }
    }
}
