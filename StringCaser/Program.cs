using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace StringCaser
{
    class Program
    {
        static void Main(string[] args)
        {
            var b = new Bench();
            var tests = new Tests();

            var passed = true;

            passed &= tests.Execute(nameof(b.GetVariatnsChechin), b.GetVariatnsChechin);
            passed &= tests.Execute(nameof(b.GetVariantsBezruchenko), b.GetVariantsBezruchenko);
            passed &= tests.Execute(nameof(b.GetVariantsKurcev), b.GetVariantsKurcev);
            passed &= tests.Execute(nameof(b.GetVariantsPanov), b.GetVariantsPanov);
            passed &= tests.Execute(nameof(b.GetVariantsAntonov), b.GetVariantsAntonov);
            passed &= tests.Execute(nameof(b.GetVariantsRaznopolov), b.GetVariantsRaznopolov);
            passed &= tests.Execute(nameof(b.GetVariantsRaznopolov2), b.GetVariantsRaznopolov2);
            passed &= tests.Execute(nameof(b.GetVariantsAntonov2), b.GetVariantsAntonov2);

            if (passed)
            {
                BenchmarkRunner.Run<Bench>();
            }
        }
    }

    [MemoryDiagnoser]
    public class Bench
    {
        private const string INPUT = "qwertyuiop";

        [Benchmark]
        public string[] GetVariatnsChechin()
        {
            return GetVariatnsChechin(INPUT);
        }

        [Benchmark]
        public string[] GetVariantsBezruchenko()
        {
            return GetVariantsBezruchenko(INPUT);
        }

        [Benchmark]
        public string[] GetVariantsKurcev()
        {
            return GetVariantsKurcev(INPUT);
        }

        [Benchmark]
        public string[] GetVariantsPanov()
        {
            return GetVariantsPanov(INPUT);
        }

        [Benchmark]
        public string[] GetVariantsAntonov()
        {
            return GetVariantsAntonov(INPUT);
        }

        [Benchmark]
        public string[] GetVariantsRaznopolov()
        {
            return GetVariantsRaznopolov(INPUT);
        }

        [Benchmark]
        public string[] GetVariantsRaznopolov2()
        {
            return GetVariantsRaznopolov2(INPUT);
        }

        [Benchmark]
        public string[] GetVariantsAntonov2()
        {
            return GetVariantsAntonov2(INPUT);
        }

        #region Chechin
        public string[] GetVariatnsChechin(string input)
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

        public string[] GetVariatnsChechin2(string input)
        {
            var n = 1 << input.Length;
            var result = new string[n];
            var map = new char[input.Length, n];

            for (int i = 0; i < input.Length; i++)
            {
                var mid = n >> (i + 1);

                for (int y = 0; y < n; y++)
                {

                }
            }

            return result;
        }

        private void Fill(char[,] map, char ch, int n, int col, int start, int end, string input)
        {
            for (int i = start; i < end; i++)
            {
                map[col, i] = ch;
            }

            var mid = n >> 1;

            if (mid > 0)
            {

            }
        }

        #endregion

        #region Bezruchenko
        public string[] GetVariantsBezruchenko(string input)
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

        private string GetCaseFromBitField(string input, ulong bitField)
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

        #endregion

        #region Kurtcev
        public string[] GetVariantsKurcev(string input)
        {
            var n = 1 << input.Length;
            var results = new string[n];
            for (int i = 0; i < n; i++)
            {
                BitArray mask = new BitArray(new int[] { i });
                var result = string.Join("", input.Select(x => x));
                for (int j = 0; j < input.Length; j++)
                {
                    if (mask[j])
                    {
                        var insert = char.ToUpper(result[j]).ToString();
                        result = result.Remove(j, 1);
                        result = result.Insert(j, insert);
                    }
                }
                results[i] = result;
            }

            return results;
        }

        #endregion

        #region Panov
        public string[] GetVariantsPanov(string input)
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

        private IEnumerable<string> AddChar(IEnumerable<string> str, char c)
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
        #endregion

        #region Raznopolov
        public string[] GetVariantsRaznopolov(string input)
        {
            var chars = input.ToCharArray();
            var size = (int)Math.Pow(2, input.Length);
            List<string> result = new List<string>(size);

            GetVariantsRaznopolovInternal(chars, 0, result);

            return result.ToArray();
        }

        public void GetVariantsRaznopolovInternal(char[] span, int index, List<string> result)
        {
            if (index == span.Length)
            {
                result.Add(span.ToString());
                return;
            }

            GetVariantsRaznopolovInternal(span, index + 1, result);

            span[index] = Revert(span[index]);
            GetVariantsRaznopolovInternal(span, index + 1, result);
        }

        public string[] GetVariantsRaznopolov2(string input)
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
                result[resultIndex++] = input.ToString();
                return;
            }

            GetVariantsRaznopolov2Internal(input, inputIndex + 1, result, ref resultIndex);

            input[inputIndex] = Revert(input[inputIndex]);
            GetVariantsRaznopolov2Internal(input, inputIndex + 1, result, ref resultIndex);
        }

        private char Revert(char ch)
            => Char.IsLower(ch) ? Char.ToUpper(ch) : Char.ToLower(ch);

        #endregion

        #region Antonov
        public string[] GetVariantsAntonov(string input)
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

        public string[] GetVariantsAntonov2(string input)
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

        #endregion
    }
}
