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
            var returnString = string.Empty;
            
            foreach (var character in input)
            {

                if (Durability > 0)
                {
                    returnString += character;
                }
                else
                {
                    returnString += " ";
                }
                
                if (char.IsWhiteSpace(character) == false)
                {
                    if (char.IsUpper(character))
                    {
                        HandleUpperCaseDegradation();
                    }
                    else
                    {
                        HandleNonUppercaseDegradation();
                    }
                }
            }

            return returnString;
        }

        private void HandleUpperCaseDegradation()
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

        private void HandleNonUppercaseDegradation()
        {
            if (Durability > 0)
            {
                Durability -= 1;
            }
        }
    }
}