using Magupisoft.SuperFizzBuzz;
using System;
using System.Collections.Generic;

namespace AdvancedFizzBuzz
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Advanced Fizz Buzz Execution
            var fizzBuzzer = new SuperFizzBuzz(
                start: -15,
                end: 145,
                rules: new List<FizzBuzzToken> {
                           new FizzBuzzToken { Key = 3, Token = "Fizz" },
                           new FizzBuzzToken { Key = 7,  Token ="Buzz" },
                           new FizzBuzzToken { Key = 38,  Token ="Bazz" }
                        });
            var results = fizzBuzzer.Execute();

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
