using System;

namespace BDDLight
{
    public class AndStep
    {
        readonly Func<bool> _action;
        WhenStep _when;
        ThenStep _then;
        AndStep _and;

        public AndStep(Func<bool> action) => _action = action;

        public WhenStep When(Func<bool> action)
        {
            _when = new WhenStep(action);
            return _when;
        }

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
            if (_and != null)
            {
                bool resultAnd = _and.Run();
                if (!resultAnd)
                {
                    throw new InvalidOperationException();
                }
            }

            if (_when == null)
            {
                bool resultWhen = _action.Invoke();
                if (!resultWhen)
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
            return _when.Run();
        }
    }
}
