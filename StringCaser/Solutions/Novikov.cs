using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace StringCaser.Solutions
{
    [MemoryDiagnoser]
    public class Novikov : ISolution
    {
        [Arguments("qwertyuiop")]
        [Benchmark]
        public string[] Do(string input)
        {
            var variantsList = new List<string>();
            var variantsCounter = 1 << input.Length;
            var binArray = new string[variantsCounter];

            for (int i = 0; i < variantsCounter; i++)
            {
                string binary = Convert.ToString(i, 2);

                if (binary.Length < input.Length)
                {
                    var lenght = input.Length - binary.Length;
                    var array = new char[input.Length];

                    for (int j = 0; j < lenght; j++)
                    {
                        array[j] = '0';
                    }

                    var binaryCharArray = binary.ToCharArray();
                    int a = 0;

                    for (int j = lenght; j < input.Length; j++)
                    {

                        array[j] = binaryCharArray[a];
                        a++;
                    }

                    binary = new string(array);
                }

                binArray[i] = binary;
            }

            for (int i = 0; i < binArray.Length; i++)
            {
                var array = binArray[i].ToCharArray();
                var inputCharArray = input.ToLower().ToCharArray();

                for (int j = 0; j < array.Length; j++)
                {
                    if (array[j] == '1')
                    {
                        inputCharArray[j] = char.ToUpper(inputCharArray[j]);
                    }
                }

                variantsList.Add(new string(inputCharArray));
            }

            return variantsList.ToArray();
        }
    }
}
