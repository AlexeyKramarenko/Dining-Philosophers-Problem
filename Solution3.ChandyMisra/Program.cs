using Shared;
using Solution3.ChandyMisra.Model;

namespace Solution3.ChandyMisra
{
    class Program
    {

        static void Main(string[] args)

            => ThreadsInvoker.Run(new PhilosopherFactory("John", "Tom", "David", "Nick", "Steven"));

    }
}
