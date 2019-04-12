using System;

namespace PencilKata.Library
{
    public class Pencil
    {
        private Paper _paper;
        private int _durability;
        
        public Pencil(Paper paper, int durability)
        {
            _paper = paper;
            _durability = durability;
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
    }
}