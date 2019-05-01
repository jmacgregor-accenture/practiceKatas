namespace PencilKata.Library
{
    public interface IFiniteWritingTool
    {
        int Durability { get; set; }
        void Use(char character);
    }
}