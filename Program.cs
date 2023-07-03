using System;
using System.Threading;

namespace BattleShip
{
    class Program
    {
        static void Main(string[] args)
        {
            bool over = false;

            Console.WriteLine("Welcome in my BattleShip game created by NGUYEN Benjamin the 11 and 12 june of 2021.\n");
            Console.WriteLine("The rules are the clasic rules so it should'nt be hard to play\n");
            Console.WriteLine("Now you have to choose if you want to play with another player or versus the computer");
            Console.WriteLine("\n\nPress enter to continue");
            Console.ReadLine();

            while (!over)
            {
                Console.WriteLine("To choose PlayerVsPlayer mode enter 'pvp' and to choose PlayerVsComputer enter 'pve' :");
                Console.WriteLine("What game mode do you choose ? ");
                string gameMode = Console.ReadLine();
                Console.Clear();
                if (gameMode == "pvp") {PlayerVsPlayer();}
                else if (gameMode == "pve") {PlayerVsAI();}
                Console.WriteLine("Do you want to play again?\n\nTo play again enter 'again' or press enter to quit");
                string userOption = Console.ReadLine();
                if (userOption != "again") {over = true;}
            }
            Console.Clear();
            Console.WriteLine("Thank for playing my game !\nSee you next time !");
            Thread.Sleep(2000);
        }

        static char[,] Init()
        {
            char[,] battleShipArray = new char[10,10] {
                                                        {'~','~','~','~','~','~','~','~','~','~'},
                                                        {'~','~','~','~','~','~','~','~','~','~'},
                                                        {'~','~','~','~','~','~','~','~','~','~'},
                                                        {'~','~','~','~','~','~','~','~','~','~'},
                                                        {'~','~','~','~','~','~','~','~','~','~'},
                                                        {'~','~','~','~','~','~','~','~','~','~'},
                                                        {'~','~','~','~','~','~','~','~','~','~'},
                                                        {'~','~','~','~','~','~','~','~','~','~'},
                                                        {'~','~','~','~','~','~','~','~','~','~'},
                                                        {'~','~','~','~','~','~','~','~','~','~'}
                                                    };
            return battleShipArray;
        }

