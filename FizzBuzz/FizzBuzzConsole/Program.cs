using FizzBuzz;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzzConsole
{
    class Program
    {
        static void Main()
        {
            var selectionString = Selection().ToString();
            Console.WriteLine();

            if (int.TryParse(selectionString, out int selection))
            {
                var howManyItemsToDisplay = GetHowManyItems();

                if (selection == 0)
                {
                    FizzBuzzDefault(howManyItemsToDisplay);
                }
                if (selection == 1)
                {
                    FizzBuzzCustom(howManyItemsToDisplay);
                }
            }
        }

        private static void FizzBuzzCustom(int howManyItemsToDisplay)
        {
            var fizzBuzzConfig = new List<NumberWordPairs>
            {
                new NumberWordPairs
                {
                    DenominatorToReplace = 20,
                    ReplacementWord = "The Number 20"
                },
                new NumberWordPairs
                {
                    DenominatorToReplace = 19,
                    ReplacementWord = "The Number 19"
                },
                new NumberWordPairs
                {
                    DenominatorToReplace = 40,
                    ReplacementWord = "The Number 40"
                }
            };

            var fizzBuzzLogic = new FizzBuzzLogic(fizzBuzzConfig);

            FizzBuzz(howManyItemsToDisplay, fizzBuzzLogic);
        }

        private static void FizzBuzzDefault(int howManyItemsToDisplay)
        {
            FizzBuzz(howManyItemsToDisplay, new FizzBuzzLogic());
        }

        private static void FizzBuzz(int howManyItemsToDisplay, FizzBuzzLogic fizzBuzzLogic)
        {
            foreach (var item in fizzBuzzLogic.Fizzle().Take(howManyItemsToDisplay))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Press any key to end");
            Console.ReadKey();
        }

        private static int GetHowManyItems()
        {
            Console.WriteLine("How many items to do you want to display?");

            var items = Console.ReadLine();

            Console.WriteLine();

            if (int.TryParse(items, out int howManyItemsToDisplay) == false)
            {
                Console.WriteLine("Please enter a number");
                return GetHowManyItems();
            }

            return howManyItemsToDisplay;
        }

        private static char Selection()
        {
            Console.WriteLine("(0) Run normal FizzBuzz");
            Console.WriteLine("(1) Run your custom FizzBuzz");
            Console.WriteLine("Any other to exit");

            return Console.ReadKey().KeyChar;
        }
    }
}
