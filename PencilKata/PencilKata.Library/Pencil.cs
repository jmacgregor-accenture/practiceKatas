namespace PencilKata.Library
{
    public class Pencil
    {
        private int _durability;

        public Pencil(int durability)
        {
            _durability = durability;
        }
        
        public void Write(IWritable paper, string stringToWrite)
        {
            var writtenString = string.Empty;

            foreach (var character in stringToWrite)
            {
                if (_durability > 0)
                {
                    writtenString += character;
                    _durability--;
                }
                else
                {
                    writtenString += " ";
                }
            }
            
            paper.Write(writtenString);
        }
    }
}