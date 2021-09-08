using System;
using BenchmarkDotNet.Attributes;

namespace StringCaser.Solutions
{
    [MemoryDiagnoser]
    public class Antonov2 : ISolution
    {
        [Arguments("qwertyuiop")]
        [Benchmark(Description = "Antonov2 variant")]
        public string[] Do(string input)
        {
            var variantsCount = Convert.ToInt32(Math.Pow(2, input.Length));
            var result = new string[variantsCount];

            for (var j = 0; j < input.Length; j++)
            {
                var a = variantsCount / Math.Pow(2, j);
                var b = variantsCount / Math.Pow(2, j + 1);
                for (var i = 0; i < variantsCount; i++)
                {
                    result[i] += i % a < b ? input[j] : char.ToUpper(input[j]);
                }
            }

            return result;
        }
    }
}
