using System.Collections.Generic;
using System.Linq;
using static ZombieKata.Game.Levels;

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
        public Level Level { get; set; }

        public Survivor(string name)
        {
            Name = name;
            ActionsPerTurn = 3;
            EquipmentCapacity = DEFAULT_EQUIPMENT_CAPACITY;
            Equipment = new List<Equipment>();
            Level = Levels.BLUE;        }

        public void Harm()
        {
            if (IsDead) return;
            
            Wounds++;
            EquipmentCapacity--;

            if (EquipmentCapacity < Equipment.Count)
            {
                Equipment.Remove(Equipment.Last());
            }

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
            foreach (var level in ALL_LEVELS)
            {
                if (Experience > level.Value)
                {
                    Level = level;
                }
            }
        }

        public void AddEquipment(Equipment equipmentToAdd)
        {
            if (Equipment.Count < EquipmentCapacity)
            {
                Equipment.Add(equipmentToAdd);
            }
            
        }
    }
}