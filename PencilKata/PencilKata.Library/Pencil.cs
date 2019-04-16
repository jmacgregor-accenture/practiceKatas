using System;
using System.Collections.Generic;
using System.Linq;

namespace PencilKata.Library
{
    public class Pencil
    {
        private int _pointDurability;
        private int _maxDurabilty;
        private int _currentLength;

        public Pencil(int durability, int length)
        {
            _pointDurability = durability;
            _maxDurabilty = durability;
            _currentLength = length;
        }

        public string Write(string input)
        {
            var writtenString = string.Empty;

            foreach (var character in input)
            {
                if (_pointDurability > 0)
                {
                    writtenString += character;

                    if (!char.IsWhiteSpace(character))
                    {
                        _pointDurability--;
                    }

                    if (char.IsUpper(character))
                    {
                        _pointDurability--;
                    }
                    
                }
                else
                {
                    writtenString += " ";
                }
            }
            
            return writtenString;
        }

        public void Write(Paper paper, string input)
        {
            paper.Contents += Write(input);
        }

        public void Sharpen()
        {
            if (_pointDurability < _maxDurabilty && _currentLength > 0)
            {
                _pointDurability = _maxDurabilty;
                _currentLength--;
            }
        }

        public void Erase(Paper paper, string eraseString)
        {
            var paperContents = paper.Contents.ToCharArray();    
            var startIndexOfErase = paper.Contents.LastIndexOf(eraseString, StringComparison.Ordinal);

            for (var i = startIndexOfErase; i < paperContents.Length; i++)
            {
                paperContents[i] = ' ';
            }

            paper.Contents = new string(paperContents);
        }
    }
}