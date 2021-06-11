using System;

namespace BDDLight
{
    public class GivenStep
    {
        readonly Func<bool> _action;
        AndStep _and;
        ThenStep _then;

        public GivenStep(Func<bool> action) => _action = action;

        public AndStep And(Func<bool> action)
        {
            _and = new AndStep(action);
            return _and;
        }

        public ThenStep Then(Func<bool> action)
        {
            _then = new ThenStep(action);
            return _then;
        }

        public bool Run()
        {
            if (_and == null)
            {
                bool thenResult = _action.Invoke();
                if (!thenResult)
                {
                    throw new InvalidOperationException();
                }
                return _then.Run();
            }

            bool result = _action.Invoke();
            if (!result)
            {
                throw new InvalidOperationException();
            }
            return _and.Run();
        }
    }
}
