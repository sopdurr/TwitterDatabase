using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using twitterAPI.Models;

namespace twitterAPI.Data
{
    public class MockRepo : Irepository
    {

        List<Tweet> Tweets = new List<Tweet>()
         {
                new Tweet() { Id = 1, Content = "HALLO EG ÞARF AÐ DREKKA" },
                new Tweet() { Id = 2, Content = "HALLO EG ÞARF AÐ FARA I RÆKTINA"},
                new Tweet() { Id = 3, Content = "HALLO EG ÞARF AÐ BOMBA", }
         };

        List<User> User = new List<User>()
        {
            new User() { Id=1, UserName="Siggi" },
        };

        public void AddTweet(Tweet tweet)
        {
            throw new NotImplementedException();
        }

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<List<Tweet>> GetAllTweetsAsync()
        {
            return null;
        }

        public List<Reply> GetReply()
        {
            throw new NotImplementedException();
        }

        public Tweet GetTweetById(int id)
        { 
            return Tweets.FirstOrDefault(x => x.Id == id);
        }


        public List<User> GetUser()
        {
            return User;
        }

        public User GetUserById(int id)
        {
            return User.FirstOrDefault(x => x.Id == id);
        }

        public Tweet UpdateTweet(int id, Tweet tweet)
        {
            throw new NotImplementedException();
        }

        public User UpdateUser(int id, User user)
        {
            throw new NotImplementedException();
        }

        public Reply GetReplyById(int id)
        {
            throw new NotImplementedException();
        }

        public void AddReply(Reply reply)
        {
            throw new NotImplementedException();
        }

        public Reply UpdateReply(int id, Reply reply)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTweet(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteReply(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public void AddLike(Like like)
        {
            throw new NotImplementedException();
        }

        public Like GetLikeById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Like> GetLike()
        {
            throw new NotImplementedException();
        }

       
    }

}
