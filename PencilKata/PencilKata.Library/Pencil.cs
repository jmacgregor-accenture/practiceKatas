namespace PencilKata.Library
{
    public class Pencil
    {
        public void Write(IWritable surface, string input)
        {
            surface.Write(input);
        }
    }
}