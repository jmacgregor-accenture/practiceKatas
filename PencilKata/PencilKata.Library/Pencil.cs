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
                    _pointSharpness--;
                }
            }
            
            return returnString;
        }

        public void WriteTo(IWritable surface, string stringToWrite)
        {
            surface.SetContents(Write(stringToWrite));
        }
    }
}