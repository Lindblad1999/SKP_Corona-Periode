using System;

namespace Spil
{
    class Program
    {
        public const int WINDOW_HEIGHT = 30;
        public const int WINDOW_WIDTH = 60;
        public const bool CURSOR_VISIBLE = false;

        static void Main(string[] args)
        {
            Console.WindowHeight = WINDOW_HEIGHT;
            Console.WindowWidth = WINDOW_WIDTH;
            Console.CursorVisible = CURSOR_VISIBLE;
            Dos_Main();
        }

        static void Dos_Main()
        {
            StartMenu();
        }

        static int StartMenu()
        {
            int menuChoiceNumber = 1;
            ConsoleKey choice = ConsoleKey.P;
            do
            {
                string menuTitle = "** WELCOME **";
                Console.SetCursorPosition(DefaultCursorPositionWidth(menuTitle), DefaultCursorPositionHeight());
                Tools.ColorfullWrite(menuTitle, ConsoleColor.Blue);

                string menuChoice1 = "-- PLAY --";
                Console.SetCursorPosition(DefaultCursorPositionWidth(menuChoice1), DefaultCursorPositionHeight() + 3);
                if (menuChoiceNumber == 1)
                    Tools.ColorfullWrite(menuChoice1, ConsoleColor.Yellow);
                else
                    Tools.ColorfullWrite(menuChoice1, ConsoleColor.White);

                string menuChoice2 = "-- SETTINGS --";
                Console.SetCursorPosition(DefaultCursorPositionWidth(menuChoice2), DefaultCursorPositionHeight() + 6);
                if (menuChoiceNumber == 2)
                    Tools.ColorfullWrite(menuChoice2, ConsoleColor.Yellow);
                else
                    Tools.ColorfullWrite(menuChoice2, ConsoleColor.White);

                string menuChoice3 = "-- HOW TO PLAY --";
                Console.SetCursorPosition(DefaultCursorPositionWidth(menuChoice3), DefaultCursorPositionHeight() + 9);
                if (menuChoiceNumber == 3)
                    Tools.ColorfullWrite(menuChoice3, ConsoleColor.Yellow);
                else
                    Tools.ColorfullWrite(menuChoice3, ConsoleColor.White);

                string menuChoice4 = "-- QUIT --";
                Console.SetCursorPosition(DefaultCursorPositionWidth(menuChoice4), DefaultCursorPositionHeight() + 12);
                if (menuChoiceNumber == 4)
                    Tools.ColorfullWrite(menuChoice4, ConsoleColor.Yellow);
                else
                    Tools.ColorfullWrite(menuChoice4, ConsoleColor.White);

                do
                {
                    choice = Console.ReadKey(true).Key;
                    switch (choice)
                    {
                        case ConsoleKey.UpArrow:
                            if (menuChoiceNumber != 1)
                                menuChoiceNumber -= 1;
                            break;
                        case ConsoleKey.DownArrow:
                            if (menuChoiceNumber != 4)
                                menuChoiceNumber += 1;
                            break;
                        case ConsoleKey.Enter:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            return menuChoiceNumber;
                    }
                } while (choice != ConsoleKey.UpArrow && choice != ConsoleKey.DownArrow && choice != ConsoleKey.Enter);
                Console.Clear();
            } while (choice != ConsoleKey.Enter);
            return 0;
        }

        static int DefaultCursorPositionWidth(string text)
        {
            return (Console.WindowWidth / 2) - (text.Length / 2);
        }

        static int DefaultCursorPositionHeight()
        {
            return (Console.WindowHeight / 4);
        }
    }
}
