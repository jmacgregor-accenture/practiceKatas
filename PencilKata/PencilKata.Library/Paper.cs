namespace PencilKata.Library
{
    public class Paper : IWritable
    {
        public string Contents { get; private set; }
        public void Write(string stringToWrite)
        {
            Contents += stringToWrite;
        }
    }
}