        static char[,] PlayerInit()
        {
            int carrier = 0;
            int battleship = 0;
            int cruiser = 0;
            int submarine = 0;
            int destroyer = 0;
            bool over = false;

            char[,] battleShipArray = Init();

            Console.Clear();

            while (!over)
            {
                Console.WriteLine("Voici le tableau actuelle :" + Environment.NewLine);
                DisplayedScreen(battleShipArray);
                Console.WriteLine(Environment.NewLine + "Veuillez entrer le navire choisi ainsi que sa position itiniale et la direction du navire.");
                Console.Write(Environment.NewLine + "Navire (carrier : 0, battleship : 1, cruiser : 2, submarine : 3, destroyer : 4) :");
                int selectedShip = new int();
                string shipNumber = Console.ReadLine();
                int.TryParse(shipNumber, out selectedShip);
                Console.Write(Environment.NewLine + "Position en ligne (a, b, c, ...) :");
                string lineNumber = Console.ReadLine();
                int selectedLine = GetLineIndex(lineNumber);
                Console.Write(Environment.NewLine + "Position en colonne (1, 2, 3, ...) :");
                int selectedColumn = new int();
                string columnNumber = Console.ReadLine();
                int.TryParse(columnNumber, out selectedColumn);
                Console.Write(Environment.NewLine + "Rentrer la direction du navire (left, right, up, down) :");
                string direction = Console.ReadLine();

                if (selectedLine < 0 || selectedLine > 9 || selectedColumn < 1 || selectedColumn > 10)
                {
                    Console.WriteLine("ERROR: You have selected an outrange line or column index...");
                }
                else{
                    switch (selectedShip)
                    {
                        case 0:
                            if (carrier == 1)
                            {
                                Console.WriteLine("\nError: You have selected a ship that has already been laid!");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                            switch (direction)
                            {
                                case "left":
                                    if (selectedColumn < 5)
                                    {
                                        Console.WriteLine("Error: Your ship is not in the range");
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        selectedColumn--;
                                        battleShipArray[selectedLine,selectedColumn] = 'c';
                                        battleShipArray[selectedLine,selectedColumn-1] = 'c';
                                        battleShipArray[selectedLine,selectedColumn-2] = 'c';
                                        battleShipArray[selectedLine,selectedColumn-3] = 'c';
                                        battleShipArray[selectedLine,selectedColumn-4] = 'c';
                                    }
                                    break;
                                case "right":
                                    if (selectedColumn > 6)
                                    {
                                        Console.WriteLine("Error: Your ship is not in the range");
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        selectedColumn--;
                                        battleShipArray[selectedLine,selectedColumn] = 'c';
                                        battleShipArray[selectedLine,selectedColumn+1] = 'c';
                                        battleShipArray[selectedLine,selectedColumn+2] = 'c';
                                        battleShipArray[selectedLine,selectedColumn+3] = 'c';
                                        battleShipArray[selectedLine,selectedColumn+4] = 'c';
                                    }
                                    break;
                                case "up":
                                    if (selectedLine < 4)
                                    {
                                        Console.WriteLine("Error: Your ship is not in the range");
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        selectedColumn--;
                                        battleShipArray[selectedLine,selectedColumn] = 'c';
                                        battleShipArray[selectedLine-1,selectedColumn] = 'c';
                                        battleShipArray[selectedLine-2,selectedColumn] = 'c';
                                        battleShipArray[selectedLine-3,selectedColumn] = 'c';
                                        battleShipArray[selectedLine-4,selectedColumn] = 'c';
                                    }
                                    break;
                                case "down":
                                    if (selectedLine > 5)
                                    {
                                        Console.WriteLine("Error: Your ship is not in the range");
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        selectedColumn--;
                                        battleShipArray[selectedLine,selectedColumn] = 'c';
                                        battleShipArray[selectedLine+1,selectedColumn] = 'c';
                                        battleShipArray[selectedLine+2,selectedColumn] = 'c';
                                        battleShipArray[selectedLine+3,selectedColumn] = 'c';
                                        battleShipArray[selectedLine+4,selectedColumn] = 'c';
                                    }
                                    break;
                            }
                            carrier++;
                            break;
                        case 1:
                            if (battleship == 1)
                            {
                                Console.WriteLine("\nError: You have selected a ship that has already been laid!");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                            switch (direction)
                            {
                                case "left":
                                    if (selectedColumn < 4)
                                    {
                                        Console.WriteLine("Error: Your ship is not in the range");
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        selectedColumn--;
                                        battleShipArray[selectedLine,selectedColumn] = 'b';
                                        battleShipArray[selectedLine,selectedColumn-1] = 'b';
                                        battleShipArray[selectedLine,selectedColumn-2] = 'b';
                                        battleShipArray[selectedLine,selectedColumn-3] = 'b';
                                    }
                                    break;
                                case "right":
                                    if (selectedColumn > 7)
                                    {
                                        Console.WriteLine("Error: Your ship is not in the range");
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        selectedColumn--;
                                        battleShipArray[selectedLine,selectedColumn] = 'b';
                                        battleShipArray[selectedLine,selectedColumn+1] = 'b';
                                        battleShipArray[selectedLine,selectedColumn+2] = 'b';
                                        battleShipArray[selectedLine,selectedColumn+3] = 'b';
                                    }
                                    break;
                                case "up":
                                    if (selectedLine < 3)
                                    {
                                        Console.WriteLine("Error: Your ship is not in the range");
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        selectedColumn--;
                                        battleShipArray[selectedLine,selectedColumn] = 'b';
                                        battleShipArray[selectedLine-1,selectedColumn] = 'b';
                                        battleShipArray[selectedLine-2,selectedColumn] = 'b';
                                        battleShipArray[selectedLine-3,selectedColumn] = 'b';
                                    }
                                    break;
                                case "down":
                                    if (selectedLine > 6)
                                    {
                                        Console.WriteLine("Error: Your ship is not in the range");
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        selectedColumn--;
                                        battleShipArray[selectedLine,selectedColumn] = 'b';
                                        battleShipArray[selectedLine+1,selectedColumn] = 'b';
                                        battleShipArray[selectedLine+2,selectedColumn] = 'b';
                                        battleShipArray[selectedLine+3,selectedColumn] = 'b';
                                    }
                                    break;
                            }
                            battleship++;
                            break;
                        case 2:
                            if (cruiser == 1)
                            {
                                Console.WriteLine("\nError: You have selected a ship that has already been laid!");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                            switch (direction)
                            {
                                case "left":
                                    if (selectedColumn < 3)
                                    {
                                        Console.WriteLine("Error: Your ship is not in the range");
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        selectedColumn--;
                                        battleShipArray[selectedLine,selectedColumn] = 'k';
                                        battleShipArray[selectedLine,selectedColumn-1] = 'k';
                                        battleShipArray[selectedLine,selectedColumn-2] = 'k';
                                    }
                                    break;
                                case "right":
                                    if (selectedColumn > 8)
                                    {
                                        Console.WriteLine("Error: Your ship is not in the range");
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        selectedColumn--;
                                        battleShipArray[selectedLine,selectedColumn] = 'k';
                                        battleShipArray[selectedLine,selectedColumn+1] = 'k';
                                        battleShipArray[selectedLine,selectedColumn+2] = 'k';
                                    }
                                    break;
                                case "up":
                                    if (selectedLine < 2)
                                    {
                                        Console.WriteLine("Error: Your ship is not in the range");
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        selectedColumn--;
                                        battleShipArray[selectedLine,selectedColumn] = 'k';
                                        battleShipArray[selectedLine-1,selectedColumn] = 'k';
                                        battleShipArray[selectedLine-2,selectedColumn] = 'k';
                                    }
                                    break;
                                case "down":
                                    if (selectedLine > 7)
                                    {
                                        Console.WriteLine("Error: Your ship is not in the range");
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        selectedColumn--;
                                        battleShipArray[selectedLine,selectedColumn] = 'k';
                                        battleShipArray[selectedLine+1,selectedColumn] = 'k';
                                        battleShipArray[selectedLine+2,selectedColumn] = 'k';
                                    }
                                    break;
                            }
                            cruiser++;
                            break;
                        case 3:
                            if (submarine == 1)
                            {
                                Console.WriteLine("\nError: You have selected a ship that has already been laid!");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                            switch (direction)
                            {
                                case "left":
                                    if (selectedColumn < 3)
                                    {
                                        Console.WriteLine("Error: Your ship is not in the range");
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        selectedColumn--;
                                        battleShipArray[selectedLine,selectedColumn] = 's';
                                        battleShipArray[selectedLine,selectedColumn-1] = 's';
                                        battleShipArray[selectedLine,selectedColumn-2] = 's';
                                    }
                                    break;
                                case "right":
                                    if (selectedColumn > 8)
                                    {
                                        Console.WriteLine("Error: Your ship is not in the range");
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        selectedColumn--;
                                        battleShipArray[selectedLine,selectedColumn] = 's';
                                        battleShipArray[selectedLine,selectedColumn+1] = 's';
                                        battleShipArray[selectedLine,selectedColumn+2] = 's';
                                    }
                                    break;
                                case "up":
                                    if (selectedLine < 2)
                                    {
                                        Console.WriteLine("Error: Your ship is not in the range");
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        selectedColumn--;
                                        battleShipArray[selectedLine,selectedColumn] = 's';
                                        battleShipArray[selectedLine-1,selectedColumn] = 's';
                                        battleShipArray[selectedLine-2,selectedColumn] = 's';
                                    }
                                    break;
                                case "down":
                                    if (selectedLine > 7)
                                    {
                                        Console.WriteLine("Error: Your ship is not in the range");
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        selectedColumn--;
                                        battleShipArray[selectedLine,selectedColumn] = 's';
                                        battleShipArray[selectedLine+1,selectedColumn] = 's';
                                        battleShipArray[selectedLine+2,selectedColumn] = 's';
                                    }
                                    break;
                            }
                            submarine++;
                            break;
                        case 4:
                            if (destroyer == 1)
                            {
                                Console.WriteLine("\nError: You have selected a ship that has already been laid!");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                            switch (direction)
                            {
                                case "left":
                                    if (selectedColumn < 2)
                                    {
                                        Console.WriteLine("Error: Your ship is not in the range");
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        selectedColumn--;
                                        battleShipArray[selectedLine,selectedColumn] = 'd';
                                        battleShipArray[selectedLine,selectedColumn-1] = 'd';
                                    }
                                    break;
                                case "right":
                                    if (selectedColumn > 9)
                                    {
                                        Console.WriteLine("Error: Your ship is not in the range");
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        selectedColumn--;
                                        battleShipArray[selectedLine,selectedColumn] = 'd';
                                        battleShipArray[selectedLine,selectedColumn+1] = 'd';
                                    }
                                    break;
                                case "up":
                                    if (selectedLine < 1)
                                    {
                                        Console.WriteLine("Error: Your ship is not in the range");
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        selectedColumn--;
                                        battleShipArray[selectedLine,selectedColumn] = 'd';
                                        battleShipArray[selectedLine-1,selectedColumn] = 'd';
                                    }
                                    break;
                                case "down":
                                    if (selectedLine > 8)
                                    {
                                        Console.WriteLine("Error: Your ship is not in the range");
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        selectedColumn--;
                                        battleShipArray[selectedLine,selectedColumn] = 'd';
                                        battleShipArray[selectedLine+1,selectedColumn] = 'd';
                                    }
                                    break;
                            }
                            destroyer++;
                            break;
                    }
                }
                
                Console.Clear();
                Console.WriteLine("Voici le tableau :");
                DisplayedScreen(battleShipArray);
                Console.Write(Environment.NewLine + "Appuyer sur entrer pour continuer à enregister la position de vos navires");
                Console.ReadLine();
                Console.Clear();

                if (carrier == 1 && battleship == 1 && cruiser == 1 && submarine == 1 && destroyer == 1)
                {
                    over = true;
                }
            }
            return battleShipArray;
        }

        static char[,] ComputerInit()
        {
            bool over = false;
            char[,] battleShipArray = Init();
            Random rd = new Random();

            while (!over)
            {
                int direction = rd.Next(4);
                int selectedLine = rd.Next(0,10);
                int selectedColumn = rd.Next(1,11);

                if (battleShipArray[selectedLine,selectedColumn-1] == '~')
                {
                    switch (direction)
                    {
                        case 0:
                            if (selectedColumn < 5)
                            {
                                break;
                            }
                            else
                            {
                                selectedColumn--;
                                battleShipArray[selectedLine,selectedColumn] = 'c';
                                battleShipArray[selectedLine,selectedColumn-1] = 'c';
                                battleShipArray[selectedLine,selectedColumn-2] = 'c';
                                battleShipArray[selectedLine,selectedColumn-3] = 'c';
                                battleShipArray[selectedLine,selectedColumn-4] = 'c';
                                over = true;
                            }
                            break;
                        case 1:
                            if (selectedColumn > 6)
                            {
                                break;
                            }
                            else
                            {
                                selectedColumn--;
                                battleShipArray[selectedLine,selectedColumn] = 'c';
                                battleShipArray[selectedLine,selectedColumn+1] = 'c';
                                battleShipArray[selectedLine,selectedColumn+2] = 'c';
                                battleShipArray[selectedLine,selectedColumn+3] = 'c';
                                battleShipArray[selectedLine,selectedColumn+4] = 'c';
                                over = true;
                            }
                            break;
                        case 2:
                            if (selectedLine < 4)
                            {
                                break;
                            }
                            else
                            {
                                selectedColumn--;
                                battleShipArray[selectedLine,selectedColumn] = 'c';
                                battleShipArray[selectedLine-1,selectedColumn] = 'c';
                                battleShipArray[selectedLine-2,selectedColumn] = 'c';
                                battleShipArray[selectedLine-3,selectedColumn] = 'c';
                                battleShipArray[selectedLine-4,selectedColumn] = 'c';
                                over = true;
                            }
                            break;
                        case 3:
                            if (selectedLine > 5)
                            {
                                break;
                            }
                            else
                            {
                                selectedColumn--;
                                battleShipArray[selectedLine,selectedColumn] = 'c';
                                battleShipArray[selectedLine+1,selectedColumn] = 'c';
                                battleShipArray[selectedLine+2,selectedColumn] = 'c';
                                battleShipArray[selectedLine+3,selectedColumn] = 'c';
                                battleShipArray[selectedLine+4,selectedColumn] = 'c';
                                over = true;
                            }
                            break;
                    }
                }
            }
            over = false;
            while (!over)
            {
                int direction = rd.Next(4);
                int selectedLine = rd.Next(0,10);
                int selectedColumn = rd.Next(1,11);

                if (battleShipArray[selectedLine,selectedColumn-1] == '~')
                {
                    switch (direction)
                {
                    case 0:
                        if (selectedColumn < 4)
                        {
                            break;
                        }
                        else
                        {
                            selectedColumn--;
                            battleShipArray[selectedLine,selectedColumn] = 'b';
                            battleShipArray[selectedLine,selectedColumn-1] = 'b';
                            battleShipArray[selectedLine,selectedColumn-2] = 'b';
                            battleShipArray[selectedLine,selectedColumn-3] = 'b';
                            over = true;
                        }
                        break;
                    case 1:
                        if (selectedColumn > 7)
                        {
                            break;
                        }
                        else
                        {
                            selectedColumn--;
                            battleShipArray[selectedLine,selectedColumn] = 'b';
                            battleShipArray[selectedLine,selectedColumn+1] = 'b';
                            battleShipArray[selectedLine,selectedColumn+2] = 'b';
                            battleShipArray[selectedLine,selectedColumn+3] = 'b';
                            over = true;
                        }
                        break;
                    case 2:
                        if (selectedLine < 3)
                        {
                            break;
                        }
                        else
                        {
                            selectedColumn--;
                            battleShipArray[selectedLine,selectedColumn] = 'b';
                            battleShipArray[selectedLine-1,selectedColumn] = 'b';
                            battleShipArray[selectedLine-2,selectedColumn] = 'b';
                            battleShipArray[selectedLine-3,selectedColumn] = 'b';
                            over = true;
                        }
                        break;
                    case 3:
                        if (selectedLine > 6)
                        {
                            break;
                        }
                        else
                        {
                            selectedColumn--;
                            battleShipArray[selectedLine,selectedColumn] = 'b';
                            battleShipArray[selectedLine+1,selectedColumn] = 'b';
                            battleShipArray[selectedLine+2,selectedColumn] = 'b';
                            battleShipArray[selectedLine+3,selectedColumn] = 'b';
                            over = true;
                        }
                        break;
                }             
                }
            }
            over = false;
            while (!over)
            {
                int direction = rd.Next(4);
                int selectedLine = rd.Next(0,10);
                int selectedColumn = rd.Next(1,11);

                if (battleShipArray[selectedLine,selectedColumn-1] == '~')
                {
                    switch (direction)
                    {
                        case 0:
                            if (selectedColumn < 3)
                            {
                                break;
                            }
                            else
                            {
                                selectedColumn--;
                                battleShipArray[selectedLine,selectedColumn] = 'k';
                                battleShipArray[selectedLine,selectedColumn-1] = 'k';
                                battleShipArray[selectedLine,selectedColumn-2] = 'k';
                                over = true;
                            }
                            break;
                        case 1:
                            if (selectedColumn > 8)
                            {
                                break;
                            }
                            else
                            {
                                selectedColumn--;
                                battleShipArray[selectedLine,selectedColumn] = 'k';
                                battleShipArray[selectedLine,selectedColumn+1] = 'k';
                                battleShipArray[selectedLine,selectedColumn+2] = 'k';
                                over = true;
                            }
                            break;
                        case 2:
                            if (selectedLine < 2)
                            {
                                break;
                            }
                            else
                            {
                                selectedColumn--;
                                battleShipArray[selectedLine,selectedColumn] = 'k';
                                battleShipArray[selectedLine-1,selectedColumn] = 'k';
                                battleShipArray[selectedLine-2,selectedColumn] = 'k';
                                over = true;
                            }
                            break;
                        case 3:
                            if (selectedLine > 7)
                            {
                                break;
                            }
                            else
                            {
                                selectedColumn--;
                                battleShipArray[selectedLine,selectedColumn] = 'k';
                                battleShipArray[selectedLine+1,selectedColumn] = 'k';
                                battleShipArray[selectedLine+2,selectedColumn] = 'k';
                                over = true;
                            }
                            break;
                    }          
                }
            }
            over = false;
            while (!over)
            {
                int direction = rd.Next(4);
                int selectedLine = rd.Next(0,10);
                int selectedColumn = rd.Next(1,11);

                if (battleShipArray[selectedLine,selectedColumn-1] == '~')
                {
                    switch (direction)
                    {
                        case 0:
                            if (selectedColumn < 3)
                            {
                                break;
                            }
                            else
                            {
                                selectedColumn--;
                                battleShipArray[selectedLine,selectedColumn] = 's';
                                battleShipArray[selectedLine,selectedColumn-1] = 's';
                                battleShipArray[selectedLine,selectedColumn-2] = 's';
                                over = true;
                            }
                            break;
                        case 1:
                            if (selectedColumn > 8)
                            {
                                break;
                            }
                            else
                            {
                                selectedColumn--;
                                battleShipArray[selectedLine,selectedColumn] = 's';
                                battleShipArray[selectedLine,selectedColumn+1] = 's';
                                battleShipArray[selectedLine,selectedColumn+2] = 's';
                                over = true;
                            }
                            break;
                        case 2:
                            if (selectedLine < 2)
                            {
                                break;
                            }
                            else
                            {
                                selectedColumn--;
                                battleShipArray[selectedLine,selectedColumn] = 's';
                                battleShipArray[selectedLine-1,selectedColumn] = 's';
                                battleShipArray[selectedLine-2,selectedColumn] = 's';
                                over = true;
                            }
                            break;
                        case 3:
                            if (selectedLine > 7)
                            {
                                break;
                            }
                            else
                            {
                                selectedColumn--;
                                battleShipArray[selectedLine,selectedColumn] = 's';
                                battleShipArray[selectedLine+1,selectedColumn] = 's';
                                battleShipArray[selectedLine+2,selectedColumn] = 's';
                                over = true;
                            }
                            break;
                    }
                }
            }
            over = false;
            while (!over)
            {
                int direction = rd.Next(4);
                int selectedLine = rd.Next(0,10);
                int selectedColumn = rd.Next(1,11);

                if (battleShipArray[selectedLine,selectedColumn-1] == '~')
                {
                    switch (direction)
                    {
                        case 0:
                            if (selectedColumn < 2)
                            {
                                break;
                            }
                            else
                            {
                                selectedColumn--;
                                battleShipArray[selectedLine,selectedColumn] = 'd';
                                battleShipArray[selectedLine,selectedColumn-1] = 'd';
                                over = true;
                            }
                            break;
                        case 1:
                            if (selectedColumn > 9)
                            {
                                break;
                            }
                            else
                            {
                                selectedColumn--;
                                battleShipArray[selectedLine,selectedColumn] = 'd';
                                battleShipArray[selectedLine,selectedColumn+1] = 'd';
                                over = true;
                            }
                            break;
                        case 2:
                            if (selectedLine < 1)
                            {
                                break;
                            }
                            else
                            {
                                selectedColumn--;
                                battleShipArray[selectedLine,selectedColumn] = 'd';
                                battleShipArray[selectedLine-1,selectedColumn] = 'd';
                                over = true;
                            }
                            break;
                        case 3:
                            if (selectedLine > 8)
                            {
                                break;
                            }
                            else
                            {
                                selectedColumn--;
                                battleShipArray[selectedLine,selectedColumn] = 'd';
                                battleShipArray[selectedLine+1,selectedColumn] = 'd';
                                over = true;
                            }
                            break;
                    }
                }
            }
            return battleShipArray;
        }

        static void DisplayedScreen(char[,] myArray)
        {
            int rowLength = myArray.GetLength(0);
            int colLength = myArray.GetLength(1);
            char[] letterIndexion = {'a','b','c','d','e','f','g','h','i','j'};
            string[] numberIndexion = {"1","2","3","4","5","6","7","8","9","10"};

            Console.Write(" ");
            for (int row = 0; row < rowLength; row++)
            {
                Console.Write(" {0}",numberIndexion[row]);
            }
            Console.Write(Environment.NewLine);
            for (int i = 0; i < rowLength; i++)
            {
                Console.Write("{0}", letterIndexion[i]);
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format(" {0}", myArray[i, j]));
                }
                Console.Write(Environment.NewLine);
            }
        }
    
        static void DoubleDisplayedScreen(char[,] myArray, char[,] mySecondArray)
        {
            int rowLength = myArray.GetLength(0);
            int colLength = myArray.GetLength(1);
            char[] letterIndexion = {'a','b','c','d','e','f','g','h','i','j'};
            string[] numberIndexion = {"1","2","3","4","5","6","7","8","9","10"," ","1","2","3","4","5","6","7","8","9","10"};

            Console.Write(" ");
            for (int row = 0; row < colLength*2+1; row++)
            {
                Console.Write(" {0}",numberIndexion[row]);
            }
            Console.Write(Environment.NewLine);
            for (int i = 0; i < rowLength; i++)
            {
                Console.Write("{0}", letterIndexion[i]);
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format(" {0}", myArray[i, j]));
                }
                Console.Write("  {0}", letterIndexion[i]);
                for (int k = 0; k < colLength; k++)
                {
                    
                    Console.Write(string.Format(" {0}", mySecondArray[i,k]));
                }
                Console.Write(Environment.NewLine);
            }
        }

        static int GetLineIndex(string line)
        {
            int lineIndex = new int();
            switch (line)
            {
                case "a":
                    lineIndex = 0;
                    break;
                case "b":
                    lineIndex = 1;
                    break;
                case "c":
                    lineIndex = 2;
                    break;
                case "d":
                    lineIndex = 3;
                    break;
                case "e":
                    lineIndex = 4;
                    break;
                case "f":
                    lineIndex = 5;
                    break;
                case "g":
                    lineIndex = 6;
                    break;
                case "h":
                    lineIndex = 7;
                    break;
                case "i":
                    lineIndex = 8;
                    break;
                case "j":
                    lineIndex = 9;
                    break;
            }
            return lineIndex;
        }
    
        static (char[,], bool) fire(char[,] myArray, char[,] theOtherArray, string line, int column)
        {   
            int selectedLine = GetLineIndex(line);
            int selectedColumn = column-1;
            bool hit = false;

            if (myArray[selectedLine,selectedColumn] != '~' && myArray[selectedLine,selectedColumn] != 'x')
            {
                theOtherArray[selectedLine,selectedColumn] = 'x';
                hit = true;
                Console.WriteLine("Touché!");
                Thread.Sleep(800);
            }
            else if (myArray[selectedLine,selectedColumn] == 'x')
            {
                Console.WriteLine("You already shoot on this case... Bad move...");
                Thread.Sleep(1200);
            }
            else
            {
                theOtherArray[selectedLine,selectedColumn] = '-';
                Console.WriteLine("Flop, in the water...");
                Thread.Sleep(800);
            }
            Console.Clear();
            return (theOtherArray, hit);
        }

        static (char[,], bool) AiFire(char[,] myArray, char[,] theOtherArray, string line, int column)
        {   
            int selectedLine = GetLineIndex(line);
            int selectedColumn = column-1;
            bool hit = false;

            if (myArray[selectedLine,selectedColumn] != '~' && myArray[selectedLine,selectedColumn] != 'x' && myArray[selectedLine,selectedColumn] != '-')
            {
                theOtherArray[selectedLine,selectedColumn] = 'x';
                hit = true;
            }
            else
            {
                theOtherArray[selectedLine,selectedColumn] = '-';
            }
            return (theOtherArray, hit);
        }
    
        static void PlayerVsPlayer()
        {
            Console.WriteLine("Welcome in the player vs Ai mode, good luck...\n");
            Console.WriteLine("Player 1 will initialize its ship grid...\nPress enter to continue");
            Console.ReadLine();
            char[,] player1 = PlayerInit(); //The player1's grid
            Console.WriteLine("Player 1 have finish to complete its grid...\n\nIt's the turn to the Player 2");
            Thread.Sleep(1200);
            Console.Clear();
            Console.WriteLine("Player 2 will initialize its ship grid...\nPress enter to continue");
            Console.ReadLine();
            char[,] player2 = PlayerInit(); //The player2's grid
            Console.WriteLine("Player 2 have finish to complete its grid...");
            Thread.Sleep(1200);
            Console.Clear();

            string line;
            int column = new int();

            char[,] player1TryArray = Init();   //The player1's tries
            char[,] player2TryArray = Init();   //The player2's tries

            bool hit = false;

            int player1ShipDestroyed = 0;
            int player2ShipDestroyed = 0;
            while (player1ShipDestroyed != 17 || player2ShipDestroyed != 17)
            {
                Console.WriteLine("Be sure that you don't know the grid of your ennemy... It will be not very fair-play from you...");
                Console.WriteLine("Press enter to start the round...");
                Console.ReadLine();
                Console.Clear();

                Console.WriteLine("The next array is the grid of Player 1 and the actual try of shoot from the Player 1 to Player 2");
                DoubleDisplayedScreen(player1,player1TryArray);
                Console.WriteLine("\nPlease enter the line and column to shoot : \nLine : ");
                line = Console.ReadLine();
                column = new int();
                Console.WriteLine("Column : ");
                int.TryParse(Console.ReadLine(), out column);
                (player1TryArray, hit) = fire(player2, player1TryArray, line, column);
                if (hit == true) {player2ShipDestroyed++;}
                Console.Clear();
                Console.WriteLine("There is the new array of battleship");
                DoubleDisplayedScreen(player1,player1TryArray);
                Console.WriteLine("\nPress enter to continue and let player 2 playing...");
                Console.ReadLine();
                Console.Clear();

                Console.WriteLine("The next array is the grid of Player 2 and the actual try of shoot from the Player 2 to Player 1");
                DoubleDisplayedScreen(player2,player2TryArray);
                Console.WriteLine("\nPlease enter the line and column to shoot : \nLine : ");
                line = Console.ReadLine();
                column = new int();
                Console.WriteLine("Column : ");
                int.TryParse(Console.ReadLine(), out column);
                (player1TryArray, hit) = fire(player1, player2TryArray, line, column);
                if (hit == true) {player1ShipDestroyed++;}
                Console.Clear();
                Console.WriteLine("There is the new array of battleship");
                DoubleDisplayedScreen(player2,player2TryArray);
                Console.WriteLine("\nPress enter to continue and let player 1 playing...");
                Console.ReadLine();
                Console.Clear();
            }
            if (player1ShipDestroyed == 17)
            {
                Console.WriteLine("Player 2 win!");
            }
            else if (player2ShipDestroyed == 17)
            {
                Console.WriteLine("Player 1 win!");
            }
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
            Console.Clear();
        }
    
        static void PlayerVsAI()
        {
            int playerShipDestroyed = 0;
            int aiShipDestroyed = 0;
            int[] alreadyNumberOut = new int[0];
            char[,] ai = ComputerInit();
            char[,] aiTryArray = Init();
            char[,] playerTryArray = Init();
            bool hit = false;

            Console.WriteLine("Welcome in the player vs Ai mode, good luck...\n");

            string line = "";
            int column = new int();
            char[,] player = PlayerInit();

            while (playerShipDestroyed != 17 || aiShipDestroyed != 17)
            {
                Console.WriteLine("Please enter the line and the column");
                DoubleDisplayedScreen(player, playerTryArray);
                Console.WriteLine("Line : ");
                line = Console.ReadLine();
                Console.WriteLine("Column : ");
                int.TryParse(Console.ReadLine(), out column);
                (playerTryArray, hit) = fire(ai,playerTryArray,line,column);
                DoubleDisplayedScreen(player,playerTryArray);
                Console.WriteLine("\nPress Enter to continue");
                Console.ReadLine();
                Console.Clear();
                if (hit) {aiShipDestroyed++; hit = false;}
                (line, column, alreadyNumberOut) = getAIFireCoordinate(alreadyNumberOut);
                (aiTryArray, hit) = AiFire(player,aiTryArray,line,column);
                if (hit) {playerShipDestroyed++; hit = false;}
            }
            if (playerShipDestroyed == 17) {Console.WriteLine("You have lose...");}
            else if (aiShipDestroyed == 17) {Console.WriteLine("You have win!");}
            Console.WriteLine("\nPress enter to continue");
            Console.ReadLine();
            Console.Clear();
        }

        static (string, int, int[]) getAIFireCoordinate(int[] alreadyNumberOut)
        {
            string line = "";
            int column = new int();

            Random aiRd = new Random();
            bool over = false;
            
            int theAiCase = aiRd.Next(1,101);
            while (!over)
            {
                if (!IsItIn(alreadyNumberOut, theAiCase))
                {
                    (line, column) = GetCoordinate(theAiCase);
                    alreadyNumberOut = AddElementToArray(alreadyNumberOut, theAiCase);
                    over = true;
                }
                else
                {
                    theAiCase = aiRd.Next(1,101);
                }
            }
            return (line, column, alreadyNumberOut);
        }

        public static int[] AddElementToArray(int[] array, int element)
        {
            int[] newArray = new int[array.Length+1];
            int i;
            for (i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }
            newArray[i] = element;
            return newArray;
        }
    
        public static bool IsItIn(int[] array, int element)
        {
            bool state = false;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == element)
                {
                    state = true;
                    break;
                }
            }
            return state;
        }
    
