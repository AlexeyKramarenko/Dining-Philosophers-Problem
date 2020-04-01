using Deadlock.Model;
using Shared;

namespace Deadlock
{
    class Program
    {

        static void Main(string[] args)

            => ThreadsInvoker.Run(new PhilosopherFactory("John", "Tom", "David", "Nick", "Steven"));

    }
}
