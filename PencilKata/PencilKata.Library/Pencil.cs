using System;

namespace PencilKata.Library
{
    public class Pencil
    {
        private int _durability;
        private int _maxDurability;
        private int _currentLength;
        
        public Pencil(int pencilDurability, int pencilLength)
        {
            _durability = pencilDurability;
            _maxDurability = _durability;
            _currentLength = pencilLength;
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

        public void Sharpen()
        {
            if (_durability < _maxDurability && _currentLength > 0)
            {
                _durability = _maxDurability;
                _currentLength--;
            }
        }
    }
}