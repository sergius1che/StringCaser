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
            //Test();
            BenchmarkRunner.Run<Bench>();
        }

        private static void Test()
        {
            var b = new Bench();

            Console.WriteLine("ab cases:");
            Print(b.GetVariantsBezruchenko("ab"));

            Console.WriteLine("abc cases:");
            Print(b.GetVariantsBezruchenko("abc"));

            Console.WriteLine("qwerty cases:");
            Print(b.GetVariantsBezruchenko("qwerty"));
        }

        private static void Print(string[] strs)
        {
            for (var i = 0; i < strs.Length; i++)
            {
                Console.WriteLine($"{(i + 1),5}: {strs[i]}");
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
            var chars = INPUT.ToCharArray();
            var size = (int)Math.Pow(2, INPUT.Length);
            List<string> result = new List<string>(size);

            GetVariantsRaznopolov(chars, 0, result);

            return result.ToArray();
        }

        [Benchmark]
        public string[] GetVariantsRaznopolov2()
        {
            var chars = INPUT.ToCharArray();
            var size = (int)Math.Pow(2, INPUT.Length);
            var result = new string[size];
            var resultIndex = 0;

            GetVariantsRaznopolov2(chars, 0, result, ref resultIndex);

            return result;
        }

        public string[] GetVariatnsChechin(string input)
        {
            input = input.ToLower();
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

        public void GetVariantsRaznopolov(char[] span, int index, List<string> result)
        {
            if (index == span.Length)
            {
                result.Add(span.ToString());
                return;
            }

            GetVariantsRaznopolov(span, index + 1, result);

            span[index] = Revert(span[index]);
            GetVariantsRaznopolov(span, index + 1, result);
        }

        private void GetVariantsRaznopolov2(char[] input, int inputIndex, string[] result, ref int resultIndex)
        {
            if (inputIndex == input.Length)
            {
                result[resultIndex++] = input.ToString();
                return;
            }

            GetVariantsRaznopolov2(input, inputIndex + 1, result, ref resultIndex);

            input[inputIndex] = Revert(input[inputIndex]);
            GetVariantsRaznopolov2(input, inputIndex + 1, result, ref resultIndex);
        }

        private char Revert(char ch)
            => Char.IsLower(ch) ? Char.ToUpper(ch) : Char.ToLower(ch);

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
    }
}
