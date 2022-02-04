using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using twitterAPI.Data;
using twitterAPI.Models;

namespace twitterAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/replylikes")]
    public class ReplyLikeController : ControllerBase
    {
        private readonly Irepository _repository;

        public ReplyLikeController(Irepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<List<ReplyLike>> GetReplyLike()
        {
            try
            {
                return Ok(_repository.GetReplyLike());

            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("{id}")]
        public ActionResult<ReplyLike> GetReplyLikeById(int id)
        {
            try
            {
                ReplyLike r = _repository.GetReplyLikeById(id);

                if (r == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(r);
                }


            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }




        [HttpPost]
        public IActionResult AddReplyLike([FromBody] ReplyLike replyLike)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _repository.AddReplyLike(replyLike);
                    return CreatedAtAction(nameof(GetReplyLikeById), new { id = replyLike.Id }, replyLike);
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

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<ReplyLike> DeleteReplyLike(int id)
        {
            try
            {
                bool deleteSuccess = _repository.DeleteReplyLike(id);

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
