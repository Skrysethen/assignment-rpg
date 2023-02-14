using assignment_rpg.Heroes;
using assignment_rpg.Items;
using System.Data.Common;
using Xunit;

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
        public void TestReturnLevel_HeroLevelUp_ShouldIncrementLevelByOne()
        {
            RogueHero newHero = new RogueHero("Bilbo");
            HeroAttribute attribute = new HeroAttribute { Str = 1, Dex = 1, Intelligence = 1};
            int expected = 2;
            newHero.RogueLevelUp(attribute);
            int actual = newHero.Level;
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
        public void TestReturnAttributes_ArmorAttributesAddedWithOnePiceOfArmor_ShouldReturnDexIncreaseByOne()
        {
            //Arrange
            RangerHero newHero = new RangerHero("Legolas");
            HeroAttribute armorAttributes = new HeroAttribute { Str = 0, Dex = 1, Intelligence = 0 };
            ArmorItem topHat = new ArmorItem("Top Hat", 1, Slot.Head, ArmorType.Leather, armorAttributes);
            HeroAttribute expected = new HeroAttribute { Str = 1, Dex = 8, Intelligence = 1 };

            //Act
            newHero.Equip(topHat);
            newHero.CalculateTotalAttributes();
            HeroAttribute actual = newHero.TotalAttributes;
            //Assert
            Assert.Equal(expected, actual);

        }
        [Fact]
        public void TestReturnAttributes_ArmorAttributesAddedWithTwoPiceOfArmor_ShouldReturnIncreaseByTwo()
        {
            //Arrange
            WarriorHero newHero = new WarriorHero("Conan");
            //Two items that gives a combined of 2str and 1 dex for a warrior at lvl 1 
            HeroAttribute hatAttribute = new HeroAttribute { Str = 1, Dex = 1, Intelligence = 0 };
            HeroAttribute vodyAttribute = new HeroAttribute { Str = 1, Dex = 0, Intelligence = 0 };
            ArmorItem plateHelm = new ArmorItem("Knights helm", 1, Slot.Head, ArmorType.Plate, hatAttribute);
            ArmorItem mailBody = new ArmorItem("Ragged Chainmail",1, Slot.Body, ArmorType.Mail, vodyAttribute);
            HeroAttribute expected = new HeroAttribute { Str = 7, Dex = 3, Intelligence = 1 };
            //Act
            newHero.Equip(plateHelm);
            newHero.Equip(mailBody);
            newHero.CalculateTotalAttributes();
            HeroAttribute actual = newHero.TotalAttributes;
            //Assert
            Assert.Equal(expected, actual);

        }
        [Fact]
        public void TestCalculateDamage_NoWeaponEquipped_ShouldReturnOne()
        {
            //Arrange
            MageHero newHero = new MageHero("Gandalf");
            decimal expected = 1;
            //Act
            decimal actual = newHero.Damage();
            //Assert
            Assert.Equal(expected,actual);
        }
        [Fact]
        public void TestCalculateDamageMage_WeaponEquipped_ShouldReturnOne()
        {
            //Arrange
            MageHero newHero = new MageHero("Gandalf");
            WeaponItem epicStaff = new WeaponItem("Staff of Jordan", 1, Slot.Weapon, WeponType.Staff, 1);
            decimal expected = 1 *(1+(8/(decimal)100));
            //Act
            newHero.Equip(epicStaff);
            decimal actual = newHero.Damage();

            //Assert
            Assert.Equal(expected, actual);
            
        }
        [Fact]
        public void TestCalculateDamageWarrior_WeaponEquippedWithDamageThreeAndArmorWithFiveStrength_SHouldReturnThreePointThree()
        {
            //Arrane
            WarriorHero newHero = new WarriorHero("Conan");
            HeroAttribute helmAttribute = new HeroAttribute { Str = 3, Dex = 0, Intelligence = 0 };
            HeroAttribute chestAttribute = new HeroAttribute { Str = 2, Dex = 0, Intelligence = 0 };
            WeaponItem bigSword = new WeaponItem("Grandfather", 1, Slot.Weapon, WeponType.Sword, 3);
            ArmorItem fancyHelm = new ArmorItem("Knights hat", 1, Slot.Head, ArmorType.Plate, helmAttribute);
            ArmorItem fancyChest = new ArmorItem("Knights chest", 1, Slot.Body, ArmorType.Plate, chestAttribute);
            decimal expected = 3 * (1+(10/(decimal)100));
            //Act
            newHero.Equip(fancyHelm);
            newHero.Equip(fancyChest);
            newHero.Equip(bigSword);
            decimal actual = newHero.Damage();
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}