using Shared;
using System;

namespace Solution3.ChandyMisra.Model
{
    public class Philosopher : AbstractPhilosopher<Fork>
    {

        public int Id { get; }
        public Philosopher LeftNeighbor { get; set; }
        public Philosopher RightNeighbor { get; set; }

        private int _eatCount;
        private int _eatNum = 0;     // total # times Philosopher has eaten
        private int _eatsInRaw = 0;   // how many times Philosopher has eaten in a row
        private bool _goingToEatRequest = false;  // signal "I want to eat"

        public Philosopher(
                        int id,
                        string name,
                        Fork leftFork,
                        Fork rightFork,
                        int eatCount) : base(leftFork, rightFork, name)
        {
            Id = id;
            _eatCount = eatCount;
        }

        public override void Run()
        {
            var logger = new ConsoleLogger(PhilosopherName);

            while (_eatNum < _eatCount)
            {
                logger.Thinking();

                ProcessForks(true);

                ObtainForksIfNecessary();

                _eatsInRaw++;
                _eatNum++;
                RightFork.IsClean = LeftFork.IsClean = false;

                logger.EatsInRaw(_eatsInRaw);
                logger.Eating();
                logger.PutDownRightFork();
                logger.PutDownLeftFork();

                ProcessForks(_eatNum != _eatCount);  // give up chopsticks unconditionally after the last iteration 
            }
        }

        private void ObtainForksIfNecessary()
        {
            // indicate that we need forks so the neighbors send them
            _goingToEatRequest = true;

            WaitForFork(LeftFork);
            WaitForFork(RightFork);

            _goingToEatRequest = false;
        }

        private void WaitForFork(Fork fork)
        {
            if (fork.Owner != this)
            {
                lock (fork)
                {
                    while (fork.Owner != this)
                    {
                        ProcessForks(true);

                        fork.Wait();
                    }
                }
            }

            var sideOfFork = fork == LeftFork ? "left" : "right";

            Console.WriteLine($"{PhilosopherName} picks up {sideOfFork} fork.");
        }

        private void ProcessForks(bool isRequestRequired)
        {
            GiveUpForkIfNecessary(LeftFork, LeftNeighbor, isRequestRequired);
            GiveUpForkIfNecessary(RightFork, RightNeighbor, isRequestRequired);
        }

        private void GiveUpForkIfNecessary(Fork fork, Philosopher receiver, bool isRequestRequired)
        {
            lock (fork)
            {
                if ((receiver._goingToEatRequest || !isRequestRequired) &&  // give up fork only on request OR unconditionally
                        !fork.IsClean &&    // only dirty forks
                        fork.Owner == this)  // only fork he owns
                {
                    // wash fork before sending out
                    fork.IsClean = true;


                    fork.Owner = receiver;

                    // reset # eats-in-raw because fork sent out
                    _eatsInRaw = 0;

                    // notify waiting threads 
                    fork.NotifyAll();
                }
            }
        }

    }
}
