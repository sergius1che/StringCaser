using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace StringCaser.Solutions
{
    [MemoryDiagnoser]
    public class Raznopolov : ISolution
    {
        [Arguments("qwertyuiop")]
        [Benchmark(Description = "Raznopolov variant")]
        public string[] Do(string input)
        {
            var chars = input.ToCharArray();
            var size = (int)Math.Pow(2, input.Length);
            List<string> result = new List<string>(size);

            GetVariantsRaznopolovInternal(chars, 0, result);

            return result.ToArray();
        }

        public static void GetVariantsRaznopolovInternal(char[] span, int index, List<string> result)
        {
            if (index == span.Length)
            {
                result.Add(new string(span));
                return;
            }

            GetVariantsRaznopolovInternal(span, index + 1, result);

            span[index] = Revert(span[index]);
            GetVariantsRaznopolovInternal(span, index + 1, result);
        }

        private static char Revert(char ch) => Char.IsLower(ch) ? Char.ToUpper(ch) : Char.ToLower(ch);
    }
}
