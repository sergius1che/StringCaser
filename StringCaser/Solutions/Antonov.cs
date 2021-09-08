using System;
using BenchmarkDotNet.Attributes;

namespace StringCaser.Solutions
{
    [MemoryDiagnoser]
    public class Antonov : ISolution
    {
        [Arguments("qwertyuiop")]
        [Benchmark]
        public string[] Do(string input)
        {
            var variantsCount = Convert.ToInt32(Math.Pow(2, input.Length));

            var result = new string[variantsCount];
            var array = new char[variantsCount, input.Length];

            var verticalLength = array.GetLength(0);
            var horizontalLength = array.GetLength(1);
            for (var j = 0; j < horizontalLength; j++)
            {
                for (var i = 0; i < verticalLength; i++)
                {
                    result[i] += i % (variantsCount / Math.Pow(2, j)) < variantsCount / Math.Pow(2, j + 1) ? input[j] : char.ToUpper(input[j]);
                }
            }

            return result;
        }
    }
}
