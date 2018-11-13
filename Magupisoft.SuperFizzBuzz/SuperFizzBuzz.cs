using System.Collections.Generic;
using System.Linq;

namespace Magupisoft.SuperFizzBuzz
{
    public class SuperFizzBuzz : FizzBuzzBase
    {
        /// <summary>
        /// Default constructor, initializes with default FizzBuzz values.
        /// Range 1...100, Fizz -> 3, Buzz -> 5, FizzBuzz -> 3 && 5 
        /// </summary>
        public SuperFizzBuzz()
        {
        }

        /// <summary>
        /// Setup Rules for FizzBuzz
        /// </summary>
        /// <param name="rules"></param>
        private SuperFizzBuzz(IList<FizzBuzzToken> rules = null)  : base(rules)
        {
        }

        /// <summary>
        /// Initialize SuperFizzBuzz class with a supplied set of numbers
        /// And Optionally a set of custom rules
        /// </summary>
        /// <param name="numbers"> Supplied set of number</param>
        /// <param name="rules"> Optional FizzBuzz rules</param>
        public SuperFizzBuzz(IEnumerable<long> numbers, IList<FizzBuzzToken> rules  = null) : this(rules) 
        {
            Numbers = numbers;
        }

        /// <summary>
        /// Initialize SuperFizzBuzz class with a defined range of numbers
        /// And Optionally a set of custom rules
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="rules"> Optional FizzBuzz rules</param>
        public SuperFizzBuzz(long start, long end, IList<FizzBuzzToken> rules = null)  : base(start, end, rules)
        {
        }

        /// <summary>
        /// Return Fizz Buzz results
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<string> Execute()
        {
            var numbers = Numbers ?? GetRange();
            return numbers.Select(ApplyingRules).AsParallel().AsOrdered(); 
        }

        private string ApplyingRules(long num)
        {
            return Token.Aggregate(
                                    seed: (string)null,
                                    func: (str, rule) =>
                                                        IsDivisible(num, rule.Key)
                                                        ?
                                                            (str == null ? rule.Token : str + rule.Token)
                                                        :
                                                            str
                                  )
                                  ??
                                  num.ToString();
        }
    }
}
