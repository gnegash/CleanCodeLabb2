using CleanCodeLabb2.Model;
using CleanCodeLabb2.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CleanCodeLabb2.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var users = _userRepository.GetAll();
            return Ok(users);
        }

        [HttpPost]
        //koppla löst, ref til mq
        //gör async
        public ActionResult AddUser(User user)
        {
            if (user == null)
            {
                return BadRequest("Something went wrong...");
            }

            _userRepository.Add(user);
            return Ok();
        }
    }
}



