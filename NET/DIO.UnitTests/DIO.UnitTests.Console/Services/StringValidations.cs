using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO.UnitTests.Console.Services
{
    public class StringValidations
    {
        public int ReturnQuantityCharacters(string text)
        {
            var numbersCharacters = text.Length;

            return numbersCharacters;
        }

        public bool ContainsCharacter(string text, string searchText)
        {
            var contains = text.Contains(searchText);
            return contains;
        }

        public bool TextEndsWith(string text, string searchText)
        {
            var ends = text.EndsWith(searchText);
            return ends;
        }
    }
}