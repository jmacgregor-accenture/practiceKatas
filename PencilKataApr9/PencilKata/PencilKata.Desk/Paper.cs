using System;
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
            var regex = new Regex(wordToErase, RegexOptions.RightToLeft);
            var whiteSpace = GenerateWhiteSpace(wordToErase.Length);
            
            Contents = regex.Replace(Contents, whiteSpace);
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