namespace PencilKata.Library
{
    public class Pencil : IFiniteWritingTool
    {
        
        private readonly int _initialDurability;
        public int Durability { get; set; }
        public int Length { get; set; }
        
        public Pencil(int initialDurability, int initialLength)
        {
            _initialDurability = initialDurability;
            Durability = _initialDurability;
            Length = initialLength;
        }
        
        public void Use(char character)
        {
            if (char.IsWhiteSpace(character) || Durability < 1) return;
            
            
            if (char.IsUpper(character))
            {
                Durability -= 2;
            }
            else
            {
                Durability -= 1;
            }
        }

        public void Sharpen()
        {
            if (Length <= 0) return;
            
            Durability = _initialDurability;
            Length--;

        }
    }
}