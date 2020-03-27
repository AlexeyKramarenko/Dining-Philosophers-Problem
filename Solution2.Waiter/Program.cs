using Shared;
using Solution2.Waiter.Model;

namespace Solution2.Waiter
{
    class Program
    {

        static void Main(string[] args)

            => ThreadsInvoker.Run(new PhilosopherFactory("John", "Tom", "David", "Nick", "Steven"));

    }
}
