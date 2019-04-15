using System;

namespace PencilKata.Library
{
    public class Pencil
    {
        public string Write(string input)
        {
            return input;
        }

        public void Write(Paper paper, string input)
        {
            paper.Contents = input;
        }
    }
}