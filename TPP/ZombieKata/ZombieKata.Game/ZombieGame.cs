using System.Collections.Generic;
using System.Linq;

namespace ZombieKata.Game
{
    public class ZombieGame
    {
        public List<Survivor> Survivors { get;  }
        public string Level { get; set; }

        public ZombieGame()
        {
            Survivors = new List<Survivor>();
            Level = "Blue";
        }

        public void AddSurvivor(Survivor player)
        {
            if (Survivors.Any(survivor => survivor.Name == player.Name)) return;
            
            Survivors.Add(player);
        }

        public bool IsOver()
        {
            return Survivors.TrueForAll(survivor => survivor.IsDead);
        }
    }
}