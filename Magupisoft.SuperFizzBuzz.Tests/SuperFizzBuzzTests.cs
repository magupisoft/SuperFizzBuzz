using System.Collections.Generic;
using Magupisoft.SuperFizzBuzz;
using Xunit;

namespace SuperFizzBuzzTests
{
    public class SuperFizzBuzzTests
    {
        private readonly Xunit.Abstractions.ITestOutputHelper output;

        public SuperFizzBuzzTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            this.output = output;
        }

        public static IEnumerable<object[]> Numbers()
        {
            yield return new object[] { new long[] { 1, 3, 15, 30, 45 }, new List<string> { "1", "Fizz", "FizzBuzz", "FizzBuzz", "FizzBuzz" } };
            yield return new object[] { new long[] { -4, -6, -10 }, new List<string> { "-4", "Fizz", "Buzz" } };
            yield return new object[] { new long[] { -2, 2, 0 }, new List<string> { "-2", "2", "FizzBuzz" } };
            yield return new object[] { new long[] { int.MinValue, -1, 0, int.MaxValue }, new List<string> { int.MinValue.ToString(), "-1", "FizzBuzz", int.MaxValue.ToString() } };
        }

        public static IEnumerable<object[]> Ranges()
        {
            yield return new object[] { 2, 35 };
            //yield return new object[] { 1, 1000000000L };
            yield return new object[] { -1, 35 };
        }

        public static IEnumerable<object[]> InvalidRanges()
        {
            yield return new object[] { long.MinValue, 1, "Start value out of allowed limits." };
            yield return new object[] { long.MaxValue, 1, "Start value out of allowed limits." };
            yield return new object[] { 1, long.MinValue, "End value out of allowed limits." };
            yield return new object[] { 1, long.MaxValue, "End value out of allowed limits." };
            yield return new object[] { 1, 0, "End value should be greater than Start value." };
            yield return new object[] { default(long), default(long), "Start and End values should be different than default." };
        }

        [Theory, MemberData(nameof(Numbers))]
        public void ReturnFizzBuzzOutputForSuppliedNumbers(long[] numbers, List<string> expectedResult)
        {
            var fizzBuzzer = new SuperFizzBuzz(numbers);
            var result = fizzBuzzer.Execute();
            Assert.Equal(expectedResult, result);
        }

        [Theory, MemberData(nameof(Ranges))]
        public void ReturnFizzBuzzOutputForSuppliedRanges(long start, long end)
        {
            var fizzBuzzer = new SuperFizzBuzz(start, end);
            var result = fizzBuzzer.Execute();
            
            foreach (var item in result)
            {
                System.Console.WriteLine(item);
            }
        }


        [Fact]
        public void GenerateTokensOtherThanDefaultFizzBuzz()
        {
            var fizzBuzzer = new SuperFizzBuzz(new List<long>()
            {
                1,
                52,
                36,
                468
            },
                rules: new List<FizzBuzzToken> {
                new FizzBuzzToken{ Key = 4, Token = "Frog" },
                new FizzBuzzToken{ Key = 13, Token =  "Duck" },
                new FizzBuzzToken{ Key = 9, Token =  "Chicken" },
            });
            var result = fizzBuzzer.Execute();
            Assert.Equal(new List<string> { "1", "FrogDuck", "FrogChicken", "FrogDuckChicken" }, result);
        }

        [Theory, MemberData(nameof(InvalidRanges))]
        public void ValidatesRange(long start, long end, string expectedErrorMessage)
        {
            System.ArgumentException ex = Assert.Throws<System.ArgumentException>(() => new SuperFizzBuzz(start, end));
            Assert.Equal(expectedErrorMessage, ex.Message);
        }
    }
}
