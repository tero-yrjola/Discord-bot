using System;
using System.Collections;
using System.IO;
using Discord.Commands;
using System.Threading.Tasks;
using DiscordBot;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

public class NoArgs : ModuleBase
{
    [Command("say"), Summary("Echoes a message.")]
    public async Task Say([Remainder, Summary("The text to echo")] string echo)
    {
        await ReplyAsync(echo);
    }
}

public class YoutubeModule : ModuleBase
{
    [Command("ytc"), Summary("Returns a random YouTube-comment")]
    public async Task GetYoutubeComment([Remainder, Summary("Youtube-channel to search the random comment from")] string searchString)
    {
        try
        {
            await ReplyAsync(YouTube.FetchCommentAsync(searchString).Result);
        }
        catch (Exception e)
        {
            await ReplyAsync(e.InnerException?.Message ?? "Failed fetching comments!");
        }
    }
}

[Group("rps")]
[Alias("ksp", "kps")]
public class RpsModule : ModuleBase
{
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