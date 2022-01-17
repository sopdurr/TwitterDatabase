using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using twitterAPI.Data;
using twitterAPI.Models;

namespace twitterAPI.Controllers
{

    [Route("api/replies")]
    [Controller]
    public class ReplyController : ControllerBase
    {
        private readonly Irepository _repository;

        public ReplyController(Irepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public ActionResult<List<Reply>> GetReply()
        {
            try
            {
                return Ok(_repository.GetReply());

            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Reply> GetReplyById(int id)
        {
            try
            {
                Reply r = _repository.GetReplyById(id);

                if(r == null)
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
        public IActionResult AddReply([FromBody] Reply reply)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _repository.AddReply(reply);
                    return CreatedAtAction(nameof(GetReplyById), new { id = reply.Id }, reply);
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
        public ActionResult<Reply> UpdateReply(int id, [FromBody] Reply reply)
        {
            try
            {
                Reply updatedReply = _repository.UpdateReply(id, reply);

                if (updatedReply == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(GetReplyById), new { id = updatedReply.Id }, updatedReply);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Reply> DeleteReply(int id)
        {
            try
            {
                bool deleteSuccess = _repository.DeleteReply(id);

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
