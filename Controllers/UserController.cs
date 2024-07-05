using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAPI_Tanuka.AOP;
using UserAPI_Tanuka.Logging;
using UserAPI_Tanuka.Models;
using UserAPI_Tanuka.Services;

namespace UserAPI_Tanuka.Controllers
{

    [ServiceFilter(typeof(UserLogger))]
    [UserExceptionHandler]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserService _userService;
        readonly ITokenGeneratorService _tokenGeneratorService;
        public UserController(IUserService userService, ITokenGeneratorService tokenGeneratorService)
        {
            _userService = userService;
            _tokenGeneratorService = tokenGeneratorService;
        }
        [HttpGet]
        [Route("getAllUsers")]
        public ActionResult GetAllUsers()
        {
            List<User> users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpPost]
        [Route("addUser")]
        public ActionResult AddUser(User user)
        {
            int userAddResult = _userService.AddUser(user);
            return Created("api/adduser", userAddResult);
        }

        [HttpDelete]
        [Route("deleteUser")]
        public ActionResult DeleteUser(int userId)
        {
            bool userDeleteResult = _userService.DeleteUser(userId);
            return Ok(userDeleteResult);
        }

        [HttpPut]
        [Route("editUser")]
        public ActionResult EditUser(int id, User newUser)
        {
            bool userEditResult = _userService.EditUser(id, newUser);
            return Ok(userEditResult);
        }

        [HttpPost]
        [Route("login")]
        public ActionResult Login(LoginUser loginUser)
        {
            User user = _userService.Login(loginUser);
            if(user != null)
            {
               string userToken =  _tokenGeneratorService.GenerateToken(user.Id, user.Name, user.Role);
               return Ok(userToken); 
            }
            else
            {
                return NotFound("");
            }
        }

        [HttpGet]
        [Route("getUserByName")]

        public ActionResult GetUserByName(string name)
        {
            User user = _userService.GetUserByName(name);
            return Ok(user);
        }

        [HttpGet]
        [Route("getUserById/{id:int}")]

        public ActionResult GetUserById(int id)
        {
            User user = _userService.GetUserById(id);
            return Ok(user);
        }

        [HttpPut]
        [Route("blockUser")]
        public ActionResult BlockUser(int id)
        {
            bool userBlockResult = _userService.BlockUser(id);
            return Ok(userBlockResult);
        }
    }
}
