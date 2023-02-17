using assignment_rpg.Heroes;
using assignment_rpg.Items;
using assignment_rpg.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentRpgTest
{
    public class RogueHerosTest
    {
        [Fact]
        public void TestCreateRogueHeroName_ShouldReturnNameOfRogueHero()
        {
            //Arrange
            RogueHero newRogueHero = new RogueHero("Bilbo");
            string expected = "Bilbo";
            //Act
            string actual = newRogueHero.Name;
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCreateRogueHeroLevel_ShouldReturnLevelEqualOne()
        {
            RogueHero rogueHero = new RogueHero("Bilbo");
            int expected = 1;
            int actual = rogueHero.Level;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCreateRogueHeorAttributes_ShouldReturnStrTwoDexSixIntelligenceOne()
        {
            RogueHero rogueHero = new RogueHero("Bilbo");
            HeroAttribute expected = new HeroAttribute { Str = 2, Dex = 6, Intelligence = 1 };
            HeroAttribute actual = rogueHero.LevelAttributes;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestRogueHeroLevelUp_AttributesShoulAddTogether_ShouldReturnStrThreeDexTenIntelligenceTwo()
        {
            RogueHero rogueHero = new RogueHero("Bilbo");
            HeroAttribute startLevel = new HeroAttribute { Str = 2, Dex = 6, Intelligence = 1 };
            HeroAttribute lvlUpAttributes = new HeroAttribute { Str = 1, Dex = 4, Intelligence = 1 };
            HeroAttribute expected = startLevel + lvlUpAttributes;
            rogueHero.LevelUp();
            HeroAttribute actual = rogueHero.LevelAttributes;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestRogueHeroLevelUp_LevelIncrease_ShuoldReturnHeroLevelTwo()
        {
            RogueHero rogueHero = new RogueHero("Bilbo");
            int expected = 2;
            rogueHero.LevelUp();
            int actual = rogueHero.Level;
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void TestRogueHeroEquip_ItemPlate_ShouldThrowInvalidArmorExeption()
        {
            RogueHero rogueHero = new RogueHero("Bilbo");
            HeroAttribute plateModifier = new HeroAttribute { Str = 3, Dex = 0, Intelligence = 5 };
            ArmorItem goldenPlateChest = new ArmorItem("Shiny Golden Plate chest", 1, Slot.Body, ArmorType.Plate, plateModifier);

            Assert.Throws<InvalidArmorExeption>(() => rogueHero.Equip(goldenPlateChest));

        }

        [Fact]
        public void TestRogueHeroEquip_WeaponSword_ShouldThrowInvalidWeaponExeption()
        {
            RogueHero rogueHero = new RogueHero("Bilbo");
            WeaponItem shinySword = new WeaponItem("Glowing Brightwoodstaff", 1, Slot.Weapon, WeponType.Staff, 5);

            Assert.Throws<InvalidWeaponExeption>(() => rogueHero.Equip(shinySword));

        }
        [Fact]
        public void TestRogueHeroEquip_ArmorAndReplaceWithOtherArmor_ShouldReturnNameOfSecondArmor()
        {
            RogueHero rogueHero = new RogueHero("Bilbo");
            HeroAttribute hatModifier = new HeroAttribute { Str = 0, Dex = 0, Intelligence = 2 };
            ArmorItem topHap = new ArmorItem("Fancy Top Hat", 1, Slot.Head, ArmorType.Leather, hatModifier);
            ArmorItem pointyHat = new ArmorItem("Sneaky Hat", 1, Slot.Head, ArmorType.Leather, hatModifier);
            string expected = "Sneaky Hat";
            rogueHero.Equip(topHap);
            rogueHero.Equip(pointyHat);
            string actual = rogueHero.Equipment[Slot.Head].Name;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRogueHeroTotalAttributes_WithNoArmorEquipped_ShouldReturnStrTwoDexSixIntelligenceOne()
        {
            RogueHero rogueHero = new RogueHero("Bilbo");
            HeroAttribute expected = new HeroAttribute { Str = 2, Dex = 6, Intelligence = 1 };
            rogueHero.CalculateTotalAttributes();
            HeroAttribute actual = rogueHero.TotalAttributes;
            Assert.Equal(expected, actual);

        }
        [Fact]
        public void TestRogueHeroTotalAttributes_WithArmorEquipped_WithBonusAttributesDexTwo_ShouldReturnStrTwoDexEightIntelligenceOne()
        {
            RogueHero rogueHero = new RogueHero("Bilbo");
            HeroAttribute armorModifier = new HeroAttribute { Str = 0, Dex = 2, Intelligence = 0 };
            ArmorItem fancyWolfArmor = new ArmorItem("Wolfie chest", 1, Slot.Body, ArmorType.Leather, armorModifier);
            HeroAttribute expected = new HeroAttribute { Str = 2, Dex = 8, Intelligence = 1 };
            rogueHero.Equip(fancyWolfArmor);
            rogueHero.CalculateTotalAttributes();
            HeroAttribute actual = rogueHero.TotalAttributes;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestRogueHeroDamage_WithNoWeapon_WithNoArmor_ShouldReturnOne()
        {
            RogueHero rogueHero = new RogueHero("Bilbo");
            decimal expected = 1;
            decimal actual = rogueHero.Damage();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestRogueHeroDamage_WithDexNoArmorEquipped_WeaponEquippedWithOneDamage_ShouldReturnOnePointZeroSix()
        {
            RogueHero rogueHero = new RogueHero("Bilbo");
            WeaponItem dagger = new WeaponItem("Pointy stick", 1, Slot.Weapon, WeponType.Dagger, 1);
            decimal expected = 1 * (1 + (6 / (decimal)100));
            //Act
            rogueHero.Equip(dagger);
            decimal actual = rogueHero.Damage();
            Assert.Equal(expected, actual);

        }

        [Fact]
        //Rename the test for rogue!!!
        public void TestRogueHeroDamage_WithArmorEquippedWithTwoDex_WeaponWithOneDamage_ShouldReturnOnePointZeroEight()
        {
            RogueHero rogueHero = new RogueHero("Bilbo");
            HeroAttribute armorModifier = new HeroAttribute { Str = 0, Dex = 2, Intelligence = 0 };
            ArmorItem flashyBoots = new ArmorItem("Magic sandals", 1, Slot.Legs, ArmorType.Leather, armorModifier);
            WeaponItem dagger = new WeaponItem("Perdition blade", 1, Slot.Weapon, WeponType.Dagger, 1);
            decimal expected = 1 * (1 + (8 / (decimal)100));
            rogueHero.Equip(dagger);
            rogueHero.Equip(flashyBoots);
            decimal actual = rogueHero.Damage();
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void TestRogueHero_ToStringMethod()
        {

        }
    }
}
