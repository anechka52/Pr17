using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17
{
    internal class Character
    {
        internal int CurrentHealth { get; private set; }
        private int _maximumHealth;
        internal string _name;
        internal int _minimumAttackPower;
        internal int _maximumAttackPower;

        public Character()
        {
            CurrentHealth = 100;
            _maximumHealth = 100;
            _name = "Нет имени";
            _minimumAttackPower = 5;
            _maximumAttackPower = 10;
        }
        public Character(int maximumHealth, string name, int minimumAttackPower, 
            int maximumAttackPower)
        { 
            CurrentHealth = maximumHealth;
            _maximumHealth = maximumHealth;
            _name = name;
            _minimumAttackPower = minimumAttackPower;
            _maximumAttackPower = maximumAttackPower;
        }
        public bool IsAlive => CurrentHealth > 0;
        public virtual int GetAttackDamage()
        {
            Random random = new Random();
            return random.Next(_minimumAttackPower, _maximumAttackPower + 1);
        }
        public virtual void TakeDamage(int Damage)
        {
            CurrentHealth -= Damage;
        }
        public virtual void Heal(int HealXP) 
        {
            if ((CurrentHealth + HealXP) >= _maximumHealth)
            {
                CurrentHealth = _maximumHealth;
            }
            else { CurrentHealth += HealXP; }
        }
        public string[] GetInfo() {
            return new string[] { _name, $"HP: {CurrentHealth}/{_maximumHealth}   {(CurrentHealth / _maximumHealth) * 100}%",$"Cила: от {_minimumAttackPower} до {_maximumAttackPower}"};
        }
        public string GetName() => _name;
        public int GetHealth() => CurrentHealth;
    }
}
