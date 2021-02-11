using System;

namespace DependencyOne
{
    public class Calculator<T> : ICalculator<T>
        where T : struct
    {
        public T Add(T a, T b)
        {
            return (dynamic) a + (dynamic) b;
        }

        public T Divide(T a, T b)
        {
            return (dynamic) a / (dynamic) b;
        }

        public T Multiple(T a, T b)
        {
            return (dynamic) a * (dynamic) b;
        }

        public T Subtract(T a, T b)
        {
            return (dynamic) a - (dynamic) b;
        }
    }
}
