using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Game
{
    public static class GameManager
    {   

        static string playerName;
        static readonly int lineDelay = 2000;

        private static void Initialize()
        {
            Player.currentGold = 12;
            Player.currentHealth = 6;
            Player.inventory.Add(ItemDatabase.apple);
            Player.inventory.Add(ItemDatabase.rustySword);
        }

        public static void GameLoop()
        {
            Console.Clear();
            GameConsole.GenerateUI();
        }

        public static void Main(string[] args)
        {
            TitleScreen();
        }

        public static void TitleScreen()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n\n\n\n\n");
            
            string[] lines = new string[]
            {
                @" _________  __              _____                    _     ___  ____    _                         __                      ",
                @"|  _   _  |[  |            |_   _|                  / |_  |_  ||_  _|  (_)                       |  ]                    ",
                @"|_/ | | \_| | |--.  .---.    | |       .--.   .--. `| |-'   | |_/ /    __   _ .--.   .--./)  .--.| |  .--.   _ .--..--.  ",
                @"    | |     | .-. |/ /__\\   | |   _ / .'`\ \( (`\] | |     |  __'.   [  | [ `.-. | / /'`\;/ /'`\' |/ .'`\ \[ `.-. .-. | ",
                @"   _| |_    | | | || \__.,  _| |__/ || \__. | `'.'. | |,   _| |  \ \_  | |  | | | | \ \._//| \__/  || \__. | | | | | | |  ",
                @"  |_____|  [___]|__]'.__.' |________| '.__.' [\__) )\__/  |____||____|[___][___||__].',__`  '.__.;__]'.__.' [___||__||__] ",
                @"                                                                                   ( ( __))                               "
            };

            foreach (string line in lines)
            {
                int padding = (Console.WindowWidth - line.Length) / 2;
                if (padding < 0) padding = 0; // In case the text is wider than the console
                Console.WriteLine(new string(' ', padding) + line);
            }

            Console.ForegroundColor = ConsoleColor.White;
            string continueText = "Press any key to begin journey...";
            Console.SetCursorPosition((Console.WindowWidth/2) - (continueText.Length/2), 24);
            Console.WriteLine(continueText);
            Console.ReadKey();

            Initialize();
            WakeUp();
        }

        static void Delay(int cycles)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < cycles; i++)
            {
                GameConsole.Write(" . ");
                Thread.Sleep(lineDelay/2);
            }
            GameConsole.WriteLine("");
            Thread.Sleep(lineDelay);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void WakeUp()
        {
            GameLoop();
            Thread.Sleep(lineDelay/3);
            GameConsole.WriteLine("You slowly open your eyes, feeling groggy and disoriented.");
            GameConsole.WriteLine("");
            Thread.Sleep(lineDelay);
            GameConsole.WriteLine("As your vision clears, you realize you're in a cozy tavern, lying on a comfortable bed.");
            GameConsole.WriteLine("");
            Thread.Sleep(lineDelay);
            GameConsole.WriteLine("A concerned figure leans over you, a warm smile on their face.");
            GameConsole.WriteLine("");
            Thread.Sleep(lineDelay);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            GameConsole.WriteLine("");
            GameConsole.WriteLine("");
            GameConsole.WriteLine("Press any key to continue...");
            Console.ReadKey();
            GameConsole.Clear();

            Console.ForegroundColor = ConsoleColor.White;
            GameConsole.WriteLine("\"Ah, you're awake!\" the person exclaims, their voice gentle.");
            GameConsole.WriteLine("");
            Thread.Sleep(lineDelay);
            GameConsole.WriteLine("\"We found you unconscious outside the tavern and brought you in.\"");
            GameConsole.WriteLine("");
            Thread.Sleep(lineDelay);
            GameConsole.WriteLine("\"Do you remember your name?\"");
            GameConsole.WriteLine("");
            Thread.Sleep(lineDelay);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            GameConsole.WriteLine("");
            GameConsole.WriteLine("");
            GameConsole.WriteLine("Enter your name:");
            Console.ForegroundColor = ConsoleColor.White;
            playerName = Console.ReadLine();

            GameConsole.Clear();
            Console.ForegroundColor = ConsoleColor.White;

            GameConsole.WriteLine($"\"{playerName}, is it?\" the person nods.");
            GameConsole.WriteLine("");
            Thread.Sleep(lineDelay);
            GameConsole.WriteLine("\"It's good to meet you. My name is Elara, and I run this tavern.\"");
            GameConsole.WriteLine("");
            Thread.Sleep(lineDelay);
            GameConsole.WriteLine("\"You seemed to have had quite the adventure. Please, take your time to recover.");
            GameConsole.WriteLine("When you're ready, come downstairs and we'll talk.\"");
            GameConsole.WriteLine("");
            Thread.Sleep(lineDelay);

            BedDecision();
        }

        static void BedDecision()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                GameConsole.WriteLine("");
                GameConsole.WriteLine("What would you like to do?");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                GameConsole.WriteLine("1. Get up and go downstairs.");
                GameConsole.WriteLine("2. Stay in bed a little longer.");
                GameConsole.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                GameConsole.Write("Enter the number of your choice: ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;

                string response = Console.ReadLine();
                switch (response)
                {
                    case "1":
                        GameConsole.Clear();
                        GoDownstairs();
                        return;
                    case "2":
                        GameConsole.Clear();
                        StayInBed();
                        return;
                    default:
                        GameConsole.Clear();
                        GameConsole.WriteLine("Invalid answer... Please try again");
                        break;
                }
            }
        }

        static void StayInBed()
        {
            Console.ForegroundColor = ConsoleColor.White;
            GameConsole.WriteLine("You decide to stay in bed.");
            GameConsole.WriteLine("");
            
            Delay(3);

            Player.ChangeHealth(2);
            GameLoop();
            GameConsole.WriteLine("You rest for a while longer, feeling more refreshed.");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            GameConsole.WriteLine("+2 Health");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            GameConsole.WriteLine("");
            BedDecision();
        }

        static void GoDownstairs()
        {
            GameConsole.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            GameConsole.WriteLine("You get up and head downstairs.");
            GameConsole.WriteLine("");
            GameConsole.WriteLine("");
            
            // Simulate a brief description of the tavern downstairs
            Thread.Sleep(lineDelay);
            GameConsole.WriteLine("The tavern downstairs is bustling with activity.");
            Thread.Sleep(lineDelay);
            GameConsole.WriteLine("");
            GameConsole.WriteLine("There are a few patrons scattered around, chatting and enjoying their drinks.");
            Thread.Sleep(lineDelay);
            GameConsole.WriteLine("");
            GameConsole.WriteLine("Elara is behind the bar, preparing drinks and greeting customers.");
            Thread.Sleep(lineDelay);
            GameConsole.WriteLine("");
            GameConsole.WriteLine("");
            // Call the method to ask how the player is feeling
            AskHowFeeling();
        }

        static void AskHowFeeling()
        {
            Thread.Sleep(lineDelay);
            GameConsole.WriteLine("\"Welcome down!\" Elara calls out with a warm smile.");
            GameConsole.WriteLine("");

            Thread.Sleep(lineDelay);
            GameConsole.WriteLine("\"How are you feeling?\" she asks, wiping her hands on a cloth.");
            GameConsole.WriteLine("");
            GameConsole.WriteLine("");

            // Provide options to the player
            Thread.Sleep(lineDelay);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            GameConsole.WriteLine("1. I’m feeling much better, thank you.");
            GameConsole.WriteLine("2. I’m still a bit weak, but I’ll manage.");
            GameConsole.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            GameConsole.Write("Enter the number of your choice: ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            string response = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            GameConsole.Clear();
            switch (response)
            {
                case "1":
                    GameConsole.WriteLine("");
                    GameConsole.WriteLine("Elara smiles and nods, \"That’s great to hear! Feel free to take a seat and get comfortable.\"");
                    Thread.Sleep(lineDelay);
                    GameConsole.WriteLine("");
                    GameConsole.WriteLine("You find a seat and settle in, ready to enjoy the tavern's atmosphere.");
                    Thread.Sleep(lineDelay);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    GameConsole.WriteLine("");
                    GameConsole.WriteLine("");
                    GameConsole.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Wizard();
                    break;
                case "2":
                    Player.inventory.Add(ItemDatabase.healthPotion);
                    GameLoop();
                    GameConsole.WriteLine("");
                    GameConsole.WriteLine("Elara looks concerned and says, \"I’m sorry to hear that.");
                    GameConsole.WriteLine("");
                    GameConsole.WriteLine("Here's a health potion that will make you feel better\"");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    GameConsole.WriteLine("");
                    GameConsole.WriteLine("+ Health Potion");
                    Thread.Sleep(lineDelay);
                    GameConsole.WriteLine("");
                    GameConsole.WriteLine("");
                    action:
                    Console.ForegroundColor= ConsoleColor.DarkGray;
                    GameConsole.WriteLine("What would you like to do?");
                    Console.ForegroundColor= ConsoleColor.DarkGreen;
                    GameConsole.WriteLine("1. Use Item");
                    GameConsole.WriteLine("2. Nothing");
                    GameConsole.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    GameConsole.Write("Enter the number of your choice: ");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    string actionResponse = Console.ReadLine();

                    if (actionResponse == "1")
                    {
                        SelectItem();
                        Wizard();
                    }
                    else if (actionResponse == "2")
                    {
                        Wizard();
                    }
                    else
                    {
                        GameConsole.Clear();
                        GameConsole.WriteLine("Invalid choice... Please try again.");
                        GameConsole.WriteLine("");
                        goto action;
                    }
                    break;
                default:
                    GameConsole.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    GameConsole.WriteLine("Invalid choice... Please try again.");
                    GameConsole.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.White;
                    AskHowFeeling(); // Re-prompt the player
                    break;
            }
        }

        static void SelectItem()
        {
            GameConsole.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            GameConsole.Write("Select the item you would like to use: ");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            int itemIndex = Convert.ToInt16(Console.ReadLine()) - 1;
            if (itemIndex < Player.inventory.Count && itemIndex >= 0)
            {
                if(!Player.inventory[itemIndex].Use())
                {
                    GameConsole.WriteLine("");
                    GameConsole.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    GameConsole.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.ForegroundColor = ConsoleColor.White;
                    SelectItem();
                }
                else
                {
                    GameConsole.WriteLine("");
                    GameConsole.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    GameConsole.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                    Console.ForegroundColor = ConsoleColor.White;
                    GameConsole.WriteLine("That item does not exist!");
                    GameConsole.WriteLine("");
                    GameConsole.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    GameConsole.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.ForegroundColor = ConsoleColor.White;
                    SelectItem();
            }
        }

        static void Wizard()
        {
            GameConsole.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            GameConsole.WriteLine("As you settle in, you overhear a hushed conversation from a nearby table.");
            GameConsole.WriteLine("");

            Thread.Sleep(lineDelay);
            GameConsole.WriteLine("A patron speaks in a low voice, \"Have you heard the rumors about the wizard in the mountains?\"");
            GameConsole.WriteLine("");
            Thread.Sleep(lineDelay);
            GameConsole.WriteLine("His companion nods grimly. \"They say he's a master of dark magic and rules with an iron fist.\"");
            GameConsole.WriteLine("");

            Thread.Sleep(lineDelay);
            GameConsole.WriteLine("The first patron shudders. \"People are terrified of him.");
            GameConsole.WriteLine("They say he can sense anyone who even thinks about opposing him.\"");
            GameConsole.WriteLine("");
            Thread.Sleep(lineDelay);
            GameConsole.WriteLine("\"It's like he has eyes everywhere,\" the other replies, glancing around nervously.");
            GameConsole.WriteLine("");

            Thread.Sleep(lineDelay);
            GameConsole.WriteLine("You feel a chill down your spine. The atmosphere in the tavern grows tense.");
            GameConsole.WriteLine("");
            Thread.Sleep(lineDelay);
            GameConsole.WriteLine("Suddenly, the ground shakes violently...");
            Thread.Sleep(lineDelay);
            GameConsole.WriteLine("");
            GameConsole.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            GameConsole.WriteLine("Press any key to continue...");
            Console.ReadKey();

            Meteor();
        }


        static void Meteor()
        {
            GameConsole.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            GameConsole.WriteLine("The ground trembles beneath your feet, a deep rumbling growing louder.");
            GameConsole.WriteLine("");
            Thread.Sleep(lineDelay);
            
            GameConsole.WriteLine("Suddenly, the sky outside lights up with an otherworldly glow.");
            GameConsole.WriteLine("");
            Thread.Sleep(lineDelay);
            
            GameConsole.WriteLine("Before you can react, a blinding flash fills the room, followed by an earth-shattering explosion.");
            GameConsole.WriteLine("");
            Thread.Sleep(lineDelay);
            
            Console.ForegroundColor = ConsoleColor.DarkRed;
            GameConsole.WriteLine("A METEOR CRASHES INTO THE TAVERN, UNLEASHING A DEVASTATING SHOCKWAVE!");
            GameConsole.WriteLine("");
            Thread.Sleep(lineDelay);
            
            GameConsole.WriteLine("THE BLAST KILLS EVERYONE, REDUCING THE LANDSCAPE TO ASHES INSTANTLY!");
            GameConsole.WriteLine("");
            Thread.Sleep(lineDelay);
            GameConsole.WriteLine("");
            GameConsole.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            GameConsole.WriteLine("Press any key to continue...");
            Console.ReadKey();

            End();
        }

        static void End()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n\n\n\n\n");
            
            string[] lines = new string[]
            {
                @" _________  __              ________                __  ",
                @"|  _   _  |[  |            |_   __  |              |  ] ",
                @"|_/ | | \_| | |--.  .---.    | |_ \_| _ .--.   .--.| |  ",
                @"    | |     | .-. |/ /__\\   |  _| _ [ `.-. |/ /'`\' |  ",
                @"   _| |_    | | | || \__.,  _| |__/ | | | | || \__/  |  ",
                @"  |_____|  [___]|__]'.__.' |________|[___||__]'.__.;__] ",
                @"                                                        "
            };

            foreach (string line in lines)
            {
                int padding = (Console.WindowWidth - line.Length) / 2;
                if (padding < 0) padding = 0; // In case the text is wider than the console
                Console.WriteLine(new string(' ', padding) + line);
            }

            Console.ForegroundColor = ConsoleColor.White;
            string continueText = "YOU DIED!";
            Console.SetCursorPosition((Console.WindowWidth/2) - (continueText.Length/2), 24);
            Console.WriteLine(continueText);
            Console.ReadKey();

        }
    }
}