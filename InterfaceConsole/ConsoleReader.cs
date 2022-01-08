using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoGarage.InterfaceConsole
{
    internal class ConsoleReader : IReader
    {
        public IWriter Writer { get; set; }

        int IReader.ReadId(int lowerBound, int higherBound)
        {
            bool valueIsCorrect = false;
            int outputValue = 0;
            while (!valueIsCorrect)
            {
                var userInput = Console.ReadLine();
                if (int.TryParse(userInput, out outputValue))
                {
                    if (outputValue >= lowerBound && outputValue <= higherBound)
                    {
                        valueIsCorrect = true;
                    }
                }
            }
            return outputValue;
        }

        string IReader.ReadText()
        {
            // TODO : une boucle, tant que c'est "null", refaire un readline
            bool stringIsCorrect = false;

            var InputUserString = Console.ReadLine();
            while (!stringIsCorrect)
            {
                if (InputUserString != null)
                {
                    stringIsCorrect = true;
                }
            }
            return InputUserString;
        }
    }
}
