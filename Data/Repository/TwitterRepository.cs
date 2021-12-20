using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using twitterAPI.Models;

namespace twitterAPI.Data
{
    public class TwitterRepository : Irepository
    {

        private TwitterDbContext _dbContext;


        public TwitterRepository()
        {
            _dbContext = new TwitterDbContext();
        }

        public void AddTweet(Tweet tweet)
        {
            using (var db = _dbContext)
            {
                db.Tweets.Add(tweet);
                db.SaveChanges();
            }
        }

        public void AddUser(User user)
        {
            using (var db = _dbContext)
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public List<Tweet> GetAllTweets()
        {
            using(var db = _dbContext)
            {
                return db.Tweets.ToList();
            }
        }

        public Tweet GetTweetById(int id)
        {
            using(var db = _dbContext)
            {
                Tweet t = db.Tweets.FirstOrDefault(x => x.Id == id);

                return t;
            }

        }

        public List<User> GetUser()
        {
            using(var db = _dbContext)
            {
                return db.Users.Include(t => t.Tweets).ToList();
            }
        }

        public User GetUserById(int id)
        {
            using (var db = _dbContext)
            {
                return db.Users.Include(t => t.Tweets).FirstOrDefault(x => x.Id == id);
            }
        }

        public Tweet UpdateTweet(int id, Tweet tweet)
        {
            Tweet tweetToUpdate;

            using(var db = _dbContext)
            {
                tweetToUpdate = db.Tweets.FirstOrDefault(t => t.Id == id);

                if (tweetToUpdate == null)
                {
                    return null;
                }

                tweetToUpdate.Content = tweet.Content;
                tweetToUpdate.User = tweet.User;
               
                db.SaveChanges();

                return tweetToUpdate;
            }
        }

        public User UpdateUser(int id, User user)
        {
            User userToUpdate;

            using (var db = _dbContext)
            {
                userToUpdate = db.Users.FirstOrDefault(u => u.Id == id);

                if(userToUpdate == null)
                {
                    return null;
                }

                userToUpdate.UserName = user.UserName;

                db.SaveChanges();
                return userToUpdate;
            }
        }
    }
}
