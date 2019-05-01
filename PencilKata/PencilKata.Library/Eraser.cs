namespace PencilKata.Library
{
    public class Eraser : IFiniteWritingTool
    {
        public int Durability { get; set; }
        
        public Eraser(int durability)
        {
            Durability = durability;
        }

        public void Use(char characterToErase)
        {
            if (char.IsWhiteSpace(characterToErase)) return;
            
            Durability--;
        }
    }
}