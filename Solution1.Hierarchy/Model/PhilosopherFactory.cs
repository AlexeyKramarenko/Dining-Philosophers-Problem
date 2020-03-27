using Shared;
using System.Collections.Generic;
using System.Linq;

namespace Solution1.Hierarchy.Model
{
    public class PhilosopherFactory : AbstractPhilosopherFactory<AbstractPhilosopher<object>>
    {

        public PhilosopherFactory(params string[] names) : base(names) { }

        public override IEnumerable<AbstractPhilosopher<object>> CreatePhilosophers()
        {
            var amount = Names.Count();
            var lastIndex = amount - 1;

            object[] forks = Forks;

            for (int i = 0; i < amount; i++)
            {
                if (i == lastIndex)
                {
                    //Firstly pick up right fork, then left one
                    yield return new Philosopher(
                                         leftFork: forks[RightIndex(i)],
                                         rightFork: forks[i],
                                         name: Names.ElementAt(i));
                }
                else
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
}
