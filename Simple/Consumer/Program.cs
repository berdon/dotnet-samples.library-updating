using System.IO;
using System;
using System.Reflection;
using System.Runtime.Loader;
using DependencyOne;

namespace Consumer
{
    class Program
    {
        private static Assembly CalculatorAssembly = typeof(Calculator<>).Assembly;

        static void Main(string[] _)
        {
            ICalculator<int> calculator = CreateCalculator();
            try { Console.WriteLine("{0} + {1} = {2}", 2, 2, calculator.Add(2, 2)); }
            catch (Exception e) { Console.Error.WriteLine("Error: {0}", e.Message); }

            LoadDependencyOneV2();
            calculator = CreateCalculator();
            
            try { Console.WriteLine("{0} + {1} = {2}", 2, 2, calculator.Add(2, 2)); }
            catch (Exception e) { Console.Error.WriteLine("Error: {0}", e.Message); }
        }

        private static void LoadDependencyOneV2()
        {
            CalculatorAssembly = Assembly.LoadFrom(GetDependencyOneV2Path());
        }

        private static ICalculator<int> CreateCalculator()
        {
            // Fallback to the default assembly implementation
            if (CalculatorAssembly == null) return new Calculator<int>();
            else
            {
                // Instantiate the new version using reflection
                var GenericCalculatorType = CalculatorAssembly.GetType("DependencyOne.Calculator`1");
                var IntCalculatorType = GenericCalculatorType.MakeGenericType(new Type[] { typeof(int) });
                var IntCalculatorConstructor = IntCalculatorType.GetConstructor(new Type[0]);
                return (ICalculator<int>)IntCalculatorConstructor.Invoke(null);
            }
        }

        private static string GetDependencyOneV2Path()
        {
            var pathWalker = Environment.CurrentDirectory;

            // Handle parent-directory walking to account for debugging/running
            while (!Path.GetDirectoryName(Path.GetFullPath(pathWalker)).EndsWith("Simple"))
                pathWalker = Path.Join(pathWalker, "..");
            return Path.Join(pathWalker, "..", "DependencyOne.v2", "bin", "Debug", "netstandard2.0", "DependencyOne.v2.dll");
        }
    }
}
