using System.Threading.Tasks;

namespace Shared
{
    public static class ThreadsInvoker
    {

        public static void Run<T>(AbstractPhilosopherFactory<AbstractPhilosopher<T>> philosopherFactory)
        {
            var philosophers = philosopherFactory.CreatePhilosophers();

            Parallel.ForEach(philosophers, p => p.Run());
        }

    }
}
