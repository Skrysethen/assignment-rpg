using assignment_rpg.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace assignment_rpg.Heroes
{
    public class WarriorHero : Hero
    {
        public WarriorHero(string name) : base(name)
        {
            this.LevelAttributes = new HeroAttribute { Str = 5, Dex = 2, Intelligence = 1 };
            ValidArmorTypes.Add(ArmorType.Mail.ToString());
            ValidArmorTypes.Add(ArmorType.Plate.ToString());
            ValidWeponTypes.Add(WeponType.Sword.ToString());
            ValidWeponTypes.Add(WeponType.Hammer.ToString());
            ValidWeponTypes.Add(WeponType.Axe.ToString());
        }

        public void WarriorLevelUp(HeroAttribute oldAttributes)
        {
            HeroAttribute newAttributes = new HeroAttribute { Str = 3, Dex = 2, Intelligence = 1};
            HeroAttribute addAttributes = oldAttributes + newAttributes;
            this.Level++;
            this.LevelAttributes = addAttributes;
            
        }

        public override decimal Damage()
        {
            CalculateTotalAttributes();
            Item? weapon = Equipment[Slot.Weapon];
            if (weapon != null)
            {
                decimal weaponDamage = weapon.GetWeaponDamage();
                decimal attributeModifier = this.TotalAttributes.Str / (decimal)100;
                
                Dps = weaponDamage * (1 + (attributeModifier));
            }
            else
            {
                Dps = 1;
            }
            return Decimal.Round(Dps,2);
        }
    }
}
