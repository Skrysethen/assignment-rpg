using assignment_rpg.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_rpg.Heroes
{
    /// <summary>
    /// The constructor takes in a name to create a new RogueHero, and then the constructor sets the attributes for the rogue, adds the valid weapons and armortypes.
    /// Level up -> increments the level of the roguehero by 1 and increase the attributes by the set amount.
    /// Damage -> Calculate the damage that the hero does with a given weapon and given stats, for the rogue the main attribute is Dex
    /// ToString -> returns the charactersheet for the hero
    /// </summary>
    public class RogueHero : Hero
    {
        public RogueHero(string name) : base(name)
        {
            //This method need to be getRogueHero attribute
            this.LevelAttributes = HeroAttribute.GetRogueAttributes();
            this.TotalAttributes = this.LevelAttributes;
            ValidArmorTypes.Add(ArmorType.Leather.ToString());
            ValidArmorTypes.Add(ArmorType.Mail.ToString());
            ValidWeponTypes.Add(WeponType.Dagger.ToString());
            ValidWeponTypes.Add(WeponType.Sword.ToString());
        }

        public override void LevelUp()
        {
            //This method needs to be getRogueHeroLevelUpAttribute
            HeroAttribute oldAttribute = this.LevelAttributes;
            HeroAttribute newAttribute = HeroAttribute.GetRogueLevelUpAttributes();
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
            } else
            {
                dps = 1;
            }
            return Decimal.Round(dps,2);
        }
        public override string ToString()
        {
            string rogue = "Rogue";

            return base.ToString() + "Class: " + rogue;
        }
    }
}
