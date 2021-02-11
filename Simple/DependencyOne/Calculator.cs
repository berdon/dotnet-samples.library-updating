using System;

namespace DependencyOne
{
    public class Calculator<T> : ICalculator<T>
        where T : struct
    {
        public T Add(T a, T b)
        {
            throw new NotImplementedException();
        }

        public T Divide(T a, T b)
        {
            throw new NotImplementedException();
        }

        public T Multiple(T a, T b)
        {
            throw new NotImplementedException();
        }

        public T Subtract(T a, T b)
        {
            throw new NotImplementedException();
        }
    }
}
