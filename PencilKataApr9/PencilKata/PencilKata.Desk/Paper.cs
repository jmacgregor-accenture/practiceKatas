using System;

namespace PencilKata.Library
{
    public class Paper
    {
        public string Contents { get; private set; }
        
        public void Write(string input)
        {
            Contents = input;
        }

        
    }
}