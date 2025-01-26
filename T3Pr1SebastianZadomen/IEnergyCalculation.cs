using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T3Pr1SebastianZadomen
{
    public interface IEnergyCalculation
    {
        double SolarEnergyGenerated(double sunHours);
        double WindEnergyGenerated(double windSpeed);
        double HydroelectricEnergyGenerated(double waterFlow);
    }
}