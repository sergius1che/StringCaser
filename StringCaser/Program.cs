using System.Linq;
using BenchmarkDotNet.Running;

namespace StringCaser
{
    class Program
    {
        static void Main(string[] args)
        {
            var solutions = typeof(Program).Assembly.GetTypes().Where(x => x.IsClass && x.GetInterfaces().Any(x => x.Equals(typeof(ISolution)))).ToArray();
            var passed = Tests.Instance.Execute(solutions);

            if (passed)
            {
                var bench = new BenchmarkSwitcher(solutions);
                bench.RunAllJoined();
            }
        }
    }
}
