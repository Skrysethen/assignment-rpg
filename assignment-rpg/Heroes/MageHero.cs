using assignment_rpg.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_rpg.Heroes
{
    public class MageHero : Hero
    {
        public MageHero(string name) : base(name)
        {

            this.LevelAttributes = HeroAttribute.GetMageAttributes();
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
            
            Item weapon = Equipment[Slot.Weapon];
            if (weapon != null)
            {
                decimal weaponDamage = weapon.GetWeaponDamage();
                decimal attributeModifier = 1 + (this.TotalAttributes.Intelligence / (decimal)100);
                Dps = weaponDamage * (attributeModifier);
            }
            else
            {
                Dps = 1;
            }
            return Decimal.Round(Dps,2);
        }
    }
}
