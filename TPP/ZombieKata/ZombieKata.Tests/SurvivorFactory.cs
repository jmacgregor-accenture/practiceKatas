using ZombieKata.Game;

namespace ZombieKata.Tests
{
    public static class SurvivorFactory
    {
        public const string PHILLIP = "Phillip";
        
        public static Survivor CreateHealthyPhillip()
        {
            return new Survivor(PHILLIP);
        }
    }
}