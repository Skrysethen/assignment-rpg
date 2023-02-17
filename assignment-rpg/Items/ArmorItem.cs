using assignment_rpg.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_rpg.Items
{
    /// <summary>
    /// Child class of Item. 
    /// The constructor takes in name, reqLevel, Slot type, armor class, armor attribute.
    /// Includes GetWeaponType -> This will Throw NotImplementedExeption.
    /// Includes GetWeaponDamage -> This will Throw NotImplementedExeption.
    /// </summary>
    public class ArmorItem : Item
    {

        public ArmorType ArmorClass { get; set; }
        public HeroAttribute ArmorAttribute { get; set; }

        public ArmorItem(string name, int reqLevel, Slot slotType, ArmorType armorClass, HeroAttribute armorAttribute) : base(name, reqLevel, slotType)
        {
            ArmorClass = armorClass;
            ArmorAttribute = armorAttribute;
        }

        public override ArmorType GetArmorType()
        {
            return ArmorClass;
        }
        public override HeroAttribute GetArmorAttribute()
        {
            return ArmorAttribute;
        }
        public override WeponType GetWeponType()
        {
            throw new NotImplementedException();
        }
        public override int GetWeaponDamage()
        {
            throw new NotImplementedException();
        }

    }
}
