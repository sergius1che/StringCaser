using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace StringCaser.Solutions
{
    [MemoryDiagnoser]
    public class Panov : ISolution
    {
        [Arguments("qwertyuiop")]
        [Benchmark]
        public string[] Do(string input)
        {
            IEnumerable<string> result = new List<string>
            {
                char.ToUpper(input[0]).ToString(),
                char.ToLower(input[0]).ToString()
            };

            foreach (var c in input[1..])
            {
                result = AddChar(result, c);
            }
            return result.ToArray();
        }

        private static IEnumerable<string> AddChar(IEnumerable<string> str, char c)
        {
            return str.SelectMany(x =>
            {
                var result = new List<string>
            {
                    x + char.ToLower(c),
                    x + char.ToUpper(c)
            };

                return result;
            });
        }
    }
}
