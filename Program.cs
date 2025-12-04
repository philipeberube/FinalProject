

//hello this is our final project

Player[] listOfPlayers = new Player[50];
int numOfPlayers = 0;

const string psswd = "2025";
bool exit = false;
int choice = 0;
Player player1 = new Player
{
    Id = "P001",
    Name = "Alice",
    NumOfHangmanGamesPlayed = 5,
    NumOfTicTacToeGamesPlayed = 3,
    HangmanScore = 80,
    TicTacToeScore = 50,
    AvgScore = 65.0f,
    IsSuspended = false
};
do
{
    Console.WriteLine("Welcome to B&B Games would you like to enter\n1- admin menu\n2- the player menu\n3- exit");
    choice = Convert.ToInt32(Console.ReadLine());

    switch (choice) 
    {
        case 1:
            // Admin menu
            Console.WriteLine ("Welcome to the admin menu");
            AdminMenu();
            break;
        case 2:
            // Player menu
            Console.WriteLine("Welcome to the player menu");

            DisplayT3Board();
            break;
        case 3:
            // Exit
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

string GetPlayerID (string Id)
{
    for (int i = 0; i < listOfPlayers.Length; i++)
    {
        if (listOfPlayers[i].Id == Id)
        {
            return $"{i}";
        }
    }
    return "-1";
}

void PrintPlayerProfile (int index)
{
    Console.WriteLine($"Player ID:{listOfPlayers[index].Id}\nName:{listOfPlayers[index].Name}\n" +
                                    $"Number of Hangman Games Played: {listOfPlayers[index].NumOfHangmanGamesPlayed}\n" +
                                    $"Number of Tic Tac Toe Games Played: {listOfPlayers[index].NumOfTicTacToeGamesPlayed}\n" +
                                    $"Hangman Score: {listOfPlayers[index].HangmanScore}\n" +
                                    $"Tic Tac Toe Score: {listOfPlayers[index].TicTacToeScore}\n" +
                                    $"Average Score: {listOfPlayers[index].AvgScore}\n" +
                                    $"Is Suspended: {listOfPlayers[index].IsSuspended}\n");
}

void AdminMenu()
{
    bool accessGranted = false;
    for (int i = 0; i < 3;)
    {
        Console.WriteLine("Please enter the admin password:");
        string inputPsswd = Console.ReadLine();
        if (inputPsswd == psswd)
        {
            accessGranted = true;
            break;
        }
        else
        {
            Console.WriteLine("Access has been denied!");
            i++;
        }
    }

    if(accessGranted == false)
    {
        Console.WriteLine("Too many incorrect attempts, returning to main menu.");
        return;
    }

    Console.WriteLine("You have been logged in to the admin menu");
    // Admin menu functionality goes here
    Console.WriteLine("what would you like to do\n1- View a profile\n2- Display all profiles" +
        "\n3- Run stats\n4- Un/Suspend player\n5- Return to Main Menu");

    int menuChoice = Convert.ToInt32(Console.ReadLine());

    switch (menuChoice)
    {
        case 1:
            // View a profile
            Console.WriteLine("Enter player ID to view profile:");
            string tempID = Console.ReadLine();
            GetPlayerID(tempID);
            if (GetPlayerID(tempID).Equals("-1"))
            {
                Console.WriteLine("Player ID not found.");
            }
            else
            {
                Console.WriteLine("Player ID found.");
                // Display player profile details here
                int id = Convert.ToInt32(GetPlayerID(tempID));

                PrintPlayerProfile(id);
            }

            break;
        case 2:
            // Display all profiles
            for (int j = 0; j < listOfPlayers.Length; j++)
            {
                PrintPlayerProfile(j);
            }
            break;
        case 3:
            // Run stats
            HangmanHighScore(listOfPlayers);
            
            TicTacToeHighScore(listOfPlayers);
            
            HighestAverageScore(listOfPlayers);
            break;
        case 4:
            // Un/Suspend player
            break;
        case 5:
            // Return to Main Menu
            break;
    }
}

void HangmanHighScore(Player[] listOfPlayers)
{
    int highScore = listOfPlayers[0].HangmanScore;
    int index=0;
    for (int i = 0; i < numOfPlayers; i++)
    {
        if (listOfPlayers[i].HangmanScore > highScore)
        {
            highScore = listOfPlayers[i].HangmanScore;
            index = i;
        }   
    }
    Console.WriteLine($"The highest Hangman score is: {highScore}");
    Console.WriteLine($"It is found at index {index}");
}
 
void TicTacToeHighScore(Player[] listOfPlayers)
{
    int highScore = listOfPlayers[0].TicTacToeScore;
    int index = 0;
    for (int i = 0; i < numOfPlayers; i++)
    {
        if (listOfPlayers[i].TicTacToeScore > highScore)
        {
            highScore = listOfPlayers[i].TicTacToeScore;
            index = i;
        }
    }
    Console.WriteLine($"The highest Tic Tac Toe score is: {highScore}");
    Console.WriteLine($"It is found at index {index}");
}

void HighestAverageScore(Player[] listOfPlayers)
{
    float highAvgScore = listOfPlayers[0].AvgScore;
    int index = 0;
    for (int i = 0; i < numOfPlayers; i++)
    {
        if (listOfPlayers[i].AvgScore > highAvgScore)
        {
            highAvgScore = listOfPlayers[i].AvgScore;
            index = i;
        }
    }
    Console.WriteLine($"The highest Average score is: {highAvgScore}");
    Console.WriteLine($"It is found at index {index}");
}

void DisplayT3Board()
{
    char temp = '1';
    // Tic Tac Toe game logic goes here
    char[,] ticTacToeBoard = new char[3, 3];
    char currentPlayer = 'X';
    Console.WriteLine("Starting Tic Tac Toe...");
    Console.WriteLine("setting up a new board...\n");
    
        
    for (int rows = 0; rows < ticTacToeBoard.GetLength(0); rows++)
    {
        for (int collums = 0; collums < ticTacToeBoard.GetLength(1); collums++)
        {
            ticTacToeBoard[rows, collums] = temp++;
            Console.Write(ticTacToeBoard[rows, collums]);

        }
        Console.WriteLine("");

    }

    Console.WriteLine();

    Console.WriteLine("Hello player 1 please enter your name:");
    string player0Name = Console.ReadLine();
    Console.WriteLine("Hello player 2 please enter your name:");
    string player1Name = Console.ReadLine();

    for (int currentplayer = 0; currentplayer < 3; currentplayer++)
    {   
        currentplayer = currentplayer % 2;
        if (currentplayer == 0) { currentPlayer = 'X'; }
        else currentPlayer = 'O';

        Console.WriteLine($"It is {currentPlayer}'s turn");
        Console.WriteLine("PLease enter the row followed by the collum you want to place your peace in (0-2)");
        int r = Convert.ToInt32(Console.ReadLine());
        int c = Convert.ToInt32(Console.ReadLine());
        for (int rows = 0; rows < ticTacToeBoard.GetLength(0); rows++)
        {
            for (int collums = 0; collums < ticTacToeBoard.GetLength(1); collums++)
            {
                
                Console.Write(ticTacToeBoard[rows, collums]);

            }
            Console.WriteLine("");

        }



        IsWinner(ticTacToeBoard);
        
    }
}

bool IsWinner(char[,] board)
{
    if (board[0, 0] == board[0, 1] && board[0, 1] == board[0, 2] || board[1, 0] == board[1, 1] && board[1, 1] == board[1, 2] 
        || board[2, 0] == board[2, 1] && board[2, 1] == board[2, 2] || board[0, 0] == board[1, 0] && board[1, 0] == board[2, 0] 
        || board[1, 0] == board[1, 1] && board[1, 1] == board[2, 1] || board[2, 0] == board[1, 2] && board[1, 2] == board[2, 2] 
        || board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] || board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
    {
        return true;
    }
    else
    {
        return false;
    }

}
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

