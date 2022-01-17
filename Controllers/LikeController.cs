using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using twitterAPI.Data;
using twitterAPI.Models;

namespace twitterAPI.Controllers
{
    [Route("api/likes")]
    public class LikeController : ControllerBase
    {
        private readonly Irepository _repository;

        public LikeController(Irepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<List<Like>> GetLike()
        {
            try
            {
                return Ok(_repository.GetLike());

            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Like> GetLikeById(int id)
        {
            try
            {
                Like l = _repository.GetLikeById(id);

                if (l == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(l);
                }


            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }




        [HttpPost]
        public IActionResult AddLike([FromBody] Like like)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _repository.AddLike(like);
                    return CreatedAtAction(nameof(GetLikeById), new { id = like.Id }, like);
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
    }
}
