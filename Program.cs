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
Player[] listOfPlayers = new Player[50];
int numOfPlayers = 1;
const string psswd = "2025";


while (true)
{






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

