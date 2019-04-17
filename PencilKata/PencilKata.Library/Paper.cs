namespace PencilKata.Library
{
    public class Paper : IWritable
    {
        public string Contents { get; private set; }
        public void SetContents(string stringToAdd)
        {
            Contents += stringToAdd;
        }
    }
}