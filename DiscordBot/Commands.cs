using System;
using System.IO;
using Discord.Commands;
using System.Threading.Tasks;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;

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
    //TODO: Fix (refactor) this long long long thing 
    [Command("ytc"), Summary("Returns a random YouTube-comment")]
    public async Task GetYoutubeComment([Remainder, Summary("Youtube-channel to search the random comment from")] string searchString)
    {
        YouTubeService service = new YouTubeService(new BaseClientService.Initializer()
        {
            ApiKey = File.ReadAllLines("token.txt")[1],
            ApplicationName = GetType().ToString()
        });

        bool includeVideo = searchString.Contains("-v");
        if (includeVideo) searchString = searchString.Replace("-v", "");
        var youtubeSearchRequest = service.Search.List("snippet");
        youtubeSearchRequest.Q = searchString;
        youtubeSearchRequest.MaxResults = 50;
        var searchResponse = youtubeSearchRequest.Execute();
        var videoId = "";
        if (searchString.Length > 2)
        {
            foreach (var searchResponseItem in searchResponse.Items)
            {
                if (searchResponseItem.Id.Kind == "youtube#video")
                {
                    videoId = searchResponseItem.Id.VideoId;
                    break;
                }
            }
        }
        else await ReplyAsync("I need longer paremeters, bro.");

        var commentThreadsRequest = service.CommentThreads.List("snippet");
        commentThreadsRequest.VideoId = videoId;
        commentThreadsRequest.MaxResults = 100;
        var commentResponse = commentThreadsRequest.Execute();
        if (commentResponse.Items.Count < 1)
            if (includeVideo)
                await ReplyAsync("This video had no comments: https://www.youtube.com/watch?v=" + videoId);
            else
                await ReplyAsync("The video had no comments!");
                var commentIndex = Util.Rng(commentResponse.Items.Count);
        var commentSnippet = commentResponse.Items[commentIndex].Snippet.TopLevelComment.Snippet;
        var returnString = commentSnippet.TextOriginal + "\n-" + commentSnippet.AuthorDisplayName;
        if (includeVideo) returnString += "\nhttps://www.youtube.com/watch?v=" + videoId;
        await ReplyAsync(returnString);
    }

    [Command("ytc"), Summary("Returns a random YouTube-comment")]
    public async Task GetYoutubeComment()
    {
        YouTubeService service = new YouTubeService(new BaseClientService.Initializer()
        {
            ApiKey = "AIzaSyAZFsp2Et_H4tu5xMEiMKL_o8OF9JxVgHs",
            ApplicationName = GetType().ToString()
        });
        var commentThreadsRequest = service.CommentThreads.List("snippet");
        commentThreadsRequest.VideoId = "wQadGczDj9E";
        commentThreadsRequest.MaxResults = 100;
        var commentResponse = commentThreadsRequest.Execute();
        var commentIndex = Util.Rng(commentResponse.Items.Count);
        var topCommentSnippet = commentResponse.Items[commentIndex].Snippet.TopLevelComment.Snippet;
        await ReplyAsync(topCommentSnippet.TextOriginal + "\n-" + topCommentSnippet.AuthorDisplayName
            + "\nhttps://www.youtube.com/watch?v=" + topCommentSnippet.VideoId);
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