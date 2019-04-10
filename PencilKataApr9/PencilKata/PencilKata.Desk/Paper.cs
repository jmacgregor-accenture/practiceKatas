using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace PencilKata.Desk
{
    public class Paper
    {
        public string Contents { get; private set; }
        
        public void Write(string input)
        {
            Contents += input;
        }


        public void Erase(string wordToErase)
        {
            var whiteSpace = GenerateWhiteSpace(wordToErase.Length);
            var lastIndex = Contents.LastIndexOf(wordToErase);

            Contents = Contents.Remove(lastIndex, wordToErase.Length);
            Contents += whiteSpace;
        }

        private string GenerateWhiteSpace(int numberOfSpaces)
        {
            var whiteSpace = string.Empty;
            
            for (var i = 0; i < numberOfSpaces; i++)
            {
                whiteSpace += " ";
            }

            return whiteSpace;
        }
    }
}