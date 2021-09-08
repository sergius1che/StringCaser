using System;
using BenchmarkDotNet.Attributes;

namespace StringCaser.Solutions
{
    [MemoryDiagnoser]
    public class Bezruchenko : ISolution
    {
        [Arguments("qwertyuiop")]
        [Benchmark(Description = "Bezruchenko variant")]
        public string[] Do(string input)
        {
            ulong totalLength = (ulong)Math.Pow(2.0, input.Length);
            string[] res = new string[totalLength];
            input = input.ToLower();

            for (ulong i = 0; i < totalLength; i++)
            {
                res[i] = GetCaseFromBitField(input, i);
            }

            return res;
        }

        private static string GetCaseFromBitField(string input, ulong bitField)
        {
            string res = "";
            for (int i = 0; i < input.Length; i++)
            {
                char ch = ((bitField & 1) == 1) ? char.ToUpper(input[i]) : input[i];
                res += ch;
                bitField >>= 1;
            }
            return res;
        }
    }
}
