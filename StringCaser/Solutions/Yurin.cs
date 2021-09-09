using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace StringCaser.Solutions
{
    [MemoryDiagnoser]
    public class Yurin : ISolution
    {
        [Arguments("qwertyuiop")]
        [Benchmark]
        public string[] Do(string input)
        {
            var result = new List<string>();
            input = input.ToLower();
            result.Add(input);
            return GetVariants(result, input).ToArray();
        }

        private IEnumerable<string> GetVariants(List<string> result, string input, int step = 0)
        {
            if (step >= input.Length)
            {
                return result;
            }
            var upperString = new StringBuilder(input);
            upperString[step] = char.ToUpper(input[step]);
            result.Add(upperString.ToString());
            step++;
            return GetVariants(result, input, step).Union(GetVariants(result, upperString.ToString(), step));
        }
    }
}
