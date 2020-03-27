using System.Threading;

namespace Solution3.ChandyMisra.Model
{
    public class Fork
    {

        public Philosopher Owner { get; set; }
        public bool IsClean { get; set; } = false;

        public void NotifyAll()
        {
            Monitor.PulseAll(this);
        }

        public void Wait()
        {
            Monitor.Wait(this);
        }

    }
}
