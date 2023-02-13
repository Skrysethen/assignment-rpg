using assignment_rpg.Items;
using assignment_rpg.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_rpg.Heroes
{
    public abstract class Hero
    {
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; } = 1;
        public HeroAttribute? LevelAttributes { get; set; }
        public HeroAttribute? TotalAttributes { get; set; } = new HeroAttribute { Str = 0, Dex= 0, Intelligence = 0 };
        public Dictionary<Slot, Item?> Equipment { get; set; } = new Dictionary<Slot, Item?>();
        public List<string> ValidWeponTypes { get; set; } = new List<string>();
        public List<string> ValidArmorTypes { get; set; } = new List<string>();

        public Hero(string name) 
        {
            Name = name;
            Equipment.Add(Slot.Weapon, null);
            Equipment.Add(Slot.Head, null);
            Equipment.Add(Slot.Body, null);
            Equipment.Add(Slot.Legs, null);
        }

        public void Equip(Item item)
        {
            int ItemLevel = item.ReqLevel;

            if (item.SlotType == Slot.Weapon)
            {
                string weponClass = item.GetWeponType().ToString();                
                bool canEquip = ValidWeponTypes.Contains(weponClass);

                if (canEquip && ItemLevel <= Level)
                {
                    Equipment[item.SlotType] = item;
                } else
                {
                    if (canEquip)
                        throw new InvalidWeaponExeption("Too low lvl for that weapon");
                   //Throw exeption here too low lvl or cant use that item
                   throw new InvalidWeaponExeption("Your class cant use that item");
                }

            } else if(item.SlotType == Slot.Head || item.SlotType == Slot.Body || item.SlotType == Slot.Legs) 
            {
                string armorClass = item.GetArmorType().ToString();
                bool canEquip = ValidArmorTypes.Contains(armorClass);
                if (canEquip && ItemLevel <= Level) { Equipment[item.SlotType] = item; }

                else
                {
                    if (canEquip)
                        throw new InvalidArmorExeption("Too low lvl for this armor");
                    throw new InvalidArmorExeption("Your class cant use that item");
                }

            } else {
                //Trow expetion, this item cant be used, no valid slot      
                //Make a new exeption for this occurence
            }

        }

        public void CalculateTotalAttributes()
        {
            this.TotalAttributes = this.LevelAttributes;
            foreach (var item in Equipment)
            {
                if(item.Key != Slot.Weapon) { 
                    if(item.Value != null)
                    {
                        HeroAttribute rhs = item.Value.GetArmorAttribute();
                        this.TotalAttributes +=  rhs; 
                    }
                }
            }
        }

        public abstract double Damage();
    }
}
