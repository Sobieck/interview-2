using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FizzBuzz.Tests
{
    public class FizzBuzzLogicTests
    {
        private FizzBuzzLogic sut;

        public FizzBuzzLogicTests()
        {
            sut = new FizzBuzzLogic();
        }

        [Fact]
        public void FizzBuzzLogic_Should_Return_1()
        {
            var expected = new List<string> { "1" };

            var result = sut.Fizzle().Take(1);

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void FizzBuzzLogic_Should_Return_9()
        {
            var expected = new List<string> { "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz" };

            var result = sut.Fizzle().Take(9);

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void FizzBuzzLogic_Should_Return_Fizz_For_Third_Item()
        {
            var expected = "Fizz";

            var result = sut.Fizzle().ElementAt(2);

            result.Should().Be(expected);
        }

        [Fact]
        public void FizzBuzzLogic_Should_Return_Buzz_For_Fifth_Item()
        {
            var expected = "Buzz";

            var result = sut.Fizzle().ElementAt(4);

            result.Should().Be(expected);
        }

        [Fact]
        public void FizzBuzzLogic_Should_Return_FizzBuzz_For_Fifthteenth_Item()
        {
            var expected = "FizzBuzz";

            var result = sut.Fizzle().ElementAt(14);

            result.Should().Be(expected);
        }
    }
}
