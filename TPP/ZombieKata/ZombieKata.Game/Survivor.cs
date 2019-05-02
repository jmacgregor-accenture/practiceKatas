using System;

namespace ZombieKata.Game
{
    public class Survivor
    {
        public string Name { get; }
        public int Wounds { get; private set; }

        public Survivor(string name)
        {
            Name = name;
        }


        public void Harm()
        {
            Wounds++;
        }
    }
}