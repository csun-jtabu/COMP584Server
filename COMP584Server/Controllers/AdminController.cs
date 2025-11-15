using COMP584Server.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using WorldModel;

namespace COMP584Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController(UserManager<WorldModelUser> userManager, JwtHandler jwtHandler) : ControllerBase
    {
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            WorldModelUser? worldUser = await userManager.FindByNameAsync(loginRequest.username);
            //if (worldUser == null || !await userManager.CheckPasswordAsync(worldUser, loginRequest.password))
            //{
            //    Response.StatusCode = StatusCodes.Status401Unauthorized;
            //    await Response.WriteAsync("Invalid username or password");
            //    return;
            //}

            if (worldUser == null)
            {
                return Unauthorized("Invalid username");
            }

            bool loginStatus = await userManager.CheckPasswordAsync(worldUser, loginRequest.password);
            if (!loginStatus)
            {
                return Unauthorized("Invalid password");
            }

            JwtSecurityToken jwtToken = await jwtHandler.GenerateToken(worldUser);
            string stringToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return Ok(new LoginResponse
            {
                Success = true,
                Message = "Mom loves me",
                Token = stringToken
            });
        }
    }
}
