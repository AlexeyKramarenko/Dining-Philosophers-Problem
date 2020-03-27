using Shared;
using System.Threading;

namespace Solution2.Waiter.Model
{
    public class Philosopher : AbstractPhilosopher<object>
    {

        private static Mutex _waiter = new Mutex();

        public Philosopher(
                object leftFork,
                object rightFork,
                string name)
                        : base(leftFork, rightFork, name) { }


        public override void Run()
        {
            var logger = new ConsoleLogger(PhilosopherName);

            while (true)
            {
                _waiter.WaitOne();

                logger.Thinking();

                lock (LeftFork)
                {

                    logger.PickedUpLeftFork();

                    lock (RightFork)
                    {

                        logger.PickedUpRightFork();

                        _waiter.ReleaseMutex();

                        logger.PutDownRightFork();
                    }

                    logger.PutDownLeftFork();
                }
            }
        }

    }
}
