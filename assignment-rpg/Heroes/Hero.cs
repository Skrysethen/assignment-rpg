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
        public List<string> ValidWeponTypes { get; set; } = new List<string>();
        public List<string> ValidArmorTypes { get; set; } = new List<string>();

        public Hero(string name) {
            Name = name;
        }

    }
}
