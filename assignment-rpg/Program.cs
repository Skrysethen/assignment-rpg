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
            Console.WriteLine(mage.LevelAttributes.Intelligence);
            WeaponItem newWeapon = new WeaponItem("common axe", 1, Slot.WEPON, WeponType.Axe, 1);
            Console.WriteLine(newWeapon.SlotType);
        }
    }
}