namespace PencilKata.Library
{
    public class Pencil
    {
        public int PointDurability { get; set; }
        
        public Pencil(int initialDurability)
        {
            PointDurability = initialDurability;
        }
        
        public void Write(char character)
        {
            if (char.IsWhiteSpace(character) || PointDurability < 1)
            {
                return;
            }
            
            if (char.IsUpper(character))
            {
                PointDurability -= 2;
            }
            else
            {
                PointDurability -= 1;
            }
        }
    }
}