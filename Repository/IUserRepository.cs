using UserAPI_Tanuka.Models;

namespace UserAPI_Tanuka.Repository
{
    public interface IUserRepository
    {
        int AddUser(User user);
        bool BlockUser(User userEditObject);
        bool DeleteUser(User userDeleteDetails);
        bool EditUser(User userEditObject, User newUser);
        List<User> GetAllUsers();
        User GetUserById(int userId);
        User GetUserName(string? name);
        User Login(LoginUser loginUser);
    }
}
