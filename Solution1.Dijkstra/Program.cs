using Shared;
using Solution1.Dijkstra.Model;

namespace Solution1.Dijkstra
{
    class Program
    {

        static void Main(string[] args)

            => ThreadsInvoker.Run(new PhilosopherFactory("John", "Tom", "David", "Nick", "Steven"));

    }
}
