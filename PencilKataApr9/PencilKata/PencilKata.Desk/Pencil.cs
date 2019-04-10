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

                if (char.IsWhiteSpace(character) == false)
                {
                    if (char.IsUpper(character))
                    {
                        HandleUpperCase();
                    }
                    else
                    {
                        HandleNonUppercase();
                    }
                }
            }

            return input;
        }

        private void HandleUpperCase()
        {
            if (Durability > 1)
            {
                Durability -= 2;
            }
            else
            {
                Durability -= 1;
            }
        }

        private void HandleNonUppercase()
        {
            if (Durability > 0)
            {
                Durability -= 1;
            }
        }
    }
}