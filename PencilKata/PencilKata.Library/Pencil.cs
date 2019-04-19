namespace PencilKata.Library
{
    public class Pencil
    {
        public void Write(IWritable paper, string stringToWrite)
        {
            paper.Write(stringToWrite);
        }
    }
}