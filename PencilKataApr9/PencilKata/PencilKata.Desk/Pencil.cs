namespace PencilKata.Desk
{
    public class Pencil
    {
        public int Durability { get; set; }

        public Pencil()
        {
            Durability = 25;
        }

        public void Write(string input)
        {
            Durability -= input.Length;
        }
    }
}