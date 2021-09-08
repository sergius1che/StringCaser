using System.Collections;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace StringCaser.Solutions
{
    [MemoryDiagnoser]
    public class Kurtsev : ISolution
    {
        [Arguments("qwertyuiop")]
        [Benchmark]
        public string[] Do(string input)
        {
            var n = input.Length;
            var resultsLength = 1 << input.Length;
            var results = new string[resultsLength];

            for (int i = 0; i < resultsLength; i++)
            {
                var result = input.ToArray();
                BitArray mask = new BitArray(new int[] { i });
                for (int j = 0; j < n; j++)
                {
                    if (mask[j])
                    {
                        result[j] = char.ToUpper(result[j]);
                    }
                }
                results[i] = new string(result);
            }

            return results;
        }
    }
}
