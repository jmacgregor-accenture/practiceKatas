namespace PencilKata.Library
{
    public class Paper
    {
        public string Writing { get; set; }
        
        public int FirstOpenSpace { get; set; }

        public int LastErasedSpot { get; set; }

        public Paper(int lengthOfWriting)
        {
            Writing = new string(' ', lengthOfWriting);
        }

        public void Write(IFiniteWritingTool pencil, string input)
        {
            var currentWriting = Writing.ToCharArray();

            LoopThroughInput(pencil, input, currentWriting);

            FirstOpenSpace += input.Length;

            Writing = new string(currentWriting);
        }

        

        public void Erase(Eraser eraser, string inputString)
        {
            var currentWriting = Writing.ToCharArray();
            var indexToStartReplace = Writing.LastIndexOf(inputString) + 
                                      inputString.Length - 1;

            var lastErasedSpot = Writing.LastIndexOf(inputString) + inputString.Length;

            for (var i = inputString.Length; i > 0; i--)
            {
                if (eraser.Durability < 1) break;
                
                eraser.Use(currentWriting[indexToStartReplace]);
                currentWriting[indexToStartReplace] = ' ';
                lastErasedSpot--;
                indexToStartReplace--;
            }

            LastErasedSpot = lastErasedSpot;
            
            Writing = new string(currentWriting);
        }
        
        private void LoopThroughInput(IFiniteWritingTool tool, string input, char[] currentWriting)
        {
            for (var i = 0; i < input.Length; i++)
            {
                if (tool.Durability <= 0) break;

                tool.Use(input[i]);
                currentWriting[FirstOpenSpace + i] = input[i];
            }
        }

        public void Edit(Pencil pencil, string replaceWith)
        {
            var currentWriting = Writing.ToCharArray();

            for (var i = 0; i < replaceWith.Length; i++)
            {
                if (pencil.Durability <= 0) break;
                
                pencil.Use(replaceWith[i]);
                InsertOrReplace(replaceWith, currentWriting, i);
            }
            
            Writing = new string(currentWriting);
        }

        private void InsertOrReplace(string replaceWith, char[] currentWriting, int indexOfInput)
        {
            var replacementChar = '@';

            if (char.IsWhiteSpace(currentWriting[LastErasedSpot + indexOfInput]))
            {
                replacementChar = replaceWith[indexOfInput];
            }

            currentWriting[LastErasedSpot + indexOfInput] = replacementChar;
        }
    }
}