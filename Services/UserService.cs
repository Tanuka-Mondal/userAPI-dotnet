using UserAPI_Tanuka.Exceptions;
using UserAPI_Tanuka.Models;
using UserAPI_Tanuka.Repository;

namespace UserAPI_Tanuka.Services
{
    public class UserService : IUserService
    {
        readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public int AddUser(User user)
        {
            User userDetails = _userRepository.GetUserName(user.Name);
            if (userDetails == null)
            {
                int addResult = _userRepository.AddUser(user);
                return addResult;
            }
            else
            {
                throw new DuplicateUserException($"Duplicate Bicycle:{user.Name}");
            }
        }

        public bool BlockUser(int id)
        {
            User userEditObject = _userRepository.GetUserById(id);
            if (userEditObject != null)
            {               
                 bool blockResult = _userRepository.BlockUser(userEditObject);
                 return blockResult;               
            }
            else
            {
                throw new UserNotFoundException("User doesn't exist");
            }
        }

        public bool DeleteUser(int userId)
        {
            User userDeleteDetails = _userRepository.GetUserById(userId);
            if (userDeleteDetails != null)
            {
                bool deleteResult = _userRepository.DeleteUser(userDeleteDetails);
                return deleteResult;
            }
            else
            {
                throw new UserNotFoundException("User doesn't exist");
            }
        }

        public bool EditUser(int id, User newUser)
        {
            User userEditObject = _userRepository.GetUserById(id);
            if (userEditObject != null)
            {
                bool areEqual = userEditObject.Equals(newUser);
                if (!areEqual)
                {
                    bool editResult = _userRepository.EditUser(userEditObject, newUser);
                    return editResult;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                throw new UserNotFoundException("User doesn't exist");
            }
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            User user = _userRepository.GetUserById(id);
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new UserNotFoundException("User Not Found");
            }
        }

        public User GetUserByName(string name)
        {
            User user = _userRepository.GetUserName(name);
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new UserNotFoundException("User Not Found");
            }
        }

        public User Login(LoginUser loginUser)
        {
            User user = _userRepository.Login(loginUser);
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new UserNotFoundException("User Not Found");
            }
        }
    }
}
