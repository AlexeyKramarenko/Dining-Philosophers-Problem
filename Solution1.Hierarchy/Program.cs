using Shared;
using Solution1.Hierarchy.Model;

namespace Solution1.Hierarchy
{
    class Program
    {

        static void Main(string[] args)

            => ThreadsInvoker.Run(new PhilosopherFactory("John", "Tom", "David", "Nick", "Steven"));

    }
}
