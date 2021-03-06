using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using twitterAPI.Data;
using twitterAPI.Models;

namespace twitterAPI.Controllers
{
    [Route("api/tweets")]
    [Controller]
    public class TweetsController : ControllerBase
    {
        private readonly Irepository _repository;

        public TweetsController(Irepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Tweet>>> GetAllTweets()
        {

            try
            {
                List<Tweet> tweets = await _repository.GetAllTweetsAsync();

                return Ok(tweets);

            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Tweet> GetTweetById(int id)
        {

            try
            {
                Tweet t = _repository.GetTweetById(id);

                if(t == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(t);
                }


            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpPost]
        public IActionResult AddTweet([FromBody] Tweet tweet)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    _repository.AddTweet(tweet);
                    return CreatedAtAction(nameof(GetTweetById), new { id = tweet.Id}, tweet);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateTweet(int id, [FromBody] Tweet tweet)
        {

            try
            {
                Tweet updatedTweet = _repository.UpdateTweet(id, tweet);

                if (updatedTweet == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(GetTweetById), new { id = updatedTweet.Id }, updatedTweet);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Tweet> DeleteTweet(int id)
        {
            try
            {
                bool deleteSuccess = _repository.DeleteTweet(id);

                if (!deleteSuccess)
                {
                    return NotFound();
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

           
        }
    }
}
