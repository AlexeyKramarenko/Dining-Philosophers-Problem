using System;
using System.Threading;

namespace Shared
{
    public class ConsoleLogger
    {

        private readonly string _philosopherName;

        public ConsoleLogger(string philosopherName)
        {
            _philosopherName = philosopherName;
        }

        public void Thinking()
        {
            Console.WriteLine($"{Environment.NewLine}{_philosopherName}: Thinking");
            Thread.Sleep(1000);
        }

        public void PickedUpLeftFork()
        {
            Console.WriteLine($"{_philosopherName}: Picked Up LEFT Fork");
            Thread.Sleep(1000);
        }

        public void PickedUpRightFork()
        {
            Console.WriteLine($"{_philosopherName}: Picked Up RIGHT Fork - EATING");
            Thread.Sleep(1000);
        }

        public void PutDownRightFork()
        {
            Console.WriteLine($"{_philosopherName}: Put Down RIGHT Fork");
            Thread.Sleep(1000);
        }

        public void PutDownLeftFork()
        {
            Console.WriteLine($"{_philosopherName}: Put Down LEFT Fork. BACK TO THINKING");
            Thread.Sleep(1000);
        }

        public void Eating()
        {
            Console.WriteLine($"{_philosopherName}: EATING");
            Thread.Sleep(1000);
        }

        public void EatsInRaw(int eatsInRaw)
        {
            Console.WriteLine($"{_philosopherName}: Eats In Raw: {eatsInRaw}");
            Thread.Sleep(1000);
        }

    }
}
