using System.Collections.Generic;

namespace ZombieKata.Game
{
    public static class Globals
    {
        public static Dictionary<string,int> Levels
        {
            get { return _levels; }
        }
        
        private static Dictionary<string, int> _levels = new Dictionary<string, int>
        {
            {"Blue", -1},
            {"Yellow", 6},
            {"Orange", 18}
        };
    }
}