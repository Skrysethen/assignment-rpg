using assignment_rpg.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_rpg.Heroes
{
    /// <summary>
    /// The constructor takes in a name, sets the attributes for the ranger, and adds the valid armor types and weapon types.
    /// LevelUp -> Increments the level of hero by one and adding to the level attributes
    /// Damage -> Calculates the damage of the hero, modifier is Dex
    /// ToString -> Outputs the character sheet for the hero
    /// </summary>
    public class RangerHero : Hero
    {
        public RangerHero(string name) : base(name)
        {
            this.LevelAttributes = HeroAttribute.GetRangerAttributes();
            this.TotalAttributes = this.LevelAttributes;
            ValidArmorTypes.Add(ArmorType.Leather.ToString());
            ValidArmorTypes.Add(ArmorType.Mail.ToString());
            ValidWeponTypes.Add(WeponType.Bow.ToString());
        }

        public override void LevelUp()
        {
            HeroAttribute oldAttribute = this.LevelAttributes;
            HeroAttribute newAttribute = HeroAttribute.GetRangerLevelUpAttributes();
            HeroAttribute addAttribute = oldAttribute + newAttribute;
            this.Level++;
            this.LevelAttributes = addAttribute;
        }
        public override decimal Damage()
        {
            CalculateTotalAttributes();
            decimal dps = 0;
            Item? weapon = Equipment[Slot.Weapon];
            if (weapon != null)
            {
                int weaponDamage = weapon.GetWeaponDamage();
                dps = weaponDamage * (1 + (this.TotalAttributes.Dex / (decimal)100));
            }
            else
            {
                dps = 1;
            }
            return Decimal.Round(dps,2);
        }
        public override string ToString()
        {
            string ranger = "Ranger";
            return base.ToString() + "Class: " + ranger + "\nDamage: " + Damage().ToString();
        }
    }
}
