using System;

namespace PencilKata.Library
{
    public class Pencil
    {
        private int _durability;
        
        public Pencil(int pencilDurability)
        {
            _durability = pencilDurability;
        }

        public string Write(string stringToWrite)
        {
            var returnString = string.Empty;

            foreach (var character in stringToWrite)
            {
                if (_durability > 0)
                {
                    returnString += character;

                    if (!char.IsWhiteSpace(character))
                    {
                        _durability--;
                    }

                    if (char.IsUpper(character))
                    {
                        _durability--;
                    }
                    
                }
                else
                {
                    returnString += " ";
                }
            }
            
            return returnString;
        }

        public void Write(Paper paperToMark, string stringToWrite)
        {
            paperToMark.Contents += Write(stringToWrite);
        }
    }
}