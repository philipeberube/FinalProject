/*
 * A struct Player with the following fields: Id, Name, NumOfHangmanGamesPlayed,
NumOfTicTacToeGamesPlayed, TotalNumOfGamesPlayed, HangmanScore, TictactoeScore, AvgScore,
IsSuspended.
2. An array listOfPlayers that will hold up to 50 player profiles. // syntax : Player[] = new Player[50];
3. A numOfPlayers variable that keeps track of the total profiles saved in the array.
4. A forever loop that will allow the program to keep running, optional exit and lose all saved profiles
5. A welcome message to the user and a prompt: admin menu, player menu, or Exit? Validate.
a. For the admin menu, a password needs to be entered. It must match a const psswd 5555
*/

//hello this is our final project
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Intrinsics.X86;
using static System.Runtime.InteropServices.JavaScript.JSType;

Player[] listOfPlayers = new Player[50];
int numOfPlayers = 0;

const string psswd = "2025";
bool exit = false;
int choice = 0;

do
{
    Console.WriteLine("Welcome to B&B Games would you like to enter\n1- admin menu\n2- the player menu\n3- exit");
    choice = Convert.ToInt32(Console.ReadLine());

    switch (choice) 
    {
        case 1:
            Console.WriteLine ("Welcome to the admin menu");
            for (int i = 0; i < 3;)
            {
                Console.WriteLine("Please enter the admin password:");
                string inputPsswd = Console.ReadLine();
                if (inputPsswd == psswd)
                {
                    int menuChoice = 0;
                    Console.WriteLine("You have been logged in to the admin menu");
                    // Admin menu functionality goes here
                    Console.WriteLine("what would you like to do\n1- View a profile\n2- Display all profiles" +
                        "\n3- Run stats\n4- Un/Suspend player\n5- Return to Main Menu");
                    switch (menuChoice)
                    {
                        case 1:
                            // View a profile
                            break;
                        case 2:
                            // Display all profiles
                            break;
                        case 3:
                            // Run stats
                            break;
                        case 4:
                            // Un/Suspend player
                            break;
                        case 5:
                            // Return to Main Menu
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("Access has been denied!");
                    i++;
                }
            }
            break;
        case 2:
            break;
        case 3:
            do
            {
                char exitout;
                do
                {
                    Console.WriteLine("do you want to exit the application and lose all saved files (y/n)");
                    exitout = Convert.ToChar(Console.ReadLine().ToLower());
                } while (exitout != 'y' && exitout != 'n');


                if (exitout == 'y')
                {
                    exit = true;
                }
                if (exitout == 'n')
                {
                    break;
                }

            } while (exit == false);
            break;
    }

} while(exit == false);








struct Player 
{
    public string Id;
    public string Name;
    public int NumOfHangmanGamesPlayed;
    public int NumOfTicTacToeGamesPlayed;
    public int HangmanScore;
    public int TicTacToeScore;
    public float AvgScore;
    public bool IsSuspended;
}

