using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using twitterAPI.Models;

namespace twitterAPI.Data
{
    public interface Irepository
    {
        Task<List<Tweet>> GetAllTweetsAsync();

        Tweet GetTweetById(int id);

        List<User> GetUser();

        User GetUserById(int id);

        void AddTweet(Tweet tweet);

        void AddUser(User user);

        Tweet UpdateTweet(int id, Tweet tweet);

        User UpdateUser(int id, User user);

        List<Reply> GetReply();

        Reply GetReplyById(int id);

        void AddReply(Reply reply);

        Reply UpdateReply(int id, Reply reply);

        bool DeleteTweet(int id);

        bool DeleteReply(int id);

        bool DeleteUser(int id);

        void AddLike(Like like);

        Like GetLikeById(int id);

        List<Like> GetLike();
    }
}
