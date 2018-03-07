using System;

public static class RPS
{
    enum Choice
    {
        rock = 0,
        paper = 1,
        scissors = 2
    }


    /// <param name="playerChoice">player's choice where 0=rock, 1=paper, 2=scissors</param>
    /// <returns>string[] where 
    /// [0] is "tie","loss" or "win" from the bots perspective.
    /// [1] is players rps choice in lowercase string
    /// [2] is bots rps choice in lowercase string</returns>
    public static string Play(int playerChoice)
    {
        int myChoice = Util.Rng(2);
        string[] rpsData =
            {"",
            ((Choice)playerChoice).ToString(),
            ((Choice)myChoice).ToString()
        };

        switch (myChoice - playerChoice)
        {
            case 0:
                rpsData[0] = "tie";
                return ReturnStringGenerator(rpsData);
            case -2:
            case  1:
                rpsData[0] = "win";
                return ReturnStringGenerator(rpsData);
            case -1:
            case  2:
                rpsData[0] = "loss";
                return ReturnStringGenerator(rpsData);

            default: return $"Invalid parameters {playerChoice} and {myChoice}";
        }
    }
    /// <summary>
    /// returns a reply-string for the bot
    /// </summary>
    /// <param name="RPSResults">string[] where 
    /// [0] is "tie","loss" or "win" from the bots perspective.
    /// [1] is players rps choice in lowercase string
    /// [2] is bots rps choice in lowercase string</param>
    /// <returns>a ready text for bot to reply to rps-command</returns>
    public static string ReturnStringGenerator(string[] RPSResults)
    {
        string replyString;

        switch (RPSResults[0])
        {
            case "tie": replyString = String.Format(Resources.GetNeutralRpsPhrase(), new[] { RPSResults[0], RPSResults[1], RPSResults[2] });
                break;
            case "loss": replyString = String.Format(Resources.GetBotLoseRpsPhrase(), new[] { RPSResults[0], RPSResults[1], RPSResults[2] });
                break;
            case "win": replyString = String.Format(Resources.GetBotWinRpsPhrase(), new[] { RPSResults[0], RPSResults[1], RPSResults[2] });
                break;
            default:
                replyString = $"Something went wrong with these: {RPSResults[0]}, {RPSResults[1]}, {RPSResults[2]}";
                break;
        ;
    }
        return replyString;
    }
}