using WarriorWars.Enum;
using WarriorWars.Equipment;

namespace WarriorWars
{
    class Warrior
    {
        private const int GOOD_GUY_STARTING_HEALTH  = 20;
        private const int BAD_GUY_STARTING_HEALTH = 20;

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
                    weapon=new Weapon(faction);
                    armor=new Armor(faction);
                    health = BAD_GUY_STARTING_HEALTH;
                    break;
                    default:
                    break;
            }
        }

        public void attack(Warrior enemy)
        {
            int damage = weapon.Damage / enemy.armor.ArmorPoints;

            enemy.health -= damage;

            AttackResult(enemy, damage);
            Thread.Sleep(250);

        }

        private void AttackResult(Warrior enemy, int damage)
        {
            if (enemy.health <= 0)
            {
                enemy.isAlive = false;
                Tools.ColoredText($"{enemy.name} is dead!", ConsoleColor.Red);
                Tools.ColoredText($"{name} is victorious", ConsoleColor.Cyan);
            }
            else
            {
                Console.WriteLine($"{name} attacked {enemy.name}. {damage} damage was inflicted to {enemy.name}, remaning health of {enemy.health} is {enemy.health}");
            }
        }
    }
}