        static (string, int) GetCoordinate(int number)
        {
            string line = "";
            int column = new int();

            if (number <= 10) {line = "a";}
            else if ( 10 < number && number <= 20 ) {line = "b";}
            else if ( 20 < number && number <= 30 ) {line = "c";}
            else if ( 30 < number && number <= 40 ) {line = "d";}
            else if ( 40 < number && number <= 50 ) {line = "e";}
            else if ( 50 < number && number <= 60 ) {line = "f";}
            else if ( 60 < number && number <= 70 ) {line = "g";}
            else if ( 70 < number && number <= 80 ) {line = "h";}
            else if ( 80 < number && number <= 90 ) {line = "i";}
            else if ( 90 < number && number <= 100 ) {line = "j";}

            if (number%10 == 1) {column = 1;}
            else if (number%10 == 2) {column = 2;}
            else if (number%10 == 3) {column = 3;}
            else if (number%10 == 4) {column = 4;}
            else if (number%10 == 5) {column = 5;}
            else if (number%10 == 6) {column = 6;}
            else if (number%10 == 7) {column = 7;}
            else if (number%10 == 8) {column = 8;}
            else if (number%10 == 9) {column = 9;}
            else if (number%10 == 0) {column = 10;}

            return (line, column);
        }
    }
}
