using Shared;
using System.Collections.Generic;
using System.Linq;

namespace Deadlock.Model
{
    public class PhilosopherFactory : AbstractPhilosopherFactory<AbstractPhilosopher<object>>
    {

        public PhilosopherFactory(params string[] names) : base(names) { }

        public override IEnumerable<AbstractPhilosopher<object>> CreatePhilosophers()
        {
            var amount = Names.Count();
            
            object[] forks = Forks;

            for (int i = 0; i < amount; i++)
            {
                //Firstly pick up left fork, then right one
                yield return new Philosopher(
                                    leftFork: forks[i],
                                    rightFork: forks[RightIndex(i)],
                                    name: Names.ElementAt(i));
            }
        }

    }
}
