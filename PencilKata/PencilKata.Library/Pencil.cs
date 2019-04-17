using System;

namespace PencilKata.Library
{
    public class Pencil
    {
        public string Write(string stringToWrite)
        {
            return stringToWrite;
        }

        public void WriteTo(IWritable surface, string stringToWrite)
        {
            surface.SetContents(stringToWrite);
        }
    }
}