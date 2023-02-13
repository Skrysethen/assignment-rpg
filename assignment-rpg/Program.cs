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
            WeaponItem newWeapon = new WeaponItem("common axe", 1, Slot.Weapon, WeponType.Axe, 1);
            mage.Equip(newWeapon);
            foreach(var equipment in mage.Equipment)
            {
                if(equipment.Value != null)
                {
                    //Hvordan accesse dictonary for å hente ut verdi
                    Console.WriteLine($"{equipment.Key}: {equipment.Value.Name}");
                }
            }
                
        }
    }
}