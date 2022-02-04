using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<List<Tweet>> GetAllTweetsAsync()
        {
            using (var db = _dbContext)
            {
                return await db.Tweets.Include(l => l.Likes).Include(r => r.Replies).ToListAsync();
            }
        }

        public Tweet GetTweetById(int id)
        {
            using (var db = _dbContext)
            {
                Tweet t = db.Tweets.Include(l => l.Likes).Include(r => r.Replies).FirstOrDefault(x => x.Id == id);

                return t;
            }

        }

        public List<User> GetUser()
        {
            using (var db = _dbContext)
            {
                return db.Users.Include(r => r.Replies).Include(t => t.Tweets).ToList();
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

            using (var db = _dbContext)
            {
                tweetToUpdate = db.Tweets.FirstOrDefault(t => t.Id == id);

                if (tweetToUpdate == null)
                {
                    return null;
                }

                tweetToUpdate.Content = tweet.Content;


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

                if (userToUpdate == null)
                {
                    return null;
                }

                userToUpdate.Tweets = user.Tweets;
                userToUpdate.Replies = user.Replies;


                db.SaveChanges();
                return userToUpdate;
            }
        }

        public void AddReply(Reply reply)
        {
            using (var db = _dbContext)
            {
                db.Replies.Add(reply);
                db.SaveChanges();
            }
        }

        public List<Reply> GetReply()
        {
            using (var db = _dbContext)
            {
                return db.Replies.Include(r => r.ReplyLikes).ToList();
            }
        }

        public Reply GetReplyById(int id)
        {
            using (var db = _dbContext)
            {
                Reply r = db.Replies.FirstOrDefault(x => x.Id == id);

                return r;
            }
        }

        public Reply UpdateReply(int id, Reply reply)
        {
            Reply replyToUpdate;

            using (var db = _dbContext)
            {
                replyToUpdate = db.Replies.FirstOrDefault(r => r.Id == id);

                if (replyToUpdate == null)
                {
                    return null;
                }

                replyToUpdate.ReplyContent = reply.ReplyContent;



                db.SaveChanges();
                return replyToUpdate;
            }
        }

        public bool DeleteTweet(int id)
        {
            Tweet tweetToDelete;

            using (var db = _dbContext)
            {
                tweetToDelete = db.Tweets.FirstOrDefault(t => t.Id == id);

                if (tweetToDelete == null)
                {
                    return false;
                }
                else
                {
                    db.Tweets.Remove(tweetToDelete);
                    db.SaveChanges();
                    return true;
                }
            }
        }

        public bool DeleteReply(int id)
        {
            Reply replyToDelete;

            using (var db = _dbContext)
            {
                replyToDelete = db.Replies.FirstOrDefault(t => t.Id == id);

                if (replyToDelete == null)
                {
                    return false;
                }
                else
                {
                    db.Replies.Remove(replyToDelete);
                    db.SaveChanges();
                    return true;
                }
            }
        }

        public bool DeleteUser(int id)
        {
            User userToDelete;

            using (var db = _dbContext)
            {
                userToDelete = db.Users.FirstOrDefault(t => t.Id == id);

                if (userToDelete == null)
                {
                    return false;
                }
                else
                {
                    db.Users.Remove(userToDelete);
                    db.SaveChanges();
                    return true;
                }
            }
        }

        public void AddLike(Like like)
        {
            using (var db = _dbContext)
            {
                db.Likes.Add(like);
                db.SaveChanges();
            }
        }

        public Like GetLikeById(int id)
        {
            using (var db = _dbContext)
            {
                Like l = db.Likes.FirstOrDefault(x => x.Id == id);

                return l;
            }
        }

        public List<Like> GetLike()
        {
            using (var db = _dbContext)
            {
                return db.Likes.ToList();

            }
        }

        public void AddReplyLike(ReplyLike replyLike)
        {
            using (var db = _dbContext)
            {
                db.ReplyLikes.Add(replyLike);
                db.SaveChanges();
            }
        }

        public ReplyLike GetReplyLikeById(int id)
        {
            using (var db = _dbContext)
            {
                ReplyLike l = db.ReplyLikes.FirstOrDefault(x => x.Id == id);

                return l;
            }
        }

        public List<ReplyLike> GetReplyLike()
        {
            using (var db = _dbContext)
            {
                return db.ReplyLikes.ToList();

            }
        }

        public bool DeleteLike(int id)
        {
            Like LikeToDelete;

            using (var db = _dbContext)
            {
                LikeToDelete = db.Likes.FirstOrDefault(t => t.Id == id);

                if (LikeToDelete == null)
                {
                    return false;
                }
                else
                {
                    db.Likes.Remove(LikeToDelete);
                    db.SaveChanges();
                    return true;
                }
            }
        }

        public bool DeleteReplyLike(int id)
        {
            ReplyLike ReplyLikeToDelete;

            using (var db = _dbContext)
            {
                ReplyLikeToDelete = db.ReplyLikes.FirstOrDefault(t => t.Id == id);

                if (ReplyLikeToDelete == null)
                {
                    return false;
                }
                else
                {
                    db.ReplyLikes.Remove(ReplyLikeToDelete);
                    db.SaveChanges();
                    return true;
                }
            }
        }

    }
}
