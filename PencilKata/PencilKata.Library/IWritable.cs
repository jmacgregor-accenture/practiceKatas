namespace PencilKata.Library
{
    public interface IWritable
    {
        string Contents { get; }
        void SetContents(string stringToAdd);
    }
}