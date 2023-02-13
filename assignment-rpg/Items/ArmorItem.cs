using assignment_rpg.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_rpg.Items
{
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

        public override WeponType GetWeponType()
        {
            throw new NotImplementedException();
        }

    }
}
