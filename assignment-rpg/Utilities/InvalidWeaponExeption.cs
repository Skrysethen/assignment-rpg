using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_rpg.Utilities
{
    public class InvalidWeaponExeption : Exception
    {
        public InvalidWeaponExeption(string message) : base(message) { }
    }
}
