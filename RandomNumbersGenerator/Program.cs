using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomNumbersGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();
            var min = 1;
            var max = 100;
            var avg = 20;

            var count = 5000;

            var numbers = new List<int>();

            for (var i = 0; i < count; i++)
            {
                var random1 = rnd.Next(min, avg + 1);
                var random2 = rnd.Next(avg + 2, max + 1);
                var randoms = new List<int>();
                randoms.AddRange(Enumerable.Repeat<int>(random2, avg - min));
                randoms.AddRange(Enumerable.Repeat<int>(random1, max - avg));

                var generatedNumber = randoms[rnd.Next(randoms.Count)];
                numbers.Add(generatedNumber);
            }

            numbers = numbers.OrderBy(x => x).ToList();
            var groups = numbers.GroupBy(x => x).OrderByDescending(x => x.Count()).ToList();
            groups.ForEach(x => Console.WriteLine($"{x.Key}: {x.Count()}"));
            Console.WriteLine($"Average: {numbers.Average(x => x)}");
            Console.WriteLine($"Sum: {numbers.Sum(x => x)}");
            Console.WriteLine($"Count of numbers: {groups.Count}");
        }
    }
}