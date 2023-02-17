using assignment_rpg.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace assignment_rpg.Heroes
{
    /// <summary>
    /// Constructor takes in name of the hero, sets the starting attributes for the mage, valid armortypes and weapontypes
    /// LevelUp -> Increments the level by one and adding attributes to LevelAttributes
    /// Damage -> Calculates damage for the hero, main modifier Int.
    /// ToString -> Prints out the charactersheet for the hero
    /// </summary>
    public class WarriorHero : Hero
    {
        public WarriorHero(string name) : base(name)
        {
            this.LevelAttributes = HeroAttribute.GetWarriorAttributes();
            this.TotalAttributes = this.LevelAttributes;
            ValidArmorTypes.Add(ArmorType.Mail.ToString());
            ValidArmorTypes.Add(ArmorType.Plate.ToString());
            ValidWeponTypes.Add(WeponType.Sword.ToString());
            ValidWeponTypes.Add(WeponType.Hammer.ToString());
            ValidWeponTypes.Add(WeponType.Axe.ToString());
        }

        public override void LevelUp()
        {
            HeroAttribute oldAttribute = this.LevelAttributes;
            HeroAttribute newAttributes = HeroAttribute.GetWarriorLevelUpAttributes();
            HeroAttribute addAttributes = oldAttribute + newAttributes;
            this.Level++;
            this.LevelAttributes = addAttributes;
            
        }
        public override decimal Damage()
        {
            CalculateTotalAttributes();
            decimal dps = 0;
            Item? weapon = Equipment[Slot.Weapon];
            if (weapon != null)
            {
                decimal weaponDamage = weapon.GetWeaponDamage();
                decimal attributeModifier = this.TotalAttributes.Str / (decimal)100;
                
                dps = weaponDamage * (1 + (attributeModifier));
            }
            else
            {
                dps = 1;
            }
            return Decimal.Round(dps,2);
        }
        public override string ToString()
        {
            string warrior = "Warrior";
            return base.ToString() + "Class: " + warrior;
        }
    }
}
