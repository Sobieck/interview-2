using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FizzBuzz.Tests
{
    public class FuzzBuzzLogicCustomConfigurationTests
    {
        private FizzBuzzLogic sut;

        public FuzzBuzzLogicCustomConfigurationTests()
        {
            var config = new List<NumberWordPairs>
            {
                new NumberWordPairs
                {
                    DenominatorToReplace = 11,
                    ReplacementWord = "Replace 11"
                },
                new NumberWordPairs
                {
                    DenominatorToReplace = 5,
                    ReplacementWord = "Replace 5"
                },
                new NumberWordPairs
                {
                    DenominatorToReplace = 20,
                    ReplacementWord = "Replace 20"
                }
            };

            sut = new FizzBuzzLogic(config);
        }

        [Fact]
        public void FizzBuzzLogic_Should_Return_5()
        {
            var expected = new List<string> { "1", "2", "3", "4", "Replace 5" };

            var result = sut.Fizzle().Take(5);

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void FizzBuzzLogic_Should_Return_CorrectFor_55()
        {
            var expected = "Replace 5Replace 11";

            var result = sut.Fizzle().ElementAt(54);

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void FizzBuzzLogic_Should_Return_CorrectFor_1100()
        {
            var expected = "Replace 5Replace 11Replace 20";

            var result = sut.Fizzle().ElementAt(1099);

            result.Should().BeEquivalentTo(expected);
        }
    }
}
