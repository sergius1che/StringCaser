using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace StringCaser.Solutions
{
    [MemoryDiagnoser]
    public class Samarskii : ISolution
    {
        [Arguments("qwertyuiop")]
        [Benchmark]
        public string[] Do(string input)
        {
            var result = new List<string>();

            void ChangeCase(string basic, int index, string current)
            {
                if (index == basic.Length)
                {
                    result.Add(current);
                    return;
                }

                ChangeCase(basic, index + 1, current + basic.ToLower()[index]);
                ChangeCase(basic, index + 1, current + basic.ToUpper()[index]);
            }

            ChangeCase(input, 0, "");
            return result.ToArray();
        }
    }
}
