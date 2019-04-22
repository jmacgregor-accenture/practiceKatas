using System.Runtime.Serialization;

namespace PencilKata.Library
{
    public class Pencil
    {
        private int _durability = 4;

        public Pencil(int durability)
        {
            _durability = durability;
        }

        public void Write(IWritable surface, string input)
        {
            var stringToWrite = string.Empty;

            foreach (var character in input)
            {
                if (_durability > 0)
                {
                    stringToWrite += character;
                    _durability--;
                }
                else
                {
                    stringToWrite += ' ';
                }
            }
            
            surface.Write(stringToWrite);
        }
    }
}