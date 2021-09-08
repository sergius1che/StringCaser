using System;
using BenchmarkDotNet.Attributes;

namespace StringCaser.Solutions
{
    [MemoryDiagnoser]
    public class Raznopolov2 : ISolution
    {
        [Arguments("qwertyuiop")]
        [Benchmark]
        public string[] Do(string input)
        {
            var chars = input.ToCharArray();
            var size = (int)Math.Pow(2, input.Length);
            var result = new string[size];
            var resultIndex = 0;

            GetVariantsRaznopolov2Internal(chars, 0, result, ref resultIndex);

            return result;
        }

        private void GetVariantsRaznopolov2Internal(char[] input, int inputIndex, string[] result, ref int resultIndex)
        {
            if (inputIndex == input.Length)
            {
                result[resultIndex++] = new string(input);
                return;
            }

            GetVariantsRaznopolov2Internal(input, inputIndex + 1, result, ref resultIndex);

            input[inputIndex] = Revert(input[inputIndex]);
            GetVariantsRaznopolov2Internal(input, inputIndex + 1, result, ref resultIndex);
        }

        private char Revert(char ch)
            => Char.IsLower(ch) ? Char.ToUpper(ch) : Char.ToLower(ch);
    }
}
