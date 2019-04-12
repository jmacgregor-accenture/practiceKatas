using System;

namespace PencilKata.Library
{
    public class Pencil
    {
        private Paper _paper;
        private int _durability;
        private int _initialDurability;
        private int _pencilLength;
        private int _eraserSize;
        
        public Pencil(Paper paper, int durability, int initialLength, int eraserSize)
        {
            _paper = paper;
            _initialDurability = durability;
            _durability = _initialDurability;
            _pencilLength = initialLength;
            _eraserSize = eraserSize;

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
            if (_pencilLength > 0)
            {
                _durability = _initialDurability;
                _pencilLength--;
            }
        }

        public void Erase(string eraseText)
        {
            var endingIndex = GetEndingIndexOfEraseText(eraseText);
            if (endingIndex < 0)
            {
                return;
            }
            var arrayThing = _paper.Text.ToCharArray();

            for (int i = 0; i < eraseText.Length; i++)
            {
                if (_eraserSize > 0)
                {
                    var indexToReplace = endingIndex - i;
                    arrayThing[indexToReplace] = ' ';
                    _eraserSize--;
                }
            }

            _paper.Text = new string(arrayThing);
        }

        private int GetEndingIndexOfEraseText(string eraseText)
        {
            var startingIndex = _paper.Text.LastIndexOf(eraseText);
            if (startingIndex < 0)
            {
                return startingIndex;
            }
            var wordLengthIndexized = eraseText.Length - 1;
            return startingIndex + wordLengthIndexized;
        }
    }
}