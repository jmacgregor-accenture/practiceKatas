﻿using System.Collections.Generic;
using static ZombieKata.Game.Globals;

namespace ZombieKata.Game
{
    public class Survivor
    {
        private const int DEFAULT_EQUIPMENT_CAPACITY = 5;
        public string Name { get; }
        public int Wounds { get; private set; }
        public bool IsDead { get; private set; }
        public int ActionsPerTurn { get;}
        public int EquipmentCapacity { get; set; }
        public List<Equipment> Equipment { get; set; }
        public int Experience { get; set; }
        public string Level { get; set; }

        public Survivor(string name)
        {
            Name = name;
            ActionsPerTurn = 3;
            EquipmentCapacity = DEFAULT_EQUIPMENT_CAPACITY;
            Equipment = new List<Equipment>();
            Level = "Blue";
        }

        public void Harm()
        {
            if (IsDead) return;
            
            Wounds++;
            EquipmentCapacity--;

            if (Wounds == 2)
            {
                IsDead = true;
            }
        }

        public void AddExperience()
        {
            Experience++;

            SetLevel();
        }

        private void SetLevel()
        {    
            foreach (var (key, value) in Levels)
            {
                if (Experience > value)
                {
                    Level = key;
                }
            }
        }
    }
}