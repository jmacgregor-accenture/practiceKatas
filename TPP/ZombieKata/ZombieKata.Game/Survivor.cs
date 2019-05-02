using System;

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

        public Survivor(string name)
        {
            Name = name;
            ActionsPerTurn = 3;
            EquipmentCapacity = DEFAULT_EQUIPMENT_CAPACITY;
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