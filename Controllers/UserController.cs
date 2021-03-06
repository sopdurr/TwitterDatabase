using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using twitterAPI.Data;
using twitterAPI.Models;


namespace twitterAPI.Controllers
{
    [Route("api/user")]
    [Controller]
    public class UserController : ControllerBase
    {
        private readonly Irepository _repository;

        public UserController(Irepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<List<User>> GetUser()
        {
            try
            {
                return Ok(_repository.GetUser());

            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            try
            {
                User u = _repository.GetUserById(id);

                if(u == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(u);
                }


            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _repository.AddUser(user);
                    return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
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
        public ActionResult<User> UpdateUser(int id,[FromBody] User user )
        {
            try
            {
                User updatedUser = _repository.UpdateUser(id, user);

                if (updatedUser == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(GetUserById), new { id = updatedUser.Id }, updatedUser);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<User> DeleteUser(int id)
        {
            try
            {
                bool deleteSuccess = _repository.DeleteUser(id);

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
