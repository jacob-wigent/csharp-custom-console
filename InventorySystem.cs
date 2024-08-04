using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    public abstract class Item
    {
        public string itemName { get; set; }
        public abstract bool Use();
    }

    public class Consumable : Item
    {
        public int healthChange;
        public Consumable(string itemName, int healthChange)
        {
            this.itemName = itemName;
            this.healthChange = healthChange;
        }

        public override bool Use()
        {
            Player.ChangeHealth(healthChange);
            Player.inventory.Remove(this);
            GameManager.GameLoop();
            Console.ForegroundColor = ConsoleColor.White;
            GameConsole.WriteLine($"You consumed {itemName}");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"+{healthChange} Health");
            Console.ForegroundColor = ConsoleColor.White;
            return true;
        }
    }

    public class Weapon : Item
    {
        public int damage;
        public Weapon(string itemName, int damage)
        {
            this.itemName = itemName;
            this.damage = damage;
        }

        public override bool Use()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            GameConsole.WriteLine("Sorry, you can't use this item right now!");
            Console.ForegroundColor = ConsoleColor.White;
            return false;
        }
    }


    public static class ItemDatabase
    {
        public static readonly Item apple = new Consumable("Apple", 2);
        public static readonly Item healthPotion = new Consumable("Health Potion", 6);
        public static readonly Item rustySword = new Weapon("Rusty Sword", 1);
    }
}