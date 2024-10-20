using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using InterviewTakeawayTask2.Models;
using InterviewTakeawayTask2.Repositories;

namespace InterviewTakeawayTask2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: Gets All Users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            return Ok(users);
        }

        // GET: Gets Specific Users
        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        //POST: Update existing user
        [HttpPut("{id}")]
        public ActionResult<User> UpdateExistingUser([FromBody] User userUpdate)
        {
            if (userUpdate == null || string.IsNullOrEmpty(userUpdate.Username) || string.IsNullOrEmpty(userUpdate.Password))
            {
                return BadRequest("Invalid user data.");
            }

            var updateUser = _userRepository.UpdateExistingUser(userUpdate.Name, userUpdate.Password, userUpdate.Email, userUpdate.Age, userUpdate.Id);
            if (updateUser == null)
            {
                return NotFound("User not found");
            }
            return Ok(updateUser);
        }

        // POST: Creates a User
        [HttpPost]
        public ActionResult<User> CreateUser([FromBody] UserRequest user)
        {
            if (user == null || string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Email))
            {
                return BadRequest("Invalid user data.");
            }

            var newUser = _userRepository.CreateUser(user.Name, user.Password, user.Email, user.Age);
            return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
        }
    }
}
