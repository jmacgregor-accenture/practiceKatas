namespace PencilKata.Library
{
    public class Pencil
    {
        private int _initialDurability;
        public int PointDurability { get; set; }
        
        public Pencil(int initialDurability)
        {
            _initialDurability = initialDurability;
            PointDurability = _initialDurability;
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
            PointDurability = _initialDurability;
        }
    }
}