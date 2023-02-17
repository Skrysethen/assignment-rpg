using assignment_rpg.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_rpg.Heroes
{
    public class RogueHero : Hero
    {
        public RogueHero(string name) : base(name)
        {
            //This method need to be getRogueHero attribute
            this.LevelAttributes = HeroAttribute.GetRogueAttributes();
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
            Item? weapon = Equipment[Slot.Weapon];
            if (weapon != null)
            {
                int weaponDamage = weapon.GetWeaponDamage();
                Dps = weaponDamage * (1 + (this.TotalAttributes.Dex / (decimal)100));
            } else
            {
                Dps = 1;
            }
            return Decimal.Round(Dps,2);
        }
    }
}
