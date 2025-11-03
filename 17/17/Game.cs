using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _17
{
    internal class Game
    {
        public string[] iterationGame(int PlayerChoice, Player Hero, Monster Enemy)
        {
            string[] act = new string[] { };
            int _playerAttack;
            int _enemyAttack;
            switch (PlayerChoice)
            {
                case 1:
                    _playerAttack = Hero.GetAttackDamage();
                    _enemyAttack = Enemy.GetAttackDamage();
                    Hero.TakeDamage(_enemyAttack);
                    Enemy.TakeDamage(_playerAttack);
                    act = new string[3] { $"{Hero.GetName()} атакует и наносит {_playerAttack} урона", $"{Enemy.GetName()} монстрик думает над ходом", $"Злой монстрик атакует и наносит {_enemyAttack} урона" };
                    return act;
                case 2:
                    _playerAttack = (int)Hero.SpecialAttackTakeDamage(Hero.GetAttackDamage());
                    _enemyAttack = Enemy.GetAttackDamage();
                    Hero.TakeDamage(_enemyAttack);
                    Enemy.TakeDamage(_playerAttack);
                    act = new string[3] { $"{Hero.GetName()} атакует специальной атакой и наносит {_playerAttack} урона", $"{Enemy.GetName()} думает над ходом", $"Злой монстрик атакует и наносит {_enemyAttack} урона" };
                    return act;
                case 3:
                    Hero.Heal(Hero.RecoveredXP);
                    _enemyAttack = Enemy.GetAttackDamage();
                    Hero.TakeDamage(_enemyAttack);
                    act = new string[3] { $"{Hero.GetName()} использует лечение и восстанавливает {Hero.RecoveredXP} xp", $"{Enemy.GetName()} думает над ходом", $"Злой монстрик атакует и наносит {_enemyAttack} урона" };
                    return act;
                case 4:
                    Hero.TakeDamage(Hero.CurrentHealth);
                    act = new string[] { $"{Hero.GetName()} сдается!", "...", "..." };
                    return act;
                default:
                    string[] error = new string[] { "Непредвиденная ошибка!", "Непредвиденная ошибка!", "Непредвиденная ошибка!" };
                    return error;
            }
        }

        public bool CheckLife(Player Hero, Monster Enemy)
        {
            if (Hero.GetHealth() <=0 || Enemy.GetHealth() <= 0) return false;
            else return true;
        }

        public string ResultGame(Player Hero, Monster Enemy) {
            if (Hero.GetHealth() <= 0 && Enemy.GetHealth() <= 0) return "Удивительно! Никто не ушел живым! Каждый получил чего желал, но какой ценой...";
            else if (Hero.GetHealth() <= 0) return "Вы проиграли! Иногда даже сделав все правильно, поражения не избежать...";
            else if (Enemy.GetHealth() <= 0) return "Вы победили! Стоило ли оно того?";
            else return "Ошибка!";
        }
    }
}


