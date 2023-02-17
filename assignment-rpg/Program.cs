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
            RogueHero rogue = new RogueHero("Bilbo");
            Console.WriteLine(mage.LevelAttributes.Intelligence);
            WeaponItem newWeapon = new WeaponItem("common axe", 1, Slot.Weapon, WeponType.Staff, 1);
            HeroAttribute armorModifier = new HeroAttribute { Str = 0, Dex = 0, Intelligence = 5 };
            ArmorItem pointyHat = new ArmorItem("Wizard Hat", 1, Slot.Head, ArmorType.Cloth, armorModifier);
            mage.Equip(pointyHat);
            mage.Equip(newWeapon);
            Console.WriteLine(mage.Damage());
            Console.WriteLine(warrior.Damage());
            Console.WriteLine(mage.ToString());
            Console.WriteLine(rogue.ToString());
            
                
        }
    }
}