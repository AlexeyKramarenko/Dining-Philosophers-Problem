using Shared;

namespace Solution1.Dijkstra.Model
{
    public class Philosopher : AbstractPhilosopher<object>
    {

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
                logger.Thinking();

                lock (LeftFork)
                {
                    logger.PickedUpLeftFork();

                    lock (RightFork)
                    {
                        logger.PickedUpRightFork();

                        logger.PutDownRightFork();
                    }

                    logger.PutDownLeftFork();
                }
            }
        }

    }
}
