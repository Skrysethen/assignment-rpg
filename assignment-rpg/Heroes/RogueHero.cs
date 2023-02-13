using assignment_rpg.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_rpg.Heroes
{
    public class RogueHero : Hero
    {
        public RogueHero(string name) : base(name)
        {
            this.LevelAttributes = new HeroAttribute { Str = 2, Dex = 6, Intelligence = 1 };
            ValidArmorTypes.Add(ArmorType.Leather.ToString());
            ValidArmorTypes.Add(ArmorType.Mail.ToString());
            ValidWeponTypes.Add(WeponType.Dagger.ToString());
            ValidWeponTypes.Add(WeponType.Sword.ToString());
        }

        public void RogueLevelUp (HeroAttribute oldAttribute)
        {
            HeroAttribute newAttribute = new HeroAttribute { Str = 1, Dex = 4, Intelligence = 1 };
            HeroAttribute addAttribute = oldAttribute + newAttribute;
            this.Level++;
            this.LevelAttributes = addAttribute;


        }
    }
}
