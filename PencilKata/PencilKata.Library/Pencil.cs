using System;

namespace PencilKata.Library
{
    public class Pencil
    {
        public string Write(string stringToWrite)
        {
            return stringToWrite;
        }

        public void Write(Paper paperToMark, string stringToWrite)
        {
            paperToMark.Contents = Write(stringToWrite);
        }
    }
}