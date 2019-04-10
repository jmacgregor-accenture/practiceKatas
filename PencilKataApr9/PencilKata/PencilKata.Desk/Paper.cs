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
            var lastIndex = Contents.LastIndexOf(wordToErase);

            Contents = GetUpdatedContentString(lastIndex, wordToErase.Length);
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

        private string GetUpdatedContentString(int startingPoint, int charactersToErase)
        {
            var whiteSpace = GenerateWhiteSpace(charactersToErase);
            var stringToUpdate = Contents;

            var erasedString = stringToUpdate.Remove(startingPoint, charactersToErase);
            var updatedString = erasedString.Insert(startingPoint, whiteSpace);

            return updatedString;
        }
    }
}