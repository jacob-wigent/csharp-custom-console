using System;

namespace Game {

    public static class GameConsole
    {
        static readonly int menuLineWidth = 30;
        static readonly int leftMargin = 5;
        static readonly int topMargin = 2;
        static readonly int maxLineWidth = Console.WindowWidth - menuLineWidth - (2*leftMargin);

        static int currentLine = 1 + topMargin;
        static int currentChar = 0;

        public static void WriteLine(string text)
        {
            Console.SetCursorPosition(menuLineWidth + leftMargin + currentChar, currentLine);
            Console.Write(text);
            currentLine++;
            currentChar = 0;
            Console.SetCursorPosition(menuLineWidth + leftMargin + currentChar, currentLine);
        }

        public static void Write(string text)
        {
            Console.SetCursorPosition(menuLineWidth + leftMargin + currentChar, currentLine);
            Console.Write(text);
            currentChar = Console.GetCursorPosition().Left - (menuLineWidth + leftMargin);
            Console.SetCursorPosition(menuLineWidth + leftMargin + currentChar, currentLine);
        }

        public static void Clear()
        {
            for (int i = topMargin; i < Console.WindowHeight - topMargin; i++)
            {
                Console.SetCursorPosition(menuLineWidth + leftMargin, i);
                Console.Write(new string(' ', maxLineWidth));
            }
            currentLine = 1 + topMargin;
            currentChar = 0;
            Console.SetCursorPosition(menuLineWidth + leftMargin, currentLine);
        }

        public static void GenerateUI()
        {
            ConsoleColor healthColor;
            if (Player.currentHealth >= 8)
            {
                healthColor = ConsoleColor.DarkGreen;
            }
            else if (Player.currentHealth >= 4)
            {
                healthColor = ConsoleColor.DarkYellow;
            }
            else
            {
                healthColor = ConsoleColor.DarkRed;
            }


            //DISPLAY HEALTH
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(new string('=', menuLineWidth+1));
            string healthText = $"{Player.currentHealth}/{Player.maxHealth}";
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" Health: ");
            Console.ForegroundColor = healthColor;
            Console.Write(healthText + new string(' ', menuLineWidth - (healthText.Length + 10)));
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("|");

            //DISPLAY GOLD
            Console.ForegroundColor = ConsoleColor.DarkGray;
            string goldText = $"{Player.currentGold}";
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" Gold: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(goldText + new string(' ', menuLineWidth - (goldText.Length + 8)));
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("|");

            Console.WriteLine(new string('=', menuLineWidth+1));

            Console.ForegroundColor = ConsoleColor.DarkGray;

            //DISPLAY INVENTORY
            string inventoryTitle = "Inventory:";
            Console.Write("| ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{inventoryTitle}" + new string(' ', menuLineWidth - (inventoryTitle.Length + 2)));
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("|");
            for (int i = 0; i < 10; i++)
            {
                string itemText = "";
                if(i < Player.inventory.Count)
                {
                    itemText = $"{i+1}. " + Player.inventory[i].itemName;
                }
                Console.Write("| ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(itemText + new string(' ', menuLineWidth - (itemText.Length + 2)));
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("|");
            }
            Console.WriteLine(new string('=', menuLineWidth+1));

            //DISPLAY STATUS BOX 16
            for (int i = 16; i < Console.WindowHeight-1; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("|" + new string('@', menuLineWidth-1) + "|");
            }
            Console.SetCursorPosition(0, Console.WindowHeight-1);
            Console.Write(new string ('=', menuLineWidth+1));
            
            Console.SetCursorPosition(menuLineWidth+1, 0);
            Console.Write(new string('=', Console.WindowWidth - (menuLineWidth+1)));
            for (int i = 1; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth-1, i);
                Console.Write("|");
            }
            Console.SetCursorPosition(menuLineWidth+1, Console.WindowHeight-1);
            Console.Write(new string('=', Console.WindowWidth - (menuLineWidth+1)));

            Console.ForegroundColor = ConsoleColor.White;
            currentLine = 1 + topMargin;
            currentChar = 0;
            Console.SetCursorPosition(menuLineWidth + leftMargin + currentChar, currentLine);
        }
    }

}