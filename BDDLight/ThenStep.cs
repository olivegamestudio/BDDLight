using System;

namespace BDDLight
{
    public class ThenStep
    {
        readonly Func<bool> _action;

        public ThenStep(Func<bool> action) => _action = action;

        public bool Run()
        {
            return _action.Invoke();
        }
    }
}
