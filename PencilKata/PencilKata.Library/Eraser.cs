namespace PencilKata.Library
{
    public class Eraser
    {
        public int Durability { get; set; }
        
        public Eraser(int durability)
        {
            Durability = durability;
        }

        public void Erase(char chracterToErase)
        {
            Durability--;
        }
    }
}