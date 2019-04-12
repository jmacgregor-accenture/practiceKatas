using System;

namespace PencilKata.Library
{
    public class Pencil
    {
        public Paper Paper { get; set; }
        
        public Pencil(Paper paper)
        {
            Paper = paper;
        }

        public void Write(string inputString)
        {
            Paper.Text = inputString;
        }
    }
}