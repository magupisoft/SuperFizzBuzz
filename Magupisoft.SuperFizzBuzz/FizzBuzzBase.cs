using System;
using System.Collections.Generic;

namespace Magupisoft.SuperFizzBuzz
{
    public abstract class FizzBuzzBase
    {
        /// <summary>
        /// Get or set Rules for FizzBuzz , defaults to Fizz -> 3, Buzz -> 5
        /// </summary>
        public IList<FizzBuzzToken> Token { get; private set; } = new List<FizzBuzzToken>() {
            new FizzBuzzToken{ Key = 3, Token ="Fizz" },
            new FizzBuzzToken{ Key = 5, Token= "Buzz" }
        };

        /// <summary>
        /// Start of range, defaults to 1
        /// </summary>
        public long Start { get; private set; } = 1L;

        /// <summary>
        /// End of range, defaults to 100
        /// </summary>
        public long End { get; private set; } = 100L;

        /// <summary>
        /// Default constructor, initialize default values
        /// </summary>
        public FizzBuzzBase()
        {
        }

        /// <summary>
        ///  Initialize tokens
        /// </summary>
        /// <param name="token"></param>
        public FizzBuzzBase(IList<FizzBuzzToken> token)
        {
            if (token != null && token.Count > 0)
            {
                Token = token;
            }
        }

        /// <summary>
        /// Defines ranges and tokens
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="tokens"></param>
        protected FizzBuzzBase(long start, long end, IList<FizzBuzzToken> tokens)  : this(tokens)
        {
            Start = start;
            End = end;
            ValidateRange();
        }

        /// <summary>
        /// Set of provided numbers
        /// </summary>
        protected IEnumerable<long> Numbers { get; set; }

        /// <summary>
        /// Get range of numbers
        /// </summary>
        /// <returns></returns>
        protected IEnumerable<long> GetRange()
        {
            for (var pointer = Start; pointer <= End; pointer += 1)
            {
                yield return pointer;
            }
        }
         
        /// <summary>
        /// Check if number is divisible by divisor
        /// </summary>
        /// <param name="number"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        protected bool IsDivisible(long number, long divisor)
        {
            return number % divisor == 0;
        }

        /// <summary>
        /// Validates Start and End values for defining a valid range.
        /// </summary>
        protected void ValidateRange()
        {
            if (Start < int.MinValue || Start > int.MaxValue)
            {
                throw new ArgumentException("Start value out of allowed limits.");
            }

            if (End < int.MinValue || End > int.MaxValue)
            {
                throw new ArgumentException("End value out of allowed limits.");
            }

            if (End < Start)
            {
                throw new ArgumentException("End value should be greater than Start value.");
            }

            if (End == default(long) && Start == default(long))
            {
                throw new ArgumentException("Start and End values should be different than default.");
            }

        }

        /// <summary>
        /// Execute FizzBuzz..er
        /// </summary>
        /// <returns></returns>
        abstract public IEnumerable<string> Execute();
    }
}
