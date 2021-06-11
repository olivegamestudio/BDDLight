using System;
using NUnit.Framework;

namespace BDDLight.Tests
{
    public class GivenStepTests
    {

        [Test]
        public void Run_Fires_ThenStep()
        {
            bool thenFired = false;
            var step = new GivenStep(() => true);
            step.Then(() =>
            {
                thenFired = true;
                return true;
            });

            bool result = step.Run();

            Assert.IsTrue(result);
            Assert.IsTrue(thenFired);
        }

        [Test]
        public void Run_Fires_AddStepThenStep()
        {
            bool thenFired = false;
            bool andFired = false;
            var step = new GivenStep(() => true);
            var andStep = step.And(() =>
            {
                andFired = true;
                return true;
            });
            andStep.Then(() =>
            {
                thenFired = true;
                return true;
            });

            bool result = step.Run();

            Assert.IsTrue(result);
            Assert.IsTrue(thenFired);
            Assert.IsTrue(andFired);
        }
    }
}
