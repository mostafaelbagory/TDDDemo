using TDDDemo.Models;

namespace TDDDemo.Services;

public interface IUserService
{
    Task<List<User>> GetAllUsers();
}
