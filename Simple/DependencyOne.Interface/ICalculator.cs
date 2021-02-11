using System;

namespace DependencyOne
{
    public interface ICalculator<T>
        where T : struct
    {
        T Add(T a, T b);
        T Subtract(T a, T b);
        T Multiple(T a, T b);
        T Divide(T a, T b);
    }
}