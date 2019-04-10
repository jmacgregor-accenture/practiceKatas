namespace PencilKata.Desk
{
    public class Pencil
    {
        public int Durability { get; set; }

        public Pencil()
        {
            Durability = 25;
        }
        
        public Pencil(int startingDurability)
        {
            Durability = startingDurability;
        }

        public string Write(string input)
        {
            foreach (var character in input)
            {
                if (Durability > 0)
                {
                    Durability -= 1;
                }
            }
            return input;
        }
    }
}