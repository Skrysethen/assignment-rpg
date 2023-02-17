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
        public void TestMageHeroLevelUp_AttributesShoulAddTogether_ShouldReturnStrTwoDexTwoIntelligenceThirteen()
        {
            MageHero mageHero = new MageHero("Gandalf");
            HeroAttribute startLevel = new HeroAttribute { Str = 1, Dex = 1, Intelligence = 8 };
            HeroAttribute lvlUpAttributes = new HeroAttribute { Str = 1, Dex = 1, Intelligence = 5 };
            HeroAttribute expected = startLevel + lvlUpAttributes;
            mageHero.LevelUp();
            HeroAttribute actual = mageHero.LevelAttributes;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestMageHeroLevelUp_LevelIncrease_ShuoldReturnHeroLevelTwo()
        {
            MageHero mageHero = new MageHero("Gandalf");
            int expected = 2;
            mageHero.LevelUp();
            int actual = mageHero.Level;
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void TestMageHeroEquip_ItemPlate_ShouldThrowInvalidArmorExeption()
        {
            MageHero mageHero = new MageHero("Gandalf");
            HeroAttribute plateModifier = new HeroAttribute { Str = 3, Dex = 0, Intelligence = 5 };
            ArmorItem goldenPlateChest = new ArmorItem("Shiny Golden Plate chest", 1, Slot.Body, ArmorType.Plate, plateModifier);

            Assert.Throws<InvalidArmorExeption>(() => mageHero.Equip(goldenPlateChest));

        }

        [Fact]
        public void TestMageHeroEquip_WeaponSword_ShouldThrowInvalidWeaponExeption()
        {
            MageHero mageHero = new MageHero("Gandalf");
            WeaponItem shinySword = new WeaponItem("Sword of a thousand tales", 1, Slot.Weapon, WeponType.Sword, 5);

            Assert.Throws<InvalidWeaponExeption>(() => mageHero.Equip(shinySword));

        }
        [Fact]
        public void TestMageHeroEquip_ArmorAndReplaceWithOtherArmor_ShouldReturnNameOfSecondArmor()
        {
            MageHero mageHero = new MageHero("Gandalf");
            HeroAttribute hatModifier = new HeroAttribute { Str = 0, Dex = 0, Intelligence = 2 };
            ArmorItem topHap = new ArmorItem("Fancy Top Hat", 1, Slot.Head, ArmorType.Cloth, hatModifier);
            ArmorItem pointyHat = new ArmorItem("Wizard Hat", 1, Slot.Head, ArmorType.Cloth, hatModifier);
            string expected = "Wizard Hat";
            mageHero.Equip(topHap);
            mageHero.Equip(pointyHat);
            string actual = mageHero.Equipment[Slot.Head].Name;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestMageHeroTotalAttributes_WithNoArmorEquipped_ShouldReturnStrOneDexOneIntelligenceEight()
        {
            MageHero mageHero = new MageHero("Gandalf");
            HeroAttribute expected = new HeroAttribute { Str = 1, Dex = 1, Intelligence = 8 };
            mageHero.CalculateTotalAttributes();
            HeroAttribute actual = mageHero.TotalAttributes;
            Assert.Equal(expected, actual);

        }
        [Fact]
        public void TestMageHeroTotalAttributes_WithArmorEquipped_WithBonusAttributesIntelligenceTwo_ShouldReturnStrOneDexOneIntelligenceTen()
        {
            MageHero mageHero = new MageHero("Gandalf");
            HeroAttribute armorModifier = new HeroAttribute { Str = 0, Dex = 0, Intelligence = 2 };
            ArmorItem fancyRobe = new ArmorItem("Gray Robe", 1, Slot.Body, ArmorType.Cloth, armorModifier);
            HeroAttribute expected = new HeroAttribute { Str = 1, Dex = 1, Intelligence = 10 };
            mageHero.Equip(fancyRobe);
            mageHero.CalculateTotalAttributes();
            HeroAttribute actual = mageHero.TotalAttributes;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestMageHeroDamage_WithNoWeapon_WithNoArmor_ShouldReturnOne()
        {
            MageHero mageHero = new MageHero("Gandalf");
            decimal expected = 1;
            decimal actual = mageHero.Damage();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestMageHeroDamage_WithIntNoArmorEquipped_WeaponEquippedWithOneDamage_ShouldReturnOnePointZeroEight()
        {
            MageHero mageHero = new MageHero("Gandalf");
            WeaponItem wand = new WeaponItem("Wandy wand", 1, Slot.Weapon, WeponType.Wand, 1);
            decimal expected = 1 * (1 + (8 / (decimal)100));
            //Act
            mageHero.Equip(wand);
            decimal actual = mageHero.Damage();
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void TestMageHeroDamage_WithArmorEquippedWithTwoIntelligence_WeaponWithOneDamage_ShouldReturnOnePointOne()
        {
            MageHero mageHero = new MageHero("Gandalf");
            HeroAttribute armorModifier = new HeroAttribute { Str = 0, Dex = 0, Intelligence = 2 };
            ArmorItem flashyBoots = new ArmorItem("Magic sandals", 1, Slot.Legs, ArmorType.Cloth, armorModifier);
            WeaponItem staff = new WeaponItem("Big Stick", 1, Slot.Weapon, WeponType.Staff, 1);
            decimal expected = 1 * (1 + (10 / (decimal)100));
            mageHero.Equip(staff);
            mageHero.Equip(flashyBoots);
            decimal actual = mageHero.Damage();
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void TestMageHero_ToStringMethod()
        {

        }

    }
}
