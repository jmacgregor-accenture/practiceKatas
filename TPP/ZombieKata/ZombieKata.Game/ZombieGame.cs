using System.Collections.Generic;

namespace ZombieKata.Game
{
    public class ZombieGame
    {
        public List<Survivor> Survivors { get; set; }

        public ZombieGame()
        {
            Survivors = new List<Survivor>();
        }

        public void AddSurvivor(Survivor player)
        {
            Survivors.Add(player);
        }
    }
}