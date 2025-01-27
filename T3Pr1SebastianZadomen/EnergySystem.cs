using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T3PR1SebastianZadomen;

namespace T3Pr1SebastianZadomen
{
    public abstract class EnergySystem
    {
            public int Id { get; set; }
            public string Date { get; set; }
            public double EnergyGenerated { get; set; }

            public EnergySystem()
            {
               
                Date = Program.RequestDate();
            }

            public abstract void Simulate();

        
    }
}
