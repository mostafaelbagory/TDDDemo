using TDDDemo.Models;

namespace TDDDemo.Services;
public class UserService : IUserService
{
    private readonly HttpClient _httpClient;

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<User>> GetAllUsers()
    {
        // var res = await _httpClient.GetAsync("https://example.com");
        return new List<User> { };
    }
}
