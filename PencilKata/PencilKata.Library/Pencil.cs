namespace PencilKata.Library
{
    public class Pencil
    {
        
        private int _initialDurability;
        public int PointDurability { get; set; }
        public int Length { get; set; }
        
        public Pencil(int initialDurability, int initialLength)
        {
            _initialDurability = initialDurability;
            PointDurability = _initialDurability;
            Length = initialLength;
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

        public void Sharpen()
        {
            if (Length > 0)
            {
                PointDurability = _initialDurability;
                Length--;
            }
            
        }
    }
}