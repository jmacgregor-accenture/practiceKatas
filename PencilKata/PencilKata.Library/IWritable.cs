using System;

namespace PencilKata.Library
{
    public interface IWritable
    {
        void Write(string inputString);
        string Read();
    }
}