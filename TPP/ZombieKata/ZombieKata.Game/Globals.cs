using System.Collections.Generic;

namespace ZombieKata.Game
{
    public static class Levels
    {
        public static Level BLUE = new Level {Name = "Blue", Value = -1};
        public static Level YELLOW = new Level {Name = "Yellow", Value = 6};
        public static Level ORANGE = new Level {Name = "Orange", Value = 18};
        public static Level RED = new Level {Name = "Red", Value = 42};
        
        public static List<Level> ALL_LEVELS = new List<Level>
        {
            BLUE,
            YELLOW,
            ORANGE,
            RED
        };
    }
}