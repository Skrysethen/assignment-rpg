using assignment_rpg.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace assignment_rpg.Items
{
    /// <summary>
    /// Parent class for ArmorItem and WeaponItem, holds the shared attributes for armor and weapon items.
    /// GetWeponType -> Gives access to the weapontype from the item class.
    /// GetArmorType -> Gives access to the armortype from the item class.
    /// GetArmorAttribute -> Gets the armor modifier.
    /// GetWeaponDamage -> Gets the weapon damage.
    /// </summary>
    public abstract class Item
    {
        public string Name { get; set; }
        public int ReqLevel { get; set; }
        public Slot SlotType { get; set; }

        public Item(string name, int reqLevel, Slot slotType)
        {
            Name = name;
            ReqLevel = reqLevel;
            SlotType = slotType;
        }

        public abstract WeponType GetWeponType();
        public abstract ArmorType GetArmorType();
        public abstract HeroAttribute GetArmorAttribute();
        public abstract int GetWeaponDamage();

        

    }



}
