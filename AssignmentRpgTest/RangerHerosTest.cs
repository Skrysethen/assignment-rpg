using assignment_rpg.Heroes;
using assignment_rpg.Items;
using assignment_rpg.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace AssignmentRpgTest
{
    public class RangerHerosTest
    {
        [Fact]
        public void TestCreateRangerHeroName_ShouldReturnNameOfRangerHero()
        {
            //Arrange
            RangerHero newRangerHero = new RangerHero("Legolas");
            string expected = "Legolas";
            //Act
            string actual = newRangerHero.Name;
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCreateRangerHeroLevel_ShouldReturnLevelEqualOne()
        {
            RangerHero rangerHero = new RangerHero("Legolas");
            int expected = 1;
            int actual = rangerHero.Level;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCreateRangerHeorAttributes_ShouldReturnStrOneDexSevenIntelligenceOne()
        {
            RangerHero rangerHero = new RangerHero("Legolas");
            HeroAttribute expected = new HeroAttribute { Str = 1, Dex = 7, Intelligence = 1 };
            HeroAttribute actual = rangerHero.LevelAttributes;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestRangerHeroLevelUp_AttributesShoulAddTogether_ShouldReturnStrTwoDexTwelveIntelligenceTwo()
        {
            RangerHero rangerHero = new RangerHero("Gandalf");
            HeroAttribute startLevel = new HeroAttribute { Str = 1, Dex = 7, Intelligence = 1 };
            HeroAttribute lvlUpAttributes = new HeroAttribute { Str = 1, Dex = 5, Intelligence = 1 };
            HeroAttribute expected = startLevel + lvlUpAttributes;
            rangerHero.LevelUp();
            HeroAttribute actual = rangerHero.LevelAttributes;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestRangerHeroLevelUp_LevelIncrease_ShuoldReturnHeroLevelTwo()
        {
            RangerHero rangerHero = new RangerHero("Legolas");
            int expected = 2;
            rangerHero.LevelUp();
            int actual = rangerHero.Level;
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void TestRangerHeroEquip_ItemPlate_ShouldThrowInvalidArmorExeption()
        {
            RangerHero mageHero = new RangerHero("Legolas");
            HeroAttribute plateModifier = new HeroAttribute { Str = 3, Dex = 0, Intelligence = 5 };
            ArmorItem goldenPlateChest = new ArmorItem("Shiny Golden Plate chest", 1, Slot.Body, ArmorType.Plate, plateModifier);

            Assert.Throws<InvalidArmorExeption>(() => mageHero.Equip(goldenPlateChest));

        }

        [Fact]
        public void TestRangerHeroEquip_WeaponSword_ShouldThrowInvalidWeaponExeption()
        {
            RangerHero rangerHero = new RangerHero("Legolas");
            WeaponItem shinySword = new WeaponItem("Sword of a thousand tales", 1, Slot.Weapon, WeponType.Sword, 5);

            Assert.Throws<InvalidWeaponExeption>(() => rangerHero.Equip(shinySword));

        }
        [Fact]
        public void TestRangerHeroEquip_ArmorAndReplaceWithOtherArmor_ShouldReturnNameOfSecondArmor()
        {
            RangerHero rangerHero = new RangerHero("Legolas");
            HeroAttribute hatModifier = new HeroAttribute { Str = 0, Dex = 2, Intelligence = 1 };
            ArmorItem topHap = new ArmorItem("Fancy Top Hat", 1, Slot.Head, ArmorType.Mail, hatModifier);
            ArmorItem pointyHat = new ArmorItem("Fedora", 1, Slot.Head, ArmorType.Leather, hatModifier);
            string expected = "Fedora";
            rangerHero.Equip(topHap);
            rangerHero.Equip(pointyHat);
            string actual = rangerHero.Equipment[Slot.Head].Name;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRangerHeroTotalAttributes_WithNoArmorEquipped_ShouldReturnStrOneDexSevenIntelligenceOne()
        {
            RangerHero rangerHero = new RangerHero("Gandalf");
            HeroAttribute expected = new HeroAttribute { Str = 1, Dex = 7, Intelligence = 1 };
            rangerHero.CalculateTotalAttributes();
            HeroAttribute actual = rangerHero.TotalAttributes;
            Assert.Equal(expected, actual);

        }
        [Fact]
        public void TestRangerHeroTotalAttributes_WithArmorEquipped_WithBonusAttributesDexTwo_ShouldReturnStrOneDexNineIntelligenceOne()
        {
            RangerHero rangerHero = new RangerHero("Legolas");
            HeroAttribute armorModifier = new HeroAttribute { Str = 0, Dex = 2, Intelligence = 0 };
            ArmorItem fancyRobe = new ArmorItem("Fancy shooty chesty", 1, Slot.Body, ArmorType.Mail, armorModifier);
            HeroAttribute expected = new HeroAttribute { Str = 1, Dex = 9, Intelligence = 1 };
            rangerHero.Equip(fancyRobe);
            rangerHero.CalculateTotalAttributes();
            HeroAttribute actual = rangerHero.TotalAttributes;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestRangerHeroDamage_WithNoWeapon_WithNoArmor_ShouldReturnOne()
        {
            RangerHero rangerHero = new RangerHero("Gandalf");
            decimal expected = 1;
            decimal actual = rangerHero.Damage();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestRangerHeroDamage_WithDexNoArmorEquipped_WeaponEquippedWithOneDamage_ShouldReturnOnePointZeroSeven()
        {
            RangerHero rangerHero = new RangerHero("Legolas");
            WeaponItem bow = new WeaponItem("Bow", 1, Slot.Weapon, WeponType.Bow, 1);
            decimal expected = 1 * (1 + (7 / (decimal)100));
            //Act
            rangerHero.Equip(bow);
            decimal actual = rangerHero.Damage();
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void TestRangerHeroDamage_WithArmorEquippedWithTwoDex_WeaponWithOneDamage_ShouldReturnOnePointZeroNine()
        {
            RangerHero rangerHero = new RangerHero("Gandalf");
            HeroAttribute armorModifier = new HeroAttribute { Str = 0, Dex = 2, Intelligence = 0 };
            ArmorItem flashyBoots = new ArmorItem("Magic sandals", 1, Slot.Legs, ArmorType.Leather, armorModifier);
            WeaponItem bow = new WeaponItem("Boomstick", 1, Slot.Weapon, WeponType.Bow, 1);
            decimal expected = 1 * (1 + (9 / (decimal)100));
            rangerHero.Equip(bow);
            rangerHero.Equip(flashyBoots);
            decimal actual = rangerHero.Damage();
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void TestMageHero_ToStringMethod()
        {
            RangerHero rangerHero = new RangerHero("Legolas");
            string expected = "Name: Legolas\nLevel: 1\nTotal Attributes:\n\tStr: 1\n\tDex: 7\n\tInt: 1\nClass: Ranger\nDamage: 1";
            string actual = rangerHero.ToString();
            Assert.Equal(expected, actual);

        }


    }
}
