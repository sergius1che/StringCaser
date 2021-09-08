using System;
using BenchmarkDotNet.Attributes;

namespace StringCaser.Solutions
{
    [MemoryDiagnoser]
    public class Chechin : ISolution
    {
        [Arguments("qwertyuiop")]
        [Benchmark(Description = "Chechin variant")]
        public string[] Do(string input)
        {
            var n = 1 << input.Length;
            var result = new string[n];
            var span = new Span<char>(input.ToCharArray());

            for (int i = 0; i < n; i++)
            {
                for (int y = 0; y < input.Length; y++)
                {
                    if (char.IsLower(span[y]))
                    {
                        span[y] = char.ToUpper(span[y]);
                        break;
                    }

                    span[y] = char.ToLower(span[y]);
                }

                result[i] = new string(span);
            }

            return result;
        }
    }
}
