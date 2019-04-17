using System;

namespace PencilKata.Library
{
    public class Pencil
    {
        private int _pointSharpness;

        public Pencil(int pointSharpness)
        {
            _pointSharpness = pointSharpness;
        }
        
        public string Write(string stringToWrite)
        {
            var returnString = string.Empty;

            foreach (var character in stringToWrite)
            {
                if (_pointSharpness > 0)
                {
                    returnString += character;

                    if (!char.IsWhiteSpace(character))
                    {
                        _pointSharpness--;
                    }
                    
                }
                else
                {
                    returnString += ' ';
                }
            }
            
            return returnString;
        }

        public void WriteTo(IWritable surface, string stringToWrite)
        {
            var writtenString = Write(stringToWrite);
            
            surface.SetContents(writtenString);
        }
    }
}