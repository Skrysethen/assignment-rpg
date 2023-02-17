using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace assignment_rpg.Heroes
{
    public class HeroAttribute
    {
        public int Str { get; set; }
        public int Intelligence { get; set; }
        public int Dex { get; set; }


        public static HeroAttribute GetMageAttributes()
        {
            return new HeroAttribute { Str = 1, Dex = 1, Intelligence = 8 };
        }
        public static HeroAttribute GetWarriorAttributes()
        {
            return new HeroAttribute { Str = 5, Dex = 2, Intelligence = 1 };
        }
        public static HeroAttribute GetRangerAttributes()
        {
            return new HeroAttribute { Str = 1, Dex = 7, Intelligence = 1 };
        }
        public static HeroAttribute GetRogueAttributes()
        {
            return new HeroAttribute { Str = 2, Dex = 6, Intelligence = 1 };
        }

        public static HeroAttribute operator +(HeroAttribute lhs, HeroAttribute rhs)
        {
            return new HeroAttribute { Str = lhs.Str + rhs.Str, Intelligence = lhs.Intelligence + rhs.Intelligence, Dex = lhs.Dex + rhs.Dex };
        }

        public static HeroAttribute GetMageLevelUpAttributes()
        {
            return new HeroAttribute { Str = 1, Intelligence = 5, Dex = 1 };
        }
        public static HeroAttribute GetWarriorLevelUpAttributes()
        {
            return new HeroAttribute { Str = 3,  Dex = 2, Intelligence = 1 };
        }
        public static HeroAttribute GetRangerLevelUpAttributes()
        {
            return new HeroAttribute { Str = 1, Dex = 5, Intelligence = 1 };
        }
        public static HeroAttribute GetRogueLevelUpAttributes()
        {
            return new HeroAttribute { Str = 1, Dex = 4, Intelligence = 1 };
        }

        public override bool Equals(object? obj)
        {
            return obj is HeroAttribute attribute &&
                   Str == attribute.Str &&
                   Intelligence == attribute.Intelligence &&
                   Dex == attribute.Dex;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Str, Intelligence, Dex);
        }
    }
}
