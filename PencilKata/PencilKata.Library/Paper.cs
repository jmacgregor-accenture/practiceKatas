using System;

namespace PencilKata.Library
{
    public class Paper
    {
        private string _contents;

        public void Write(string input)
        {
            _contents = input;
        }

        public string Read()
        {
            return _contents;
        }
    }
}