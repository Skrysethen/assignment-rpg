using assignment_rpg.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_rpg.Heroes
{
    public class RangerHero : Hero
    {
        public RangerHero(string name) : base(name)
        {
            this.LevelAttributes = new HeroAttribute { Str = 1, Dex = 7, Intelligence = 1 };
            ValidArmorTypes.Add(ArmorType.Leather.ToString());
            ValidArmorTypes.Add(ArmorType.Mail.ToString());
            ValidWeponTypes.Add(WeponType.Bow.ToString());
        }

        public void RangerLevelUp(HeroAttribute oldAttribute)
        {
            HeroAttribute newAttribute = new HeroAttribute { Str = 1, Dex = 5, Intelligence = 1 };
            HeroAttribute addAttribute = oldAttribute + newAttribute;
            this.LevelAttributes = addAttribute;
        }
    }
}
