using System.Runtime.InteropServices;
using Xunit;
using Shouldly;
using ZombieKata.Game;

namespace ZombieKata.Tests
{
    public class SurvivorShould
    {
        private const string PHILLIP = "Phillip";
        private Survivor _survivor;

        private void CreateHealthyPhillip()
        {
            _survivor = new Survivor(PHILLIP);
        }
        
        [Fact]
        public void HaveName()
        {
            CreateHealthyPhillip();

            _survivor.Name.ShouldBe(PHILLIP);
        }

        [Fact]
        public void StartWithNoWounds()
        {
            CreateHealthyPhillip();

            _survivor.Wounds.ShouldBe(0);
        }

        [Fact]
        public void BeWoundedWhenHarmed()
        {
            
        }
    }
}