using System;
using System.Collections.Generic;
using System.Linq;

namespace Shared
{
    public abstract class AbstractPhilosopherFactory<AbstractPhilosopher>
    {

        protected IEnumerable<string> Names { get; }

        public AbstractPhilosopherFactory(IEnumerable<string> names)
        {
            if (names == null)
                throw new ArgumentNullException(nameof(names));

            if (!names.Any())
                throw new ArgumentException("'names' should contain at least one element.");

            Names = names;
        }

        public abstract IEnumerable<AbstractPhilosopher> CreatePhilosophers();

        protected int LeftIndex(int i)
            => (i - 1) % Names.Count();

        protected int RightIndex(int i)
            => (i + 1) % Names.Count();

        protected object[] Forks
        {
            get =>
                new object[Names.Count()]
                            .Select(a => new object())
                            .ToArray();
        }

    }
}
