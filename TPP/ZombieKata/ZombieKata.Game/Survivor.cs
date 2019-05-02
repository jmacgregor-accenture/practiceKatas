﻿using System;

namespace ZombieKata.Game
{
    public class Survivor
    {
        public string Name { get; }
        public int Wounds { get; private set; }
        public bool IsDead { get; private set; }

        public Survivor(string name)
        {
            Name = name;
        }


        public void Harm()
        {
            if (IsDead) return;
            
            Wounds++;

            if (Wounds == 2)
            {
                IsDead = true;
            }
        }
    }
}