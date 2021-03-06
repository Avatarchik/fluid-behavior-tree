using CleverCrow.Fluid.BTs.Decorators;
using CleverCrow.Fluid.BTs.Tasks;
using NUnit.Framework;

namespace CleverCrow.Fluid.BTs.Testing {
    public class RepeatForeverTest {
        public class UpdateMethod {
            private RepeatForever repeater;

            [SetUp]
            public void Setup_repeater () {
                repeater = new RepeatForever();
            }

            [Test]
            public void Returns_continue_on_child_failure () {
                repeater.AddChild(A.TaskStub().WithUpdateStatus(TaskStatus.Failure).Build());

                Assert.AreEqual(TaskStatus.Continue, repeater.Update());
            }

            [Test]
            public void Returns_continue_on_child_success () {
                repeater.AddChild(A.TaskStub().WithUpdateStatus(TaskStatus.Success).Build());

                Assert.AreEqual(TaskStatus.Continue, repeater.Update());
            }

            [Test]
            public void Returns_continue_on_child_continue () {
                repeater.AddChild(A.TaskStub().WithUpdateStatus(TaskStatus.Continue).Build());

                Assert.AreEqual(TaskStatus.Continue, repeater.Update());
            }
        }
    }
}