using System.Collections.Generic;
using System.Linq;

namespace ZombieKata.Game
{
    public class ZombieGame
    {
        public List<Survivor> Survivors { get;  }
        public Level Level { get; set; }

        public ZombieGame()
        {
            Survivors = new List<Survivor>();
            Level = Levels.BLUE;
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

        public void SetLevel()
        {
            if (Survivors.Count <= 0) return;
            
            var maxValue = Survivors.Select(survivor => survivor.Level.Value).Max();

            Level = Levels.ALL_LEVELS.Find(level => level.Value == maxValue);

        }
    }
}