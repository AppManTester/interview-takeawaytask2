using System.Collections.Generic;
using System.Linq;
using InterviewTakeawayTask2.Models;

namespace InterviewTakeawayTask2.Repositories
{
    public class UserRepository
    {
        private readonly List<User> _users;
        private int _nextId = 1;

        public UserRepository()
        {
            // Initializing with some dummy users
            _users = new List<User>
            {
                new User { Id = _nextId++, Username = "alice@example.com", Password="Password", Name = "Alice", Email = "alice@example.com", Age = 25 },
                new User { Id = _nextId++, Username = "bob@example.com", Password="Password", Name = "Bob", Email = "bob@example.com", Age = 30 }
            };
        }

        // Get all users
        public List<User> GetAllUsers() => _users;

        // Get a user by ID
        public User? GetUserById(int id) => _users.FirstOrDefault(u => u.Id == id);

        // Create a new user
        public User CreateUser(string name, string password, string email, int age)
        {
            var user = new User
            {
                Id = _nextId++,
                Username = email,
                Password = password,
                Name = name,
                Email = email,
                Age = age
            };

            _users.Add(user);
            return user;
        }

        // Update an existing user
        public User? UpdateExistingUser(string name, string password, string? email, int age, int id)
        {
            var existingUser = _users.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                return null;
            }

            existingUser.Name = name;
            existingUser.Email = email;
            existingUser.Age = age;
            existingUser.Password = password;

            return existingUser;
        }

    }
}
