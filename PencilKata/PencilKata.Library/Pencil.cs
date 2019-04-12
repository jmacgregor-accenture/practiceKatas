using System;

namespace PencilKata.Library
{
    public class Pencil
    {
        public Paper Paper { get; set; }
        private int _durability;
        
        public Pencil(Paper paper, int durability)
        {
            Paper = paper;
            _durability = durability;
        }

        public void Write(string inputString)
        {
            foreach (var character in inputString)
            {
                if (_durability > 0)
                {
                    Paper.Text += character;
                    if (!char.IsWhiteSpace(character))
                    {
                        _durability--;
                    }
                }
                else
                {
                    Paper.Text += ' ';
                }
            }
        }
    }
}