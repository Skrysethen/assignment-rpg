using assignment_rpg.Heroes;
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
        public void TestCreateRangerHero_ShouldReturnLegolas()
        {
            RangerHero rangerHero = new RangerHero("Legolas");
            string expected = "Legolas";
            string actual = rangerHero.Name;
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
        public void TestCreateRangerHeroAttributes_ShouldReturnAttributesStrTwoDexSixIntOne()
        {
            RangerHero rangerHero = new RangerHero("Legolas");
            HeroAttribute expected = new HeroAttribute { Str = 2, Dex = 6, Intelligence = 1 };
            HeroAttribute actual = rangerHero.LevelAttributes;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestRangerHeroAttributes_LevelUp_ShouldReturnAttributesStrThreeDexTenIntTwo()
        {
            RangerHero rangerHero = new RangerHero("Legolas");
            HeroAttribute oldAttributes = new HeroAttribute { Str = 2, Dex = 6, Intelligence = 1 };
            HeroAttribute attributeModifier = new HeroAttribute { Str = 1, Dex = 4, Intelligence = 1 };
            HeroAttribute expected = oldAttributes + attributeModifier;
            rangerHero.RangerLevelUp();
            HeroAttribute actual = rangerHero.LevelAttributes;
        }
        [Fact]
        public void TestRangerHeroEquip_ArmorWithArmorTypeCloth_ShouldReturnInvalidArmorExeption()
        {

        }
        [Fact]
        public void TestRangerHeroEquip_WeaponWithWeaponTypeWand_ShouldReturnInvalidWeaponExeption()
        {

        }
        [Fact]
        public void TestRangerHeroEquip_ArmorAndReplaceWithOtherArmor_ShouldReturnNameOfSecondArmor()
        {

        }
        [Fact]
        public void TestRangerHeroDamage_NoWeaponEquipped_ShouldReturnOne()
        {

        }
        [Fact]
        public void TestRangerHeroDamage_EquipWeaponWithAttackOne_ShouldReturnOnePointZeroSix()
        {

        }
        [Fact]
        public void TestRangerHeroDamage_EquipWeaponWithAttackOne_ArmorWithDexFour_ShouldReturnOnePointOne()
        {

        }
        [Fact]
        public void TestRangerHeroTotalAttributes_NoArmorEquipped_ShouldReturnStrTwoDexSixIntOne()
        {

        }
        [Fact]
        public void TestRangerHeroToString_ShouldReturn()
        {

        }
        

    }
}
