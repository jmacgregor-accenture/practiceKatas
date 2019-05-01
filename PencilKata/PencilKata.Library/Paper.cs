using System.Collections.Generic;

namespace PencilKata.Library
{
    public class Paper
    {
        public string Writing { get; set; }
        
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

        public void Erase(Eraser eraser, string inputString)
        {
            var currentWriting = Writing.ToCharArray();
            var indexToStartReplace = Writing.LastIndexOf(inputString) + inputString.Length;

            for (var i = inputString.Length; i > 0; i--)
            {
                if (eraser.Durability < 1) break;
                
                eraser.Erase(currentWriting[indexToStartReplace - 1]);
                currentWriting[indexToStartReplace - 1] = ' ';
                indexToStartReplace--;
            }
            
            Writing = new string(currentWriting);
        }
    }
}