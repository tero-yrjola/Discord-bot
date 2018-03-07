using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;

public class NoArgs : ModuleBase
{
    [Command("say"), Summary("Echoes a message.")]
    public async Task Say([Remainder, Summary("The text to echo")] string echo)
    {
        await ReplyAsync(echo);
    }

}

[Group("rps")]
[Alias("ksp", "kps")]
public class RpsModule : ModuleBase
{
    private string winLoseTie = "";
    [Command("rock")]
    [Alias("kivi", "k", "r")]
    public async Task RpsRock()
    {
        
        await ReplyAsync(RPS.Play(0));
    }

    [Command("paper")]
    [Alias("paperi", "p")]
    public async Task RpsPaper()
    {
        await ReplyAsync(RPS.Play(1));
    }

    [Command("scissors")]
    [Alias("scissors", "sakset", "s")]
    public async Task RpsScissors()
    {
        await ReplyAsync(RPS.Play(2));
    }
}