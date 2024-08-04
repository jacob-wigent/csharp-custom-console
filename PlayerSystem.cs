using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    public static class Player
    {
        public static List<Item> inventory = new List<Item>();
        public static readonly int maxHealth = 10;
        public static int currentHealth;
        public static int currentGold;

        public static void Consume(Consumable consumableItem)
        {
            ChangeHealth(consumableItem.healthChange);
            inventory.Remove(consumableItem);
        }

        public static void ChangeHealth(int healthChange)
        {
            currentHealth = Math.Clamp(currentHealth + healthChange, 0, maxHealth);
        }
    }
}