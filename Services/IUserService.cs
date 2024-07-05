using UserAPI_Tanuka.Models;

namespace UserAPI_Tanuka.Services
{
    public interface IUserService
    {
        int AddUser(User user);
        bool BlockUser(int id);
        bool DeleteUser(int userId);
        bool EditUser(int id, User newUser);
        List<User> GetAllUsers();
        User GetUserById(int id);
        User GetUserByName(string name);
        User Login(LoginUser loginUser);
    }
}
