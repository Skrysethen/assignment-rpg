using assignment_rpg.Heroes;

namespace AssignmentRpgTest
{
    public class HerosTest
    {
        [Fact]
        public void TestReturnName_WarriorHero_ShouldReturnName()
        {
            //Arrange
            WarriorHero newHero = new WarriorHero("Conan");
            string expected = "Conan";
            //Act
            string actual = newHero.Name;
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestReturnAttributes_MageLevelUp_ShouldReturnIntelligenceIncreasedByFiveRestByOne()
        {
            //Arrange
            MageHero newHero = new MageHero("Gandalf");
            HeroAttribute oldAttributes = newHero.LevelAttributes;
            HeroAttribute expected = new HeroAttribute { Str = 2, Dex = 2, Intelligence = 13 };
            //Act
            newHero.MageLevelUp(oldAttributes);
            HeroAttribute actual = newHero.LevelAttributes;
            //Assert
            Assert.Equal(expected, actual);
            

        }
        [Fact]
        public void TestReturnAttributes_RangerLevelUp_ShouldReturnDexterityIncreasedBySevenRestByOne()
        {
            //Arrange
            RangerHero newHero = new RangerHero("Legolas");
            HeroAttribute oldAttributes = newHero.LevelAttributes;
            HeroAttribute expected = new HeroAttribute { Str = 2, Dex = 12, Intelligence = 2 };
            //Act
            newHero.RangerLevelUp(oldAttributes);
            HeroAttribute actual = newHero.LevelAttributes;
            //Assert
            Assert.Equal(expected, actual);


        }
        [Fact]
        public void TestReturnAttributes_RogueLevelUp_ShouldReturnDexterityIncreasedByFourRestByOne()
        {
            //Arrange 
            RogueHero newHero = new RogueHero("Bilbo");
            HeroAttribute oldAttributes = newHero.LevelAttributes;
            HeroAttribute expected = new HeroAttribute { Str = 3, Dex = 10, Intelligence = 2 };
            //Act
            newHero.RogueLevelUp(oldAttributes);
            HeroAttribute actual = newHero.LevelAttributes;
            //Assert
            Assert.Equal(expected, actual);

        }
        [Fact]
        public void TestReturnAttributes_WarriorLevelUp_ShouldReturnStrengthIncreasedByThreeAndDexByTwoRestByOne()
        {
            //Arrange
            WarriorHero newHero = new WarriorHero("Conan");
            HeroAttribute oldAttributes = newHero.LevelAttributes;
            HeroAttribute expected = new HeroAttribute { Str = 8, Dex = 4, Intelligence = 2 };
            //Act
            newHero.WarriorLevelUp(oldAttributes);
            HeroAttribute actual = newHero.LevelAttributes;
            //Assert
            Assert.Equal(expected, actual); 

        }
        [Fact]
        public void TestReturnAttributes_ArmorAttributesAddedWithOnePiceOfArmor_ShouldReturnIncreaseByOne()
        {

        }
        [Fact]
        public void TestReturnAttributes_ArmorAttributesAddedWithTwoPiceOfArmor_ShouldReturnIncreaseByTwo()
        {

        }
    }
}