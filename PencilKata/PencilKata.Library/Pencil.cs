using System;

namespace PencilKata.Library
{
    public class Pencil
    {
        private Paper _paper;
        private int _durability;
        private int _initialDurability;
        private int _pencilLength;
        
        public Pencil(Paper paper, int durability, int initialLength)
        {
            _paper = paper;
            _initialDurability = durability;
            _durability = _initialDurability;

        }

        public void Write(string inputString)
        {
            foreach (var character in inputString)
            {
                if (_durability > 0)
                {
                    _paper.Text += character;
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
                    _paper.Text += ' ';
                }
            }
        }

        public void Sharpen()
        {
            _durability = _initialDurability;
        }
    }
}