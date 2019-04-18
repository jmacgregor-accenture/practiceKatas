namespace PencilKata.Library
{
    public interface IWritable
    {
        string Contents { get; }
        void Write(string stringToWrite);
    }
}