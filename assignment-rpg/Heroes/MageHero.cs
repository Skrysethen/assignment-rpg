﻿using assignment_rpg.Items;
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

            this.LevelAttributes = new HeroAttribute { Str = 1, Dex = 1, Intelligence = 8 };
            ValidArmorTypes.Add(ArmorType.Cloth.ToString());
            ValidWeponTypes.Add(WeponType.Wand.ToString());
            ValidWeponTypes.Add(WeponType.Staff.ToString());

        }

        public void MageLevelUp(HeroAttribute oldAttributes)
        {
            HeroAttribute newAttributes = new HeroAttribute { Str = 1, Dex = 1, Intelligence = 5 };
            HeroAttribute addedAttributes = newAttributes + oldAttributes;
            this.Level++;
            this.LevelAttributes = addedAttributes;
            

        }

        public override double Damage()
        {
            CalculateTotalAttributes();
            Item weapon = Equipment[Slot.Weapon];
            if (weapon.Name != null)
            {
                int weaponDamage = weapon.GetWeaponDamage();
                this.Dps = weaponDamage * (1 + (this.TotalAttributes.Intelligence / 100));
            }
            else
            {
                this.Dps = 1;
            }
            return this.Dps;
        }
    }
}
