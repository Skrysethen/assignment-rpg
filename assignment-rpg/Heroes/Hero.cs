using assignment_rpg.Items;
using System;
using System.Collections.Generic;
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
        //Dictonary to make TKey and TValue for equipment
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
            string ItemType = item.SlotType.ToString();

            //Testing for itemlevel equal or lower than herolvl 
            if(ItemLevel <= Level) {
                Equipment[item.SlotType] = item;
            }
            

        }

    }
}
