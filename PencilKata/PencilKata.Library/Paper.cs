namespace PencilKata.Library
{
    public class Paper
    {
        public string Writing
        {
            get => GetWriting();
            set => _currentWriting = value.ToCharArray();
        }
        
        public int FirstOpenSpace { get; set; }

        public int LastErasedSpot { get; set; }

        private char[] _currentWriting;

        public Paper(int lengthOfWriting)
        {
            Writing = new string(' ', lengthOfWriting);
        }

        public void Write(IFiniteWritingTool pencil, string input)
        {
            LoopThroughInput(pencil, input, FirstOpenSpace);

            FirstOpenSpace += input.Length;

            Writing = new string(_currentWriting);
        }
        
        public void Erase(Eraser eraser, string inputString)
        {
            var indexToStartReplace = Writing.LastIndexOf(inputString) + 
                                      inputString.Length - 1;

            var lastErasedSpot = Writing.LastIndexOf(inputString) + inputString.Length;

            for (var i = inputString.Length; i > 0; i--)
            {
                if (eraser.Durability < 1) break;
                
                eraser.Use(_currentWriting[indexToStartReplace]);
                _currentWriting[indexToStartReplace] = ' ';
                
                lastErasedSpot--;
                indexToStartReplace--;
            }

            LastErasedSpot = lastErasedSpot;
            
            Writing = new string(_currentWriting);
        }
        
        public void Edit(Pencil pencil, string replaceWith)
        {
            LoopThroughInput(pencil, replaceWith, LastErasedSpot);
            
            Writing = new string(_currentWriting);
        }
        
        private void LoopThroughInput(IFiniteWritingTool tool, string input, 
            int pointToStartWriting)
        {
            for (var i = 0; i < input.Length; i++)
            {
                if (tool.Durability <= 0) break;

                tool.Use(input[i]);
                InsertOrReplace(input, i, pointToStartWriting);
            }
        }
        
        private void InsertOrReplace(string replaceWith, int indexOfInput, int startPoint)
        {
            var replacementChar = '@';

            if (char.IsWhiteSpace(_currentWriting[startPoint + indexOfInput]))
            {
                replacementChar = replaceWith[indexOfInput];
            }

            _currentWriting[startPoint + indexOfInput] = replacementChar;
        }

        private string GetWriting()
        {
            return new string(_currentWriting);
        }
    }
}