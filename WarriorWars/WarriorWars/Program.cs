using System;
namespace WarriorWars.Enum
{
    class EntryPoint
    {
       static Random rng = new Random();
        static void Main()
        {
            
            Warrior goodGuy = new Warrior("Kalen", Faction.GoodGuy);
            Warrior badGuy = new Warrior("Kirei", Faction.BadGuy);
           
            while (goodGuy.IsAlive && badGuy.IsAlive)
            {
                if (rng.Next(0,10) < 5)
                {
                    goodGuy.attack(badGuy);
                }
                else
                {
                    badGuy.attack(goodGuy);
                }
            }
        }
    }
}