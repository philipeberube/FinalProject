

//hello this is our final project

using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

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
            // Admin menu
            Console.WriteLine ("Welcome to the admin menu");
            AdminMenu();
            break;
        case 2:
            // Player menu
            PlayerMenu();

            break;
        case 3:
            // Exit
            do
            {
                char exitout;
                do
                {
                    Console.WriteLine("Do you want to exit the application and lose all saved files (y/n)");
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
        Console.WriteLine("\n");
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
    char leave = 'n';
    Console.WriteLine("You have been logged in to the admin menu");
    // Admin menu functionality goes here
    do 
    {
        Console.WriteLine("What would you like to do\n1- View a profile\n2- Display all profiles" +
        "\n3- Run stats\n4- Un/Suspend player\n5- Return to Main Menu");

        int menuChoice = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("\n");
    

    
        
        switch (menuChoice)
        {
            case 1:
                // View a profile
                Console.WriteLine("Enter player ID to view profile:");
                string tempID = Console.ReadLine();
                Console.WriteLine("\n");
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
                for (int j = 0; j < numOfPlayers; j++)
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

                leave = MainReturn();
                break;
        }

    } while (leave == 'n');
}
char MainReturn()
{

    char leave = 'n';
    
    do
    {

        Console.WriteLine("Do you want to return to main menu? (y/n)");
        leave = Convert.ToChar(Console.ReadLine().ToLower());

    } while (leave != 'y' && leave != 'n');
    return leave;
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
    Console.WriteLine($"The highest TicTacToe score is: {highScore}");
    Console.WriteLine($"It is found at index {index}");
}

void HighestAverageScore(Player[] listOfPlayers)
{
    float highScore = listOfPlayers[0].AvgScore;
    int index = 0;
    for (int i = 0; i < numOfPlayers; i++)
    {
        if (listOfPlayers[i].AvgScore > highScore)
        {
            highScore = listOfPlayers[i].AvgScore;
            index = i;
        }
    }
    Console.WriteLine($"The highest Average score is: {highScore}");
    Console.WriteLine($"It is found at index {index}");
}
void PlayerMenu()
{
    Console.WriteLine("Welcome to the player menu");
    Console.WriteLine("What would you like to do \n1: create account\n2: check account\n3: play tictactoe");
    int input = Convert.ToInt32(Console.ReadLine());
    switch (input)
    {
        case 1:
            CreateAccount();
            numOfPlayers++;

            break;
        case 2:
            EnterAccount();
            break;
        case 3:
            DisplayT3Board();
            break;
    }
        
}
void CreateAccount()
{
    bool doesntOverlap = false;
    string tempId;
    string tempName;
    char answr;
    do
    {
        Console.WriteLine("Please enter a new ID");
        tempId = Console.ReadLine();
        for (int i = 0; i < listOfPlayers.Length; i++)
        {
            if (tempId == listOfPlayers[i].Id)
            {
                doesntOverlap = true;
                break;
            }
        }
    }while (doesntOverlap);
    
    do
    {
        Console.WriteLine("Please enter your username");
        tempName = Console.ReadLine();
        do
        {
            Console.WriteLine("Are you sure of that name (y/n)");
            answr = Convert.ToChar(Console.ReadLine().ToLower());

        } while (answr != 'y' && answr != 'n');
    } while (answr == 'n');

    listOfPlayers[numOfPlayers].Id = tempId;
    listOfPlayers[numOfPlayers].Name = tempName;

    


}
void EnterAccount()
{
    string tempId;
    string id;
    int Id;

    for (int i = 0;i <=3 ;i++)
    {
        do
        {
            Console.WriteLine("Please enter your Id");
            tempId = Console.ReadLine();
            id = GetPlayerID(tempId);
        } while (id == "-1");
        if (id != "-1")
        {
            Id = Convert.ToInt32(GetPlayerID(tempId));
            PrintPlayerProfile(Id);
            break;
        }
        else { Console.WriteLine("Please enter a valid Id"); }
    }

    Console.WriteLine();



}
 

void DisplayT3Board()
{
    char temp = '1';
    // Tic Tac Toe game logic goes here
    char[,] ticTacToeBoard = new char[3, 3];
    for (int rows = 0; rows < ticTacToeBoard.GetLength(0); rows++)
    {
        for (int collums = 0; collums < ticTacToeBoard.GetLength(1); collums++)
        {
            ticTacToeBoard[rows, collums] = temp++;


        }
    }
    string tempId;
    char currentPlayer = 'X';
    Console.WriteLine("Starting Tic Tac Toe...");
    Console.WriteLine("Setting up a new board...\n");

    String[] player = new string[2];
    
    Console.WriteLine("Hello player 1 please enter your ID:");
    tempId = GetPlayerID(Console.ReadLine());
    player[0] = listOfPlayers[Convert.ToInt32(tempId)].Name;
        
    Console.WriteLine(player[0]);
    Console.WriteLine("Hello player 2 please enter your ID:");
    tempId = GetPlayerID(Console.ReadLine());
    player[1] = listOfPlayers[Convert.ToInt32(tempId)].Name;


    for (int currentplayer = 0; currentplayer < 3; currentplayer++)
    {
        currentplayer = currentplayer % 2;
        if (currentplayer == 0) { currentPlayer = 'X'; }
        else currentPlayer = 'O';

        for (int rows = 0; rows < ticTacToeBoard.GetLength(0); rows++)// prining board 
        {
            for (int collums = 0; collums < ticTacToeBoard.GetLength(1); collums++)
            {
                Console.Write(ticTacToeBoard[rows, collums]);

            }
            Console.WriteLine("");

        }

        Console.WriteLine();

        switch (TicTacToeInput(ticTacToeBoard))
        {
            case '1':
                SwapInBoard(ticTacToeBoard, 0, 0, currentPlayer);
                break;
            case '2':
                SwapInBoard(ticTacToeBoard, 0, 1, currentPlayer);
                break;
            case '3':
                SwapInBoard(ticTacToeBoard, 0, 2, currentPlayer);
                break;
            case '4':
                SwapInBoard(ticTacToeBoard, 1, 0, currentPlayer);
                break;
            case '5':
                SwapInBoard(ticTacToeBoard, 1, 1, currentPlayer);
                break;
            case '6':
                SwapInBoard(ticTacToeBoard, 1, 2, currentPlayer);
                break;
            case '7':
                SwapInBoard(ticTacToeBoard, 2, 0, currentPlayer);
                break;
            case '8':
                SwapInBoard(ticTacToeBoard, 2, 1, currentPlayer);
                break;
            case '9':
                SwapInBoard(ticTacToeBoard, 2, 2, currentPlayer);
                break;
        }



        if (IsWinner(ticTacToeBoard)== true)
        {  
            Console.WriteLine($"Congratulations {player[currentplayer]} you have won the game!");
            if (currentplayer == 0)
            {
                listOfPlayers[Convert.ToInt32(player[0])].TicTacToeScore += 2;
                listOfPlayers[Convert.ToInt32(player[1])].TicTacToeScore -= 0;
            }
            else if (currentplayer == 1)
            {
                listOfPlayers[Convert.ToInt32(player[1])].TicTacToeScore += 2;
                listOfPlayers[Convert.ToInt32(player[0])].TicTacToeScore -= 0;
            }
            else
            {
                listOfPlayers[Convert.ToInt32(player[0])].TicTacToeScore += 1;
                listOfPlayers[Convert.ToInt32(player[1])].TicTacToeScore += 1;
            }
            break;

        }
            


    }


        
        
    
}




char[,] SwapInBoard(char[,] board,int r,int c, char swap)
{
    board[r,c] = swap;
    return board;
}



char TicTacToeInput(char[,] board)
{
    char playerchoice;
    bool spaceTaken = true;
    do
    {
        do
        {
            Console.WriteLine("Please enter which space you want to play in");
            playerchoice = Convert.ToChar(Console.ReadLine());

        } while (playerchoice != '1' && playerchoice != '2' && playerchoice != '3' && playerchoice != '4' && playerchoice != '5' && playerchoice != '6' && playerchoice != '7' && playerchoice != '8' && playerchoice != '9');

        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[i, j] == playerchoice)
                {
                    spaceTaken = false; 
                }
            }
        }

    }while (spaceTaken);

    return playerchoice;
}

  

bool IsWinner(char[,] board)
{
    if (board[0, 0] == board[0, 1] && board[0, 1] == board[0, 2] || board[1, 0] == board[1, 1] && board[1, 1] == board[1, 2] 
        || board[2, 0] == board[2, 1] && board[2, 1] == board[2, 2] ||/*horizontal*/
        board[0, 0] == board[1, 0] && board[1, 0] == board[2, 0] || board[1, 0] == board[1, 1] && board[1, 1] == board[2, 1] 
        || board[2, 0] == board[1, 2] && board[1, 2] == board[2, 2] /*vartical*/
        || board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] || board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])//diagonal
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

