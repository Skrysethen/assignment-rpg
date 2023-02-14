using assignment_rpg.Heroes;
using assignment_rpg.Items;

namespace assignment_rpg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            MageHero mage = new MageHero("Petter");
            WarriorHero warrior = new WarriorHero("Conan");
            Console.WriteLine(mage.LevelAttributes.Intelligence);
            WeaponItem newWeapon = new WeaponItem("common axe", 1, Slot.Weapon, WeponType.Staff, 1);

            mage.Equip(newWeapon);
            Console.WriteLine(mage.Damage());
            Console.WriteLine(warrior.Damage());
                
        }
    }
}