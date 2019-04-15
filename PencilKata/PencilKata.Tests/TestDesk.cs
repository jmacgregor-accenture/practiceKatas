using PencilKata.Library;

namespace PencilKata.Tests
{
    public class TestDesk
    {
        protected Pencil _pencil;
        protected Paper _paper;

        protected void SetupDesk(int pencilDurability, int pencilLength, bool addPaper)
        {
            _pencil = new Pencil(pencilDurability, pencilLength);

            if (addPaper)
            {
                _paper = new Paper();
            }
        }
    }
}