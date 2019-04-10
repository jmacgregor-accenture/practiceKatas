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
            var whiteSpace = string.Empty;

            for (var i = 0; i < wordToErase.Length; i++)
            {
                whiteSpace += " ";
            }
            
            Contents = regex.Replace(Contents, whiteSpace);
        }
    }
}