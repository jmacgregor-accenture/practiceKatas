namespace PencilKata.Library
{
    public class Paper : IWritable
    {
        private string _contentsBuffer;

        public void Write(string inputString)
        {
            _contentsBuffer += inputString;
        }

        public string Read()
        {
            return _contentsBuffer;
        }
    }
}