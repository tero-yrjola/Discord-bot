public static class RPS
{
    public static string Play(int playerChoice)
    {
        int myChoice = Util.Rng(2);

        switch (myChoice - playerChoice)
        {
            case  0: return $"We both chose {(Choice)playerChoice}, it's a tie!";
            case -2:
            case  1: return $"You chose {(Choice)playerChoice} but I chose {(Choice)myChoice} so I win! Ha!";
            case -1:
            case  2: return $"Darn! You chose {(Choice)playerChoice} and I chose {(Choice)myChoice} so you win.";

            default: return $"Invalid parameters {playerChoice} and {myChoice}";
        }
    }
}

enum Choice
{
    rock = 0,
    paper = 1,
    scissors = 2
}