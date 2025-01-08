using System;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

public class HelloWorld
{
    //menu
    public static bool MenuList()
    {
        while (true)
        {
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. About the author");
            Console.WriteLine("3. Exit");
            int menuButton = Convert.ToInt32(Console.ReadLine());
            if (menuButton == 1)
            {
                return true;
                break;
            }
            else if (menuButton == 2)
            {
                Console.Clear();
                Console.WriteLine("Created by Mykhailenko Vadym!");
            }
            else if (menuButton == 3)
            {
                Console.WriteLine("Are you certain? (y/n)");
                string ans = Console.ReadLine();
                if (ans == "y")
                {
                    return false;
                    break;
                }
                else
                {
                    Console.Clear();     
                }


            }

        }
    }

    public static void Main(string[] args)
    {
        bool gameRun = MenuList();


        string[] yFirst = { " ", " ", " " };
        string[] ySecond = { " ", " ", " " };
        string[] yThird = { " ", " ", " " };
        string[][] Board = { yFirst, ySecond, yThird };
        string player = "X";
        
        int turns = 0;
        while (gameRun)
        {
            //Board
            for (int boxRow = 0; boxRow < 3; boxRow++)
            {
                Console.WriteLine($" {Board[boxRow][0]} | {Board[boxRow][1]} | {Board[boxRow][2]} ");
                if (boxRow < 2) Console.WriteLine("---+---+---");
            }

            //Win?
            for (int i = 0; i < Board.Length; i++)
            {
                //Vertical
                if (Board[i][0] != " " && Board[i][0] == Board[i][1] && Board[i][1] == Board[i][2])
                {
                    Console.WriteLine($"{Board[i][0]} is victorious!");
                    gameRun = false;
                    break;
                }
                //Horizontal
                if (Board[0][i] != " " && Board[0][i] == Board[1][i] && Board[1][i] == Board[2][i])
                {
                    Console.WriteLine($"{Board[0][i]} is victorious!");
                    gameRun = false;
                    break;
                }
                //Diagonal 1
                if (Board[0][0] != " " && Board[0][0] == Board[1][1] && Board[1][1] == Board[2][2])
                {
                    Console.WriteLine($"{Board[0][i]} is victorious!");
                    gameRun = false;
                    break;

                }
                //Diagonal 2
                if (Board[0][2] != " " && Board[0][2] == Board[1][1] && Board[1][1] == Board[2][0])
                {
                    Console.WriteLine($"{Board[0][i]} is victorious!");
                    gameRun = false;
                    break;
                }
            }
            //Tie?
            if (gameRun) 
            { 
                if (turns == 9)
                {
                    Console.WriteLine("Tie!");
                    break;
                }
            }


            //Action
            if (gameRun)
            {
                Console.Write($"{player}’s move > ");
                int Act = Convert.ToInt32(Console.ReadLine());
                Act -= 1;
                //In range?
                if (Act > -1 && Act < 9)
                {
                    int selRow = 0;
                    while (Act > 2)
                    {
                        Act -= 3;
                        selRow++;
                    }
                    if (Board[selRow][Act] == " ")
                    {
                        Board[selRow][Act] = player;
                        if (player == "X")
                        {
                            player = "O";
                        }
                        else player = "X";
                        turns++;
                    }
                }
                Console.Clear();
            }
        }
    }
}
