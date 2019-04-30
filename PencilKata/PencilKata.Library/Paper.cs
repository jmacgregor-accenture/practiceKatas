using System.Collections.Generic;

namespace PencilKata.Library
{
    public class Paper
    {
        private int _lastIndexWritten;

        public Paper(int lengthOfWriting)
        {
            Writing = new string(' ', lengthOfWriting);
        }

        public void Write(Pencil pencil, string input)
        {
            var currentWriting = Writing.ToCharArray();

            for (var i = 0; i < input.Length; i++)
            {
                if (pencil.PointDurability <= 0) break;
                
                pencil.Write(input[i]);
                currentWriting[_lastIndexWritten + i] = input[i];

            }

            _lastIndexWritten += input.Length;

            Writing = new string(currentWriting);
        }

        public string Writing { get; set; }
    }
}