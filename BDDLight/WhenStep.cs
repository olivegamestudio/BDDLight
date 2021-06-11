using System;

namespace BDDLight
{
    public class WhenStep
    {
        readonly Func<bool> _action;
        ThenStep _then;

        public WhenStep(Func<bool> action) => _action = action;

        public ThenStep Then(Func<bool> action)
        {
            _then = new ThenStep(action);
            return _then;
        }

        public bool Run()
        {
            bool result = _action.Invoke();
            if (!result)
            {
                throw new InvalidOperationException();
            }
            return _then.Run();
        }
    }
}
