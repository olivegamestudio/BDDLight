using System;

namespace LightBDD
{
    public class Scenario
    {
        Scenario()
        {
        }

        GivenStep _given;

        public static Scenario Create() => new Scenario();

        public GivenStep Given(Func<bool> action)
        {
            _given = new GivenStep(action);
            return _given;
        }

        public bool Run()
        {
            return _given.Run();
        }
    }
}
