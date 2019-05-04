using Microsoft.AspNetCore.Identity;
using Sports.Models;
using Sports.Services.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Sports.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IList<ApplicationUser>> GetAllAsync()
        {
            var users = await _userManager.GetUsersInRoleAsync("Athlete");
            return users;
        }
    }
}
