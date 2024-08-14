using MyDotNetApi.Data;
using MyDotNetApi.DTOs.UserDtos;
using MyDotNetApi.Models;
using System.Collections.Generic;

namespace MyDotNetApi.Services
{
    public class UserService
    {
        private readonly DataContextDapper _dapper;

        public UserService(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }

        public IEnumerable<Users> GetUsers()
        {
            string sql = @"
                SELECT 
                    [UserId], 
                    [FirstName], 
                    [LastName], 
                    [Email], 
                    [Gender], 
                    [Active]
                FROM EntitiesAppSchema.Users";
            return _dapper.LoadData<Users>(sql);
        }

        public Users GetUserById(int id)
        {
            string sql = @"
                SELECT 
                    [UserId], 
                    [FirstName], 
                    [LastName], 
                    [Email], 
                    [Gender], 
                    [Active]
                FROM EntitiesAppSchema.Users
                WHERE UserId = @UserId";
            return _dapper.LoadDataSingle<Users>(sql, new { UserId = id });
        }

        public bool AddUser(CreateUserDto user)
        {
            string sql = @"
                INSERT INTO EntitiesAppSchema.Users 
                ([FirstName],
                [LastName],
                [Email],
                [Gender],
                [Active]
                ) VALUES (
                @FirstName,
                @LastName,
                @Email,
                @Gender,
                @Active)";
            var newUser = new
            {
                user.FirstName,
                user.LastName,
                user.Email,
                user.Gender,
                user.Active,
            };
            return _dapper.ExecuteSql(sql, newUser);
        }

        public bool EditUser(int id, UpdateUserDto user)
        {
            string sql = @"
                UPDATE EntitiesAppSchema.Users 
                SET [FirstName] = @FirstName, 
                    [LastName] = @LastName, 
                    [Email] = @Email, 
                    [Gender] = @Gender, 
                    [Active] = @Active
                WHERE UserId = @UserId";
            var updateUser = new
            {
                user.FirstName,
                user.LastName,
                user.Email,
                user.Gender,
                user.Active,
                UserId = id
            };
            return _dapper.ExecuteSql(sql, updateUser);
        }

        public bool DeleteUser(int id)
        {
            string sql = @"
                DELETE FROM EntitiesAppSchema.Users 
                WHERE UserId = " + id;

            return _dapper.ExecuteSql(sql);

        }
    }
}
