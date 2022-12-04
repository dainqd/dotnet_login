namespace Auth.Models;
using System;
using System.Collections.Generic;
public class Users
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Name { get; set; }
    public string EmailId { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public string DateOfBirth { get; set; }

    public IEnumerable<Users> GetUsers()
    {
        return new List<Users>() { 
            new Users { Id = 101, 
                UserName = "admin", 
                Name = "AD", 
                EmailId = "anet@test.com", 
                Password = "123456", 
                Role = "Admin", 
                DateOfBirth = "01/01/2022" },
            new Users { Id = 102,
                UserName = "user",
                Name = "Hello",
                EmailId = "user@gmail.com",
                Password = "123456",
                Role = "User",
                DateOfBirth = "10/10/2022" }
        };
    }
}