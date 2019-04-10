namespace PencilKata.Desk
{
    public class Pencil
    {
        public int Durability { get; set; }
        private int _maxDurability;
        private int _length;

        public Pencil()
        {
            Durability = 25;
            _maxDurability = 25;
            _length = 5;
        }

        public Pencil(int startingDurability, int length)
        {
            Durability = startingDurability;
            _maxDurability = 25;
            _length = length;
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
                    Durability -= 1;
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

        public void Sharpen()
        {
            if (_length > 0)
            {
                Durability = _maxDurability;
            }
        }
    }
}