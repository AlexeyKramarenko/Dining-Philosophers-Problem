namespace Shared
{
    public abstract class AbstractPhilosopher<T>
    {

        protected T LeftFork;
        protected T RightFork;
        protected string PhilosopherName;

        public AbstractPhilosopher(
                    T leftFork,
                    T rightFork,
                    string name)
        {
            LeftFork = leftFork;
            RightFork = rightFork;
            PhilosopherName = name;
        }

        public abstract void Run();

    }
}
