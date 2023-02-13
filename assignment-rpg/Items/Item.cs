using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace assignment_rpg.Items
{
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

        

    }



}
