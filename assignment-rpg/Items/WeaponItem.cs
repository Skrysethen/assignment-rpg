using assignment_rpg.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace assignment_rpg.Items
{
    public class WeaponItem : Item
    {

        public int WeaponDamage { get; set; }
        public WeponType WeponClass { get; set; }

        public WeaponItem(string name, int reqLevel, Slot slotType, WeponType weponClass, int weaponDamage) : base(name, reqLevel, slotType)
        {
            WeaponDamage = weaponDamage;
            WeponClass = weponClass;
        }
        public override WeponType GetWeponType()
        {
            return WeponClass;
        }
        public override ArmorType GetArmorType()
        {
            throw new NotImplementedException();
        }
        public override HeroAttribute GetArmorAttribute()
        {
            throw new NotImplementedException();
        }
    }
}
