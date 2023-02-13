using assignment_rpg.Heroes;
using assignment_rpg.Items;
using assignment_rpg.Utilities;
using Xunit.Sdk;

namespace AssignmentRpgTest
{
    public class ItemsTest
    {
        [Fact]
        public void TestCreateWeaponItem_ShouldReturnName() 
        {
            //Arrange
            WeaponItem simpleAxe = new WeaponItem("Axe", 1, Slot.Weapon, WeponType.Axe, 1);
            string expected = "Axe";
            //Act
            string actual = simpleAxe.Name;
            //Assert
            Assert.Equal(expected, actual);
            
        }
        [Fact]
        public void TestCreateArmorItem_ShouldReturnName()
        {
            //Arrange
            HeroAttribute bandanaModifiers = new HeroAttribute { Str = 1, Dex = 1, Intelligence = 1 };
            ArmorItem simpleArmor = new ArmorItem("Bandana", 1, Slot.Head, ArmorType.Cloth, bandanaModifiers);
            string expected = "Bandana";
            //Act 
            string actual = simpleArmor.Name;
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestEquipArmor_ShouldReturnNameOfArmorInHeroObject()
        {
            //Arrange
            MageHero newHero = new MageHero("Gandalf");
            HeroAttribute robeModifiers = new HeroAttribute { Str = 0, Dex = 0, Intelligence = 2 };
            ArmorItem simpleRobe = new ArmorItem("Gray Robe", 1, Slot.Body, ArmorType.Cloth, robeModifiers);
            string expected = "Gray Robe";
            //Act
            newHero.Equip(simpleRobe);
            //In the test we know this value is not zero
            string actual = newHero.Equipment[Slot.Body].Name;
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestEquipWeaponMage_ShouldReturnNameOfWeaponInHeroObject()
        {
            MageHero newHero = new MageHero("Gandalf");
            WeaponItem simpleStaff = new WeaponItem("Stick", 1, Slot.Weapon, WeponType.Staff, 1);
            string expected = "Stick";
            newHero.Equip(simpleStaff);
            string actual = newHero.Equipment[Slot.Weapon].Name;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestEquipWeapon_ShouldReturnNameOfWeaponInHeroObject()
        {
            //Arrange 
            WarriorHero newHero = new WarriorHero("Aragorn");
            WeaponItem simpleSword = new WeaponItem("Grief", 1, Slot.Weapon, WeponType.Sword, 2);
            string expected = "Grief";
            //Act 
            newHero.Equip(simpleSword);
            string actual = newHero.Equipment[Slot.Weapon].Name; 
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestEquipWeapon_WeaponWithHigherLvlRequirement_ShouldThrowInvalidWeaponExeption()
        {
            //Arrange
            RangerHero newHero = new RangerHero("Legolas");
            HeroAttribute bowModifier = new HeroAttribute { Str = 0, Dex = 3, Intelligence = 0 };
            WeaponItem simpleBow = new WeaponItem("Faith", 2, Slot.Weapon, WeponType.Bow, 5);
            
            //Act & Assert
            Assert.Throws<InvalidWeaponExeption>(() => newHero.Equip(simpleBow));
            
        }
        [Fact]
        public void TestEquipArmor_InvalidArmorTypeForClass_ShouldThrowInvalidArmorExeption()
        {
            //Arrange
            RogueHero newHero = new RogueHero("Bilbo");
            HeroAttribute plateLegsModifier = new HeroAttribute { Str = 0, Dex = 7, Intelligence = 0 };
            ArmorItem plateLegs = new ArmorItem("Fancy Legs", 1, Slot.Legs, ArmorType.Plate, plateLegsModifier);

            //Act & Assert
            Assert.Throws<InvalidArmorExeption>(() => newHero.Equip(plateLegs));
        }
    }
}
