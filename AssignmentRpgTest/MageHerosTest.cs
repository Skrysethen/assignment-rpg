using assignment_rpg.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentRpgTest
{
    public class MageHerosTest
    {
        [Fact]
        public void TestCreateMageHeroName_ShouldReturnNameOfMageHero()
        {
            //Arrange
            MageHero newMageHero = new MageHero("Gandalf");
            string expected = "Gandalf";
            //Act
            string actual = newMageHero.Name;
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCreateMageHeroLevel_ShouldReturnLevelEqualOne()
        {
            MageHero mageHero = new MageHero("Gandalf");
            int expected = 1;
            int actual = mageHero.Level;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCreateMageHeorAttributes_ShouldReturnStrOneDexOneIntelligenceEight()
        {
            MageHero mageHero = new MageHero("Gandalf");
            HeroAttribute expected = new HeroAttribute { Str = 1, Dex = 1, Intelligence = 8 };
            HeroAttribute actual = mageHero.LevelAttributes;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestMageHeroLevelUp_ShouldReturnStrTwoDexTwoIntelligenceThirteen()
        {
            MageHero mageHero = new MageHero("Gandalf");
            HeroAttribute startLevel = new HeroAttribute { Str = 1, Dex = 1, Intelligence = 8 };
            HeroAttribute lvlUpAttributes = new HeroAttribute { Str = 1, Dex = 1, Intelligence = 5 };
            HeroAttribute expected = startLevel + lvlUpAttributes;
            HeroAttribute actual = mageHero.LevelAttributes;
            Assert.Equal(expected, actual);
        }
    }
}
