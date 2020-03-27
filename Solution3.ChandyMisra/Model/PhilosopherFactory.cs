using Shared;
using System.Collections.Generic;
using System.Linq;

namespace Solution3.ChandyMisra.Model
{
    public class PhilosopherFactory : AbstractPhilosopherFactory<AbstractPhilosopher<Fork>>
    {

        public PhilosopherFactory(params string[] names) : base(names) { }

        public override IEnumerable<AbstractPhilosopher<Fork>> CreatePhilosophers()
        {
            int philosophersCount = Names.Count();

            int eatCount = Names.Count() - 1;

            var forks = new Fork[philosophersCount];

            for (int i = 0; i < philosophersCount; i++)
                forks[i] = new Fork();


            var philosophers = new Philosopher[philosophersCount];

            for (int i = 0; i < philosophersCount; i++)
                philosophers[i] = new Philosopher(
                                        id: i + 1,
                                        name: Names.ElementAt(i),
                                        leftFork: forks[i],
                                        rightFork: forks[RightIndex(i)],
                                        eatCount: eatCount);


            //  set neighbors and assign owners: give the forks to the philosopher with the lower ID
            philosophers[0].LeftNeighbor = philosophers[philosophersCount - 1];
            philosophers[0].RightNeighbor = philosophers[1];
            forks[0].Owner = philosophers[0];


            for (int i = 1; i < philosophersCount; i++)
            {
                philosophers[i].LeftNeighbor = philosophers[LeftIndex(i)];
                philosophers[i].RightNeighbor = philosophers[RightIndex(i)];
                forks[i].Owner = philosophers[i - 1];
            }

            return philosophers;
        }

    }
}
