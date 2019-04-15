using System;

namespace PencilKata.Library
{
    public class Pencil
    {
        private int _pointDurability;

        public Pencil(int durability)
        {
            _pointDurability = durability;
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
    }
}