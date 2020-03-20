using System;
using System.IO;

namespace Spil
{
    class Program
    {
        public const int WINDOW_HEIGHT = 30;
        public const int WINDOW_WIDTH = 60;
        public const bool CURSOR_VISIBLE = false;

        public static bool gameOver = false;
        public static bool win;
        public static int streak;

        static void Main(string[] args)
        {
            Console.WindowHeight = WINDOW_HEIGHT;
            Console.WindowWidth = WINDOW_WIDTH;
            Console.CursorVisible = CURSOR_VISIBLE;
            Dos_Main();
        }

        static void Dos_Main()
        {
            bool end = false;
            do
            {
                switch (StartMenu())
                {
                    case 1:
                        Game_Loop();
                        break;
                    case 2:
                        DisplayHighscore();
                        break;
                    case 3:
                        HowToPlay();
                        break;
                    case 4:
                        end = true;
                        break;
                }
            } while (!end);
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

                string menuChoice2 = "-- HIGHSCORE --";
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

                string guideText1 = "use arrow keys to navigate";
                string guideText2 = "press enter to select";
                Console.SetCursorPosition(WINDOW_WIDTH - guideText1.Length - 3, WINDOW_HEIGHT - 1);
                Tools.ColorfullWrite(guideText1, ConsoleColor.DarkGray);
                Console.SetCursorPosition(WINDOW_WIDTH - guideText1.Length - 3, WINDOW_HEIGHT);
                Tools.ColorfullWrite(guideText2, ConsoleColor.DarkGray);

                do
                {
                    choice = Console.ReadKey(true).Key;
                    switch (choice)
                    {
                        case ConsoleKey.UpArrow:
                            if (menuChoiceNumber != 1)
                                menuChoiceNumber -= 1;
                            else
                                menuChoiceNumber = 4;
                            break;
                        case ConsoleKey.DownArrow:
                            if (menuChoiceNumber != 4)
                                menuChoiceNumber += 1;
                            else
                                menuChoiceNumber = 1;
                            break;
                        case ConsoleKey.Enter:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            return menuChoiceNumber;
                    }
                } while (choice != ConsoleKey.UpArrow && choice != ConsoleKey.DownArrow && choice != ConsoleKey.Enter);
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

        static void Game_Loop()
        {
            streak = 0;
            Random rand = new Random();
            do
            {
                gameOver = false;
                win = false;
                int attempts = 0;
                int aim = rand.Next(0, 10);
                do
                {
                    string indtastTalText = "INPUT NUMBER";
                    Console.SetCursorPosition(DefaultCursorPositionWidth(indtastTalText), DefaultCursorPositionHeight());
                    Tools.ColorfullWrite(indtastTalText, ConsoleColor.Blue);
                    Console.SetCursorPosition(WINDOW_WIDTH / 2, DefaultCursorPositionHeight() + 1);
                    int input = -1;

                    string attemptsRemaining = "ATTEMPTS REMAINING";
                    Console.SetCursorPosition(DefaultCursorPositionWidth(attemptsRemaining), DefaultCursorPositionHeight() + 5);
                    Tools.ColorfullWrite(attemptsRemaining, ConsoleColor.Green);
                    Console.SetCursorPosition(WINDOW_WIDTH / 2, DefaultCursorPositionHeight() + 6);
                    Tools.ColorfullWrite((3 - attempts).ToString(), ConsoleColor.Green);

                    string streakText = $"STREAK: {streak}";
                    Console.SetCursorPosition(2, 2);
                    Tools.ColorfullWrite(streakText, ConsoleColor.Yellow);
                    bool keySuccess = false;
                    do
                    {
                        ConsoleKey ja = Console.ReadKey(true).Key;
                        switch (ja)
                        {
                            case ConsoleKey.D0:
                                input = 0;
                                keySuccess = true;
                                break;
                            case ConsoleKey.D2:
                                input = 2;
                                keySuccess = true;
                                break;
                            case ConsoleKey.D3:
                                input = 3;
                                keySuccess = true;
                                break;
                            case ConsoleKey.D4:
                                input = 4;
                                keySuccess = true;
                                break;
                            case ConsoleKey.D5:
                                input = 5;
                                keySuccess = true;
                                break;
                            case ConsoleKey.D6:
                                input = 6;
                                keySuccess = true;
                                break;
                            case ConsoleKey.D7:
                                input = 7;
                                keySuccess = true;
                                break;
                            case ConsoleKey.D8:
                                input = 8;
                                keySuccess = true;
                                break;
                            case ConsoleKey.D9:
                                input = 9;
                                keySuccess = true;
                                break;
                            case ConsoleKey.D1:
                                input = 1;
                                keySuccess = true;
                                break;
                        }
                    } while (!keySuccess);

                    if (input == aim)
                    {
                        win = true;
                        gameOver = true;
                    }
                    else if (input < aim)
                    {
                        string higherText = $"HIGHER THAN {input}";
                        Console.Clear();
                        Console.SetCursorPosition(DefaultCursorPositionWidth(higherText), DefaultCursorPositionHeight() - 2);
                        Tools.ColorfullWrite(higherText, ConsoleColor.Red);
                        attempts++;
                    }
                    else if (input > aim)
                    {
                        string lowerText = $"LOWER THAN {input}";
                        Console.Clear();
                        Console.SetCursorPosition(DefaultCursorPositionWidth(lowerText), DefaultCursorPositionHeight() - 2);
                        Tools.ColorfullWrite(lowerText, ConsoleColor.Red);
                        attempts++;
                    }

                    if (attempts == 3)
                        gameOver = true;
                } while (!gameOver);

                if (win)
                {
                    Win();
                    gameOver = false;
                    win = false;
                    streak += 1;
                }
                else
                    Lose(aim);
            } while (!gameOver);

        }

        static void Win()
        {
            string winText = "YOU WIN";
            string continueText = "Press any key to continue...";
            Console.Clear();
            Console.SetCursorPosition(DefaultCursorPositionWidth(winText), DefaultCursorPositionHeight() + 3);
            Tools.ColorfullWrite(winText, ConsoleColor.Green);
            Console.SetCursorPosition(DefaultCursorPositionWidth(continueText), DefaultCursorPositionHeight() + 6);
            Tools.ColorfullWrite(continueText, ConsoleColor.White);
            Console.ReadKey();
            Console.Clear();
        }

        static void Lose(int aim)
        {
            string loseText = "YOU LOSE";
            string aimText = $"TARGET WAS: {aim.ToString()}";
            string streakText = $"YOUR STREAK WAS {streak}";
            Console.Clear();
            Console.SetCursorPosition(DefaultCursorPositionWidth(loseText), DefaultCursorPositionHeight() + 1);
            Tools.ColorfullWrite(loseText, ConsoleColor.Red);
            Console.SetCursorPosition(DefaultCursorPositionWidth(aimText), DefaultCursorPositionHeight() + 2);
            Tools.ColorfullWrite(aimText, ConsoleColor.Green);
            Console.SetCursorPosition(DefaultCursorPositionWidth(streakText), DefaultCursorPositionHeight() + 3);
            Tools.ColorfullWrite(streakText, ConsoleColor.Green);

            if(streak > Convert.ToInt32(ReadHighscore()))
            {
                WriteHighscore(streak);
                string highscoreText = "NEW HIGHSCORE!:";
                Console.SetCursorPosition(DefaultCursorPositionWidth(highscoreText), DefaultCursorPositionHeight() + 6);
                Tools.ColorfullWrite(highscoreText, ConsoleColor.Blue);
                Console.SetCursorPosition(DefaultCursorPositionWidth(streak.ToString()), DefaultCursorPositionHeight() + 7);
                Tools.ColorfullWrite(streak.ToString(), ConsoleColor.Yellow);
            }

            string continueText = "Press any key to continue...";
            Console.SetCursorPosition(DefaultCursorPositionWidth(continueText), DefaultCursorPositionHeight() + 9);
            Tools.ColorfullWrite(continueText, ConsoleColor.White);
            Console.ReadKey();
            Console.Clear();
        }

        static void DisplayHighscore()
        {
            string scoreText = "CURRENT HIGHSCORE:";
            string score = ReadHighscore();
            Console.Clear();
            Console.SetCursorPosition(DefaultCursorPositionWidth(scoreText), DefaultCursorPositionHeight());
            Tools.ColorfullWrite(scoreText, ConsoleColor.Blue);
            Console.SetCursorPosition(DefaultCursorPositionWidth(score), DefaultCursorPositionHeight() + 1);
            Tools.ColorfullWrite(score, ConsoleColor.Green);

            string continueText = "Press any key to continue...";
            Console.SetCursorPosition(DefaultCursorPositionWidth(continueText), DefaultCursorPositionHeight() + 9);
            Tools.ColorfullWrite(continueText, ConsoleColor.White);
            Console.ReadKey();
            Console.Clear();
        }

        static string ReadHighscore()
        {
            try
            {
                return File.ReadAllText(@"E:\Program Files (x86)\Microsoft Visual Studio\Projects\SKP_Corona-Periode\Spil\Spil\highscore.txt");
            }
            catch (Exception)
            {
                return "-1";
            }
        }

        static void WriteHighscore(int score)
        {
            try
            {
                File.WriteAllText(@"E:\Program Files (x86)\Microsoft Visual Studio\Projects\SKP_Corona-Periode\Spil\Spil\highscore.txt", String.Empty);
                File.WriteAllText(@"E:\Program Files (x86)\Microsoft Visual Studio\Projects\SKP_Corona-Periode\Spil\Spil\highscore.txt", score.ToString());
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        static void HowToPlay()
        {
            string mes1 = "Navigate menu with arrow keys";
            string mes2 = "Enter number between 0 and 9";
            string mes3 = "An indicator will show whether";
            string mes3v2 = "the target number is higher or lower";
            Console.SetCursorPosition(DefaultCursorPositionWidth(mes1), DefaultCursorPositionHeight());
            Tools.ColorfullWrite(mes1, ConsoleColor.Blue);
            Console.SetCursorPosition(DefaultCursorPositionWidth(mes2), DefaultCursorPositionHeight() + 2);
            Tools.ColorfullWrite(mes2, ConsoleColor.Blue);
            Console.SetCursorPosition(DefaultCursorPositionWidth(mes3), DefaultCursorPositionHeight() + 4);
            Tools.ColorfullWrite(mes3, ConsoleColor.Blue);
            Console.SetCursorPosition(DefaultCursorPositionWidth(mes3v2), DefaultCursorPositionHeight() + 5);
            Tools.ColorfullWrite(mes3v2, ConsoleColor.Blue);

            string continueText = "Press any key to continue...";
            Console.SetCursorPosition(DefaultCursorPositionWidth(continueText), DefaultCursorPositionHeight() + 9);
            Tools.ColorfullWrite(continueText, ConsoleColor.White);
            Console.ReadKey();
            Console.Clear();
        }
    }
}
