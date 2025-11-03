using System;
using System.Numerics;
using System.Threading;

namespace _17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player;
            Monster monster;

            //Настройка Игры
            Console.WriteLine("Для создания персонажей по умолчанию введите: Default");
            string userSetting = Console.ReadLine();
            CreatePerson(userSetting);

            //Подготовка к игре 
            Game game = new Game();
            string[] infoHero;
            string[] infoMonster;
            string[] resultIterationGame;
            int userChoice;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Новый бой начался!");

            //Игра
            while (game.CheckLife(player, monster))
            {
                //Обновление данных
                infoHero = player.GetInfo();
                infoMonster = monster.GetInfo();

                //Вывод UI
                Console.SetCursorPosition(0, 0);
                Console.Write($"{player.GetName()} готовиться к действию...");
                OutputStats();
                OutputMenu();

                //Вывод результата
                resultIterationGame = game.iterationGame(userChoice, player, monster);
                OutputResult();

                //Очистка
                Console.Clear();

            }
            EndGame();

            void CreatePerson(string userSetting)
            {
                if (userSetting == "Default" || userSetting == "default" || userSetting == "Дэфолт" || userSetting == "дэфолт")
                {
                    player = new Player(100, "Герой", 5, 20, 20, 2f);
                    monster = new Monster(100, "Монстрик", 5, 20);
                    Console.WriteLine("Создание персонажей по умолчанию произошло успешно!");
                    Console.ReadKey();
                    Console.Clear();

                }
                else
                {
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Введите имя игрока:");
                            string playerName = Console.ReadLine();
                            Console.WriteLine("Введите количество хп игрока:");
                            int playerXP = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите минимальный урон игрока");
                            int playerMinAttack = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите максимальный урон игрока");
                            int playerMaxAttack = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите сколько хп может восстановить игрок");
                            int playerRecoveredXP = Convert.ToInt32(Console.ReadLine());
                            player = new Player(playerXP, playerName, playerMinAttack, playerMaxAttack, playerRecoveredXP, 2);
                            Console.WriteLine("Введите имя монстрика:");
                            string monsterName = Console.ReadLine();
                            Console.WriteLine("Введите количество хп монстрика:");
                            int monsterXP = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите минимальный урон монстрика");
                            int monsterMinAttack = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите максимальный урон монстрика");
                            int monsterMaxAttack = Convert.ToInt32(Console.ReadLine());
                            monster = new Monster(monsterXP, monsterName, monsterMinAttack, monsterMaxAttack);
                            Console.WriteLine("Создание кастомных персонажей произошло успешно!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Введены некорректные данные!");
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        }

                    }
                }
            }

            void OutputStats()
            {
                //Вывод статистик игрока
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(60, 0);
                Console.Write(infoHero[0]);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(60, 1);
                Console.Write(infoHero[1]);
                Console.SetCursorPosition(60, 2);
                Console.Write(infoHero[2]);
                Console.ResetColor();

                //Вывод статистик противника
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(60, 3);
                Console.Write(infoMonster[0]);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(60, 4);
                Console.Write(infoMonster[1]);
                Console.SetCursorPosition(60, 5);
                Console.Write(infoMonster[2]);
                Console.ResetColor();

            }

            void OutputMenu()
            {
                while (true)
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(60, 7);
                        Console.WriteLine("Герой делает Ход:");
                        Console.SetCursorPosition(60, 8);
                        Console.ResetColor();
                        Console.WriteLine("1) Использовать атаку");
                        Console.SetCursorPosition(60, 9);
                        Console.WriteLine("2) Использовать специальную атаку");
                        Console.SetCursorPosition(60, 10);
                        Console.WriteLine("3) Излечиться");
                        Console.SetCursorPosition(60, 11);
                        Console.WriteLine("4) Сдаться");
                        Console.SetCursorPosition(60, 12);
                        Console.WriteLine("Ваш выбор:");
                        Console.SetCursorPosition(71, 12);
                        userChoice = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        Console.SetCursorPosition(60, 13);
                        Console.WriteLine("Такого действия нет!");
                        continue;
                    }
                }
            }

            void OutputResult()
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(0, 1);
                Console.WriteLine(resultIterationGame[0]);
                Console.ResetColor();
                Console.SetCursorPosition(0, 2);
                Console.WriteLine(resultIterationGame[1]);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(0, 3);
                Console.WriteLine(resultIterationGame[2]);
                Console.ResetColor();
                Console.ReadKey();
            }

            void EndGame() {
                Console.SetCursorPosition(0, 0);
                //Console.WriteLine(game.ResultGame(player, monster));
                foreach (var i in game.ResultGame(player, monster)) {
                    Console.Write(i);
                    Thread.Sleep(100);
                }
                Console.SetCursorPosition(0, 5);
                Console.WriteLine("Cпасибо за игру!");
            }
        }
    }
}

