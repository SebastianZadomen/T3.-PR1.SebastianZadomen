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
        public double EnergyGenerated { get; set; } 


        public SimulationResult(string systemType, string date, double energyGenerated)
        {
            SystemType = systemType;
            Date = date;
            EnergyGenerated = energyGenerated;
        }

        public override string ToString()
        {
            return $"System: {SystemType}, Date: {Date}, Energy Generated: {EnergyGenerated} kWh";
        }
    }
}
