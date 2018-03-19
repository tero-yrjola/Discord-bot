
using System;
using System.Linq;

//{0} gets replaced with "win", "loss" or "tie" from the bot's perspective
//{1} gets replaced with the players pick
//{2} gets replaced with the bots pick
public static class Resources
{
    #region shoutstrings
    private static readonly string[] neutralShoutString =
    {
        "Hmm... ",
        "Well well well... ",
        "Oh! ",
        "Would you just look at that! ",
        ""
    };

    private static readonly string[] botWinShoutString =
    {
        "Hahaa! ",
        "Yess! ",
        "Too bad! ",
        "I'm so sorry. ",
        ""
    };

    private static readonly string[] botLoseShoutString =
    {
        "Oh darn. ",
        "Shuckles! ",
        "What?! ",
        "Are you cheating? ",
        ""
    };
    #endregion
    #region RPS resources
    #region RPS information about choices-strings

    private static readonly string[] RPSNeutralChoicesString =
    {
        "You picked {1} and I picked {2}. ",
        "I chose {2} and you chose {1}. ",
        "Your choice was {1} and mine was {2}. ",
        "My choice was {2}. You chose {1}. "
    };
    #endregion
    #region RPS information about the rps-result -strings
    private static readonly string[] RPSNeutralResultsString =
    {
        "That means it's a {0}! ",
        "So yeah, it is a {0}. "
    };

    private static readonly string[] RPSBotWinResultsString =
    {
        "I WON! ",
        "You lost. :D ",
        "So I take the trophy! ",
        "Another one for me boys. ",
        "All I do is win, no matter what. ",
        "I beat you. "
    };

    private static readonly string[] RPSBotLoseResultsString =
    {
        "You won..? ", 
        "Huh, you won. ",
        "You win, gz. ",
        "I guess you won then... ",
        "You just got lucky there. ",
        "Yeah you got lucky, try it again! "
    };

    #endregion
    #endregion
    private static string GetRandomFromProp(params string[][] values)
    {
        string  returnString = "";
        foreach (string[] phrases in values)
        {
            returnString += phrases[Util.Rng(phrases.Length)];
        }
        return returnString;
    }


    public static string GetNeutralRpsPhrase()
    {
        return GetRandomFromProp(neutralShoutString, RPSNeutralChoicesString, RPSNeutralResultsString);
    }

    public static string GetBotWinRpsPhrase()
    {
        return GetRandomFromProp(botWinShoutString, RPSNeutralChoicesString, RPSBotWinResultsString);
    }

    public static string GetBotLoseRpsPhrase()
    {
        return GetRandomFromProp(botLoseShoutString, RPSNeutralChoicesString, RPSBotLoseResultsString);
    }

}

