using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using WarriorsWars.Enum;
using WarriorsWars.Equipment;

namespace WarriorsWars
{
    class Warrior
    {
        private const int GOOD_GUY_STARTING_HEALTH=100;
        private int BAD_GUY_STARTING_HEALTH = 100;

        private readonly Faction FACTION;

        private int health;
        private string name;
        private bool isAlive;

        public bool IsAlive 
        {
            get 
            {
                return isAlive;
            }
        }

        private Weapon weapon;
        private Armor armor;

        public Warrior(string name, Faction faction)
        {
            this.name = name;
            FACTION = faction;
            isAlive = true;

            switch (faction)
            {
                case Faction.GoodGuy:
                    weapon = new Weapon(faction);
                    armor = new Armor(faction);
                    health = GOOD_GUY_STARTING_HEALTH;
                    break;
                case Faction.BadGuy:
                    weapon = new Weapon(faction);
                    armor = new Armor(faction);
                    health = BAD_GUY_STARTING_HEALTH;
                    break;
                default:
                    break;
            }
        }

        public void Attack(Warrior enemy)
        {
            int damage = weapon.Damage / enemy.armor.ArmorPoints;

            enemy.health = enemy.health - damage;

            if (enemy.health <= 0)
            {
                enemy.isAlive= false;
                Console.WriteLine($"{enemy.name} is dead! and {name} is Victorious!!");
            } else
            {
                Console.WriteLine($"{name} attacked {enemy.name}. {damage} was inflicted, remaining health {enemy.health} ");
            }

            Thread.Sleep(400); 
        }

    }
}
