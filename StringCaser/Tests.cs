using System;
using System.Linq;

namespace StringCaser
{
    public class Tests
    {
        private string _test1 = "ab";
        private string _test2 = "abc";
        private string[] _expect1 = new[] { "ab", "Ab", "aB", "AB" };
        private string[] _expect2 = new[] { "abc", "Abc", "aBc", "ABc", "abC", "AbC", "aBC", "ABC" };

        public static Tests Instance => new Tests();

        public bool Execute(params Type[] solutions)
        {
            var passed = true;
            foreach (var solution in solutions)
            {
                var instance = (ISolution)Activator.CreateInstance(solution);
                passed &= ExecuteInternal(solution.Name, instance.Do, _test1, _expect1);
                passed &= ExecuteInternal(solution.Name, instance.Do, _test2, _expect2);
            }

            return passed;
        }

        private bool ExecuteInternal(string testName, Func<string, string[]> func, string input, string[] expect)
        {
            Console.WriteLine($"Start test '{input}' for {testName}");

            var passed = true;

            var result = func(input);

            passed &= expect.Length == result.Length;

            var expectSorted = expect.OrderBy(x => x).ToArray();
            var resultSorted = result.OrderBy(x => x).ToArray();

            if (passed)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    passed &= expectSorted[i] == resultSorted[i];
                }
            }

            if (passed)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Test passed!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Test failed!");
                Console.Write("Expected array: ");
                PrintArr(expectSorted);
                Console.Write("Resulted array: ");
                PrintArr(resultSorted);
            }

            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();

            return passed;
        }

        private void PrintArr(string[] arr)
        {
            Console.Write("[");
            Console.Write(string.Join(", ", arr.Select(x => "\"" + x + "\"")));
            Console.Write("]");

            Console.WriteLine();
        }
    }
}
