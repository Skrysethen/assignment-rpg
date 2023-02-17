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
    public class WarriorHerosTest
    {
        [Fact]
        public void TestCreateWarrioreHeroName_ShouldReturnNameOfWarriorHero()
        {
            //Arrange
            WarriorHero newWarriorHero = new WarriorHero("Conan");
            string expected = "Conan";
            //Act
            string actual = newWarriorHero.Name;
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCreateWarriorHeroLevel_ShouldReturnLevelEqualOne()
        {
            WarriorHero warriorHero = new WarriorHero("Conan");
            int expected = 1;
            int actual = warriorHero.Level;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCreateWarriorHeorAttributes_ShouldReturnStrFiveDexTwoIntelligenceOne()
        {
            WarriorHero warriorHero = new WarriorHero("Conan");
            HeroAttribute expected = new HeroAttribute { Str = 5, Dex = 2, Intelligence = 1 };
            HeroAttribute actual = warriorHero.LevelAttributes;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestWarriorHeroLevelUp_AttributesShoulAddTogether_ShouldReturnStrEightDexFourIntelligenceTwo()
        {
            WarriorHero warriorHero = new WarriorHero("Conan");
            HeroAttribute startLevel = new HeroAttribute { Str = 5, Dex = 2, Intelligence = 1 };
            HeroAttribute lvlUpAttributes = new HeroAttribute { Str = 3, Dex = 2, Intelligence = 1 };
            HeroAttribute expected = startLevel + lvlUpAttributes;
            warriorHero.LevelUp();
            HeroAttribute actual = warriorHero.LevelAttributes;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestWarriorHeroLevelUp_LevelIncrease_ShuoldReturnHeroLevelTwo()
        {
            WarriorHero warriorHero = new WarriorHero("Conan");
            int expected = 2;
            warriorHero.LevelUp();
            int actual = warriorHero.Level;
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void TestWarriorHeroEquip_ItemCloth_ShouldThrowInvalidArmorExeption()
        {
            WarriorHero warriorHero = new WarriorHero("Conan");
            HeroAttribute clothModifier = new HeroAttribute { Str = 3, Dex = 0, Intelligence = 5 };
            ArmorItem goldenClothChest = new ArmorItem("Shiny Golden Robe", 1, Slot.Body, ArmorType.Cloth,  clothModifier);

            Assert.Throws<InvalidArmorExeption>(() => warriorHero.Equip(goldenClothChest));

        }

        [Fact]
        public void TestWarriorHeroEquip_WeaponSword_ShouldThrowInvalidWeaponExeption()
        {
            WarriorHero warriorHero = new WarriorHero("Conan");
            WeaponItem shinyWand = new WeaponItem("Wandy wand", 1, Slot.Weapon, WeponType.Wand, 5);

            Assert.Throws<InvalidWeaponExeption>(() => warriorHero.Equip(shinyWand));

        }
        [Fact]
        public void TestWarriorHeroEquip_ArmorAndReplaceWithOtherArmor_ShouldReturnNameOfSecondArmor()
        {
            WarriorHero warriorHero = new WarriorHero("Conan");
            HeroAttribute hatModifier = new HeroAttribute { Str = 1, Dex = 0, Intelligence = 0 };
            ArmorItem topHap = new ArmorItem("Shiny Helm", 1, Slot.Head, ArmorType.Plate, hatModifier);
            ArmorItem pointyHat = new ArmorItem("Knights Hat", 1, Slot.Head, ArmorType.Plate, hatModifier);
            string expected = "Knights Hat";
            warriorHero.Equip(topHap);
            warriorHero.Equip(pointyHat);
            string actual = warriorHero.Equipment[Slot.Head].Name;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestWarriorHeroTotalAttributes_WithNoArmorEquipped_ShouldReturnStrFiveDexTwoIntelligenceOne()
        {
            WarriorHero warriorHero = new WarriorHero("Conan");
            HeroAttribute expected = new HeroAttribute { Str = 5, Dex = 2, Intelligence = 1 };
            warriorHero.CalculateTotalAttributes();
            HeroAttribute actual = warriorHero.TotalAttributes;
            Assert.Equal(expected, actual);

        }
        [Fact]
        public void TestWarriorHeroTotalAttributes_WithArmorEquipped_WithBonusAttributesStrTwo_ShouldReturnStrSevenDexTwoIntelligenceOne()
        {
            WarriorHero mageHero = new WarriorHero("Conan");
            HeroAttribute armorModifier = new HeroAttribute { Str = 2, Dex = 0, Intelligence = 0 };
            ArmorItem fancyPlate = new ArmorItem("Shiny chest", 1, Slot.Body, ArmorType.Plate, armorModifier);
            HeroAttribute expected = new HeroAttribute { Str = 7, Dex = 2, Intelligence = 1 };
            mageHero.Equip(fancyPlate);
            mageHero.CalculateTotalAttributes();
            HeroAttribute actual = mageHero.TotalAttributes;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestWarriorHeroDamage_WithNoWeapon_WithNoArmor_ShouldReturnOne()
        {
            WarriorHero mageHero = new WarriorHero("Conan");
            decimal expected = 1;
            decimal actual = mageHero.Damage();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestWarriorHeroDamage_WithStrNoArmorEquipped_WeaponEquippedWithOneDamage_ShouldReturnOnePointZeroEight()
        {
            WarriorHero warriorHero = new WarriorHero("Conan");
            WeaponItem sword = new WeaponItem("Grandfather", 1, Slot.Weapon, WeponType.Sword, 1);
            decimal expected = 1 * (1 + (5 / (decimal)100));
            //Act
            warriorHero.Equip(sword);
            decimal actual = warriorHero.Damage();
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void TestWarriorHeroDamage_WithArmorEquippedWithTwoStr_WeaponWithOneDamage_ShouldReturnOnePointOne()
        {
            WarriorHero warriorHero = new WarriorHero("Conan");
            HeroAttribute armorModifier = new HeroAttribute { Str = 2, Dex = 0, Intelligence = 0 };
            ArmorItem flashyBoots = new ArmorItem("Shiny Plate boots", 1, Slot.Legs, ArmorType.Plate, armorModifier);
            WeaponItem sword = new WeaponItem("Big Stick", 1, Slot.Weapon, WeponType.Sword, 1);
            decimal expected = 1 * (1 + (7 / (decimal)100));
            warriorHero.Equip(sword);
            warriorHero.Equip(flashyBoots);
            decimal actual = warriorHero.Damage();
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void TestWarriorHero_ToStringMethod()
        {

        }
    }
}
