using Shared;
using System.Collections.Generic;
using System.Linq;

namespace Solution2.Waiter.Model
{
    public class PhilosopherFactory : AbstractPhilosopherFactory<AbstractPhilosopher<object>>
    {

        public PhilosopherFactory(params string[] names) : base(names) { }

        public override IEnumerable<AbstractPhilosopher<object>> CreatePhilosophers()
        {
            object[] forks = Forks;

            for (int i = 0; i < Names.Count(); i++)

                yield return new Philosopher(
                                     leftFork: forks[i],
                                     rightFork: forks[RightIndex(i)],
                                     name: Names.ElementAt(i));
        }

    }
}
