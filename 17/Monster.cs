using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17
{
    internal class Monster : Character
    {
        public Monster() : base()
        { }
        public Monster(int maximumHealth, string name, int minimumAttackPower,
            int maximumAttackPower) : base(maximumHealth, name,
                minimumAttackPower, maximumAttackPower)
        { }
        
    }
}
