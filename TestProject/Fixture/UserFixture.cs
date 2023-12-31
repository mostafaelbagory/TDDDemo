using TDDDemo.Models;

namespace TestProject.Fixture;

public static class UserFixture
{
    public static List<User> GetTestUsers() =>
        new() {
            new User
            {
                Id = 1,
                Name = "Test",
                Address= new ()
                {
                    Street = "str",
                    City = "city",
                    ZipCode= "0989767",
                },
                Email="mostafa@mail.com"
            },
            new User
            {
                Id = 1,
                Name = "Test",
                Address= new ()
                {
                    Street = "str",
                    City = "city",
                    ZipCode= "0989767",
                },
                Email="mostafa@mail.com"
            }
        };
}
