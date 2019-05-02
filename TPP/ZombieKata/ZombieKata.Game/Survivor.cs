using System;

namespace ZombieKata.Game
{
    public class Survivor
    {
        public string Name { get; }
        public int Wounds { get; private set; }
        public bool IsAlive { get; private set; }

        public Survivor(string name)
        {
            Name = name;
            IsAlive = true;
        }


        public void Harm()
        {
            if (IsAlive == false) return;
            
            Wounds++;

            if (Wounds == 2)
            {
                IsAlive = false;
            }
        }
    }
}