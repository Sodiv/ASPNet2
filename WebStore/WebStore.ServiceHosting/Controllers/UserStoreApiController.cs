using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WebStore.DAL.Context;
using WebStore.Domain.Entities;

namespace WebStore.ServiceHosting.Controllers
{
    [Produces("application/json")]
    [Route("api/userstore")]
    public class UserStoreApiController : Controller
    {
        private readonly UserStore<User> _userStore;

        public UserStoreApiController(WebStoreContext context)
        {
            _userStore = new UserStore<User>(context) { AutoSaveChanges = true };
        }

        [HttpPost("userId")]
        public async Task<string> GetUserIdAsync([FromQuery]User user)
        {
            return await _userStore.GetUserIdAsync(user);
        }

        [HttpPost("userName")]
        public async Task<string> GetUserNameAsync([FromBody]User user)
        {
            return await _userStore.GetUserNameAsync(user);
        }

        [HttpPost("userName/{userName}")]
        public async Task SetUserNameAsync([FromBody]User user, string userName)
        {
            await _userStore.SetUserNameAsync(user, userName);
        }

        [HttpPost("normalUserName")]
        public async Task<string> GetNormalizedUserNameAsync([FromBody]User user)
        {
            var result = await _userStore.GetNormalizedUserNameAsync(user);
            return result;
        }

        [HttpPost("normalUserName/{normalizedName}")]
        public async Task SetNormalizedUserNameAsync([FromBody]User user, string normalizedName)
        {
            await _userStore.SetNormalizedUserNameAsync(user, normalizedName);
        }

        ///Post api/users/user
        [HttpPost("user")]
        public async Task<bool> CreateAsync([FromBody]User user)
        {
            var result = await _userStore.CreateAsync(user);
            return result.Succeeded;
        }

        [HttpPut("user")]
        public async Task<bool> UpdateAsync([FromBody]User user)
        {
            var result = await _userStore.UpdateAsync(user);
            return result.Succeeded;
        }

        [HttpPost("user/delete")]
        public async Task<bool> DeleteAsync([FromBody]User user)
        {
            var result = await _userStore.DeleteAsync(user);
            return result.Succeeded;
        }

        [HttpGet("user/find/{userId}")]
        public async Task<User> FindByIdAsync(string userId)
        {
            var result = await _userStore.FindByIdAsync(userId);
            return result;
        }

        [HttpGet("user/normal/{normalizedUserName}")]
        public async Task<User> FindByNameAsync(string normalizedUserName)
        {
            var result = await _userStore.FindByNameAsync(normalizedUserName);
            return result;
        }

    }
}