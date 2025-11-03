using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17
{
    internal class Player : Character
    {
        private int _theNumberOfRecoveredXP;
        private double _specialAttackCoefficient;
        internal bool _usingSpecialAttack {  get; private set; }
        internal int RecoveredXP { get => _theNumberOfRecoveredXP; }


        public Player() : base()
        {
            _theNumberOfRecoveredXP = 0;
            _specialAttackCoefficient = 0;
            _usingSpecialAttack = false;
        }
        public Player(int maximumHealth, string name, int minimumAttackPower,
            int maximumAttackPower, int theNumberOfRecoveredXP,
            double specialAttackCoefficient) : base(maximumHealth, name,
                minimumAttackPower, maximumAttackPower)
        {
            _theNumberOfRecoveredXP = theNumberOfRecoveredXP;
            _specialAttackCoefficient = specialAttackCoefficient;
        }
        public double SpecialAttackTakeDamage(int Damage)
        {
            if (!_usingSpecialAttack)
            {
                return Damage * _specialAttackCoefficient;
            }
            else { return Damage; }
        }
    }
}
