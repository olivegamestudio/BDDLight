using System;

namespace LightBDD
{
    public static class Runner
    {
        public static bool RunScenario(Scenario scenario)
        {
            bool result = scenario.Run();
            if (!result)
            {
                throw new InvalidOperationException();
            }
            return result;
        }
    }
}
