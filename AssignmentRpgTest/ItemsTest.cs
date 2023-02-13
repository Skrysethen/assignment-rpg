using assignment_rpg.Heroes;
using assignment_rpg.Items;

namespace AssignmentRpgTest
{
    public class ItemsTest
    {
        [Fact]
        public void CreateWeaponItem_ShouldReturnName() 
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
        public void CreateArmorItem_ShouldReturnName()
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
    }
}
