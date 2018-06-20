using System.Collections.Generic;
using System.Linq;

namespace FizzBuzz
{
    public class FizzBuzzLogic
    {
        private ICollection<NumberWordPairs> NumberWordPairs { get; set; }

        public FizzBuzzLogic()
        {
            NumberWordPairs = new List<NumberWordPairs>
            {
                new NumberWordPairs { DenominatorToReplace = 3, ReplacementWord = "Fizz" },
                new NumberWordPairs { DenominatorToReplace = 5, ReplacementWord = "Buzz" }
            };
        }

        public FizzBuzzLogic(List<NumberWordPairs> numberWordPairs)
        {
            NumberWordPairs = numberWordPairs.OrderBy(x => x.DenominatorToReplace).ToList();
        }

        public IEnumerable<string> Fizzle()
        {
            for (int i = 1; i < int.MaxValue; i++)
            {
                var replacementWords = NumberWordPairs
                    .Where(x => i % x.DenominatorToReplace == 0)
                    .Select(x => x.ReplacementWord);


                if(replacementWords.Count() > 0)
                {
                    yield return replacementWords.Aggregate((x, result) => x + result);
                }
                else
                {
                    yield return i.ToString();
                }
            }
        }
    }
}
