using System;

namespace ZombieKata.Game
{
    public class Survivor
    {
        public string Name { get; set; }
        public int Wounds { get; set; }

        public Survivor(string name)
        {
            Name = name;
        }

        
    }
}