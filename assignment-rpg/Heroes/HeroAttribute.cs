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


        public static HeroAttribute operator +(HeroAttribute lhs, HeroAttribute rhs)
        {
            return new HeroAttribute { Str = lhs.Str + rhs.Str, Intelligence = lhs.Intelligence + rhs.Intelligence, Dex = lhs.Dex + rhs.Dex };
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
