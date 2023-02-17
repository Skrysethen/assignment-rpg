using assignment_rpg.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_rpg.Heroes
{
    /// <summary>
    /// The constructor takes in a name, sets the starting attributes for mage, valid armortypes and valid weapontypes.
    /// LevelUp -> Increment the hero level by one and adding attributes to Level attributes.
    /// Damage -> Calculates the damage for the mage, modifier for mage Int.
    /// ToString -> Prints out the character sheet for the hero.
    /// </summary>
    public class MageHero : Hero
    {
        public MageHero(string name) : base(name)
        {

            this.LevelAttributes = HeroAttribute.GetMageAttributes();
            this.TotalAttributes = this.LevelAttributes;
            ValidArmorTypes.Add(ArmorType.Cloth.ToString());
            ValidWeponTypes.Add(WeponType.Wand.ToString());
            ValidWeponTypes.Add(WeponType.Staff.ToString());

        }

        public override void LevelUp()
        {
            HeroAttribute oldAttributes = LevelAttributes;
            HeroAttribute newAttributes = HeroAttribute.GetMageLevelUpAttributes();
            HeroAttribute addedAttributes = newAttributes + oldAttributes;
            this.Level++;
            this.LevelAttributes = addedAttributes;
            

        }
        public override decimal Damage()
        {
            CalculateTotalAttributes();
            decimal dps = 0;
            Item weapon = Equipment[Slot.Weapon];
            if (weapon != null)
            {
                //Use decimal for the capability to round the output to 2 decimals
                decimal weaponDamage = weapon.GetWeaponDamage();
                decimal attributeModifier = 1 + (this.TotalAttributes.Intelligence / (decimal)100);
                dps = weaponDamage * (attributeModifier);
            }
            else
            {
                dps = 1;
            }
            return Decimal.Round(dps,2);
        }
        public override string ToString()
        {
            string mage = "Mage";
            return base.ToString() + "Class: " + mage;
        }
    }
}
