using System;
using System.Collections;
using System.IO;
using System.Threading.Tasks;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace DiscordBot
{
    public class YouTube
    {
        public static async Task<string> FetchCommentAsync(string searchString)
        {
            var service = new YouTubeService(new BaseClientService.Initializer
            {
                ApiKey = File.ReadAllLines("token.txt")[1]
            });

            var includeVideo = searchString.Contains("-v");
            if (includeVideo) searchString = searchString.Replace("-v", "");

            var searchResponse = GetYoutubeSearchResponse(searchString, service);

            var videoId = GetRandomVideoIdFromSearchResponse(searchResponse);

            var commentResponse = GetCommentResponseFromVideoId(service, videoId);

            return GetRandomCommentFromCommentResponse(commentResponse, videoId, includeVideo);
        }

        private static CommentThreadListResponse GetCommentResponseFromVideoId(YouTubeService service, string videoId)
        {
            var commentThreadsRequest = service.CommentThreads.List("snippet");
            commentThreadsRequest.VideoId = videoId;
            commentThreadsRequest.MaxResults = 100;
            var commentResponse = commentThreadsRequest.Execute();
            return commentResponse;
        }

        private static string GetRandomCommentFromCommentResponse(CommentThreadListResponse commentResponse,string videoId, bool includeVideo)
        {
            if (commentResponse.Items.Count < 1)
                return GetReturnStringWhenVideoHasNoComments(videoId, includeVideo);

            var commentIndex = Util.Rng(commentResponse.Items.Count);
            var commentSnippet = commentResponse.Items[commentIndex].Snippet.TopLevelComment.Snippet;

            return GetReturnStringWhenVideoHasComments(videoId, includeVideo, commentSnippet);
        }

        private static string GetReturnStringWhenVideoHasComments(string videoId, bool includeVideo,
            CommentSnippet commentSnippet)
        {
            var returnString = commentSnippet.TextOriginal + "\n-" + commentSnippet.AuthorDisplayName;
            if (includeVideo) returnString += "\nhttps://www.youtube.com/watch?v=" + videoId;
            return returnString;
        }

        private static string GetReturnStringWhenVideoHasNoComments(string videoId, bool includeVideo)
        {
            if (includeVideo)
            {
                return "This video had no comments: https://www.youtube.com/watch?v=" + videoId;
            }
            return "The video had no comments!";
        }

        private static SearchListResponse GetYoutubeSearchResponse(string searchString, YouTubeService service)
        {
            var youtubeSearchRequest = service.Search.List("snippet");
            youtubeSearchRequest.Q = searchString;
            youtubeSearchRequest.MaxResults = 25;
            var searchResponse = youtubeSearchRequest.Execute();
            return searchResponse;
        }

        private static string GetRandomVideoIdFromSearchResponse(SearchListResponse searchResponse)
        {
            var videoIdList = new ArrayList();
            foreach (var searchResponseItem in searchResponse.Items)
                if (searchResponseItem.Id.Kind == "youtube#video")
                    videoIdList.Add(searchResponseItem.Id.VideoId);
            return (string)videoIdList[Util.Rng(videoIdList.Count)];

        }
    }
}
