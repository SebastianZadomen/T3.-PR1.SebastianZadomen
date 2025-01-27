using T3Pr1SebastianZadomen;
namespace TestingT3Pr1

{
    public class UnitTest1
    {

        public class SolarEnergySimulatorTests
        {
            [Fact]
            public void TestSolarEnergySimulation_Good()
            {
                
                double hours = 10;
                SolarSystem solarSystem = new SolarSystem(hours);

               
                double energyGenerated = solarSystem.SolarEnergyGenerated(hours);

                Assert.Equal(5.0, energyGenerated); 
            }

            [Fact]
            public void TestSolarEnergySimulation_Bad()
            {
     
                double hours = -5; 
                SolarSystem solarSystem = new SolarSystem(hours);

                double energyGenerated = solarSystem.SolarEnergyGenerated(hours);

                Assert.Equal(0.0, energyGenerated);
            }
        }
        public class WindEnergySimulatorTests
        {
            [Fact]
            public void TestWindEnergySimulation_Good()
            {
            
                double windSpeed = 15.0;
                WindSystem windSystem = new WindSystem(windSpeed);

               
                double energyGenerated = windSystem.WindEnergyGenerated(windSpeed);

                
                Assert.Equal(12.0, energyGenerated); 
            }

            [Fact]
            public void TestWindEnergySimulation_Bad()
            {
                double windSpeed = -10.0; 
                WindSystem windSystem = new WindSystem(windSpeed);

                
                double energyGenerated = windSystem.WindEnergyGenerated(windSpeed);

               
                Assert.Equal(0.0, energyGenerated); 
            }
        }
        public class HydroelectricEnergySimulatorTests
        {
            [Fact]
            public void TestHydroelectricEnergySimulation_Good()
            { 
                double waterFlow = 20.0; 
                HydroelectricSystem hydroelectricSystem = new HydroelectricSystem(waterFlow);

                double energyGenerated = hydroelectricSystem.HydroelectricEnergyGenerated(waterFlow);

               
                Assert.Equal(16.0, energyGenerated); 
            }

            [Fact]
            public void TestHydroelectricEnergySimulation_Bad()
            {
                
                double waterFlow = -5.0; 
                HydroelectricSystem hydroelectricSystem = new HydroelectricSystem(waterFlow);

             
                double energyGenerated = hydroelectricSystem.HydroelectricEnergyGenerated(waterFlow);

              
                Assert.Equal(0.0, energyGenerated); 
            }
        }
    }
}
