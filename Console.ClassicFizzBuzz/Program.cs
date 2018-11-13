using Magupisoft.SuperFizzBuzz;
using System;
using System.Diagnostics;

namespace ClassiFizzBuzz
{
    public class Program
    {
        static void Main(string[] args)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Restart();

            // Classic Fizz Buzz Execution
            var fizzBuzzer = new SuperFizzBuzz();
            var results = fizzBuzzer.Execute();  
            var results2 = fizzBuzzer.Execute();   
            Console.WriteLine(string.Join(Environment.NewLine, results));
            Console.WriteLine("----------------------------------");
            Console.WriteLine(string.Join(Environment.NewLine, results2));
            stopWatch.Stop();
            Console.WriteLine("Execution time=" + stopWatch.ElapsedMilliseconds / 1000.0d);
            Console.ReadKey();
        }
    }
}
