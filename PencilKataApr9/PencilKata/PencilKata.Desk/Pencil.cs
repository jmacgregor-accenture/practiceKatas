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

                    HandleDegradation(character);
                }
                else
                {
                    returnString += " ";
                    continue;
                }
            }

            return returnString;
        }

        private void HandleDegradation(char character)
        {
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
            Durability -= 1;
        }
    }
}