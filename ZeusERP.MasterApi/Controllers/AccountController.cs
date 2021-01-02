using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ZeusERP.Entities.Concrete;
using ZeusERP.Entities.Concrete.ComplexTypes;

using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace ZeusERP.MasterApi.Controllers
{
    [EnableCors("TCAPolicy")]
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserManager<SysUser> _userManager;
        private RoleManager<SysUserRole> _roleManager;
        private SignInManager<SysUser> _signinManager;
        private IConfiguration _config;

        public AccountController(
            UserManager<SysUser> userManager,
            RoleManager<SysUserRole> roleManager,
            SignInManager<SysUser> signinManager,
            IConfiguration config
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signinManager = signinManager;
            _config = config;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] dynamic content)
        {
            var json = JsonConvert.DeserializeObject<JObject>(content.ToString());
            Console.WriteLine(json);

            string username = json.GetValue("username").ToString();
            string pw = json.GetValue("password").ToString();
            bool remember = bool.Parse(json.GetValue("remember").ToString());
            SignInResult result = _signinManager.PasswordSignInAsync(username, pw, remember, false).Result;
            if(result.Succeeded)
            {
                var tokenString = GenerateJSONWebToken(new SysUser { UserName = username });

                return Ok(new { token = tokenString });
            }
            return Forbid(JsonConvert.SerializeObject("Unapproved!"));
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterDto content)
        {
            //var json = JsonConvert.DeserializeObject<JObject>(content);
            //string username = json.GetValue("username").ToString();
            //string pw = json.GetValue("password").ToString();

            var user = new SysUser
            {
                UserName = content.Username
            };
            IdentityResult result = _userManager.CreateAsync(user, content.Password).Result;
            if(result.Succeeded)
            {
                if(!_roleManager.RoleExistsAsync("Admin").Result)
                {
                    SysUserRole role = new SysUserRole
                    {
                        Name = "Admin"
                    };

                    IdentityResult roleResult = _roleManager.CreateAsync(role).Result;

                    if(!roleResult.Succeeded)
                    {
                        return BadRequest(JsonConvert.SerializeObject("Role cannot be created!"));
                    }
                }

                return Ok(JsonConvert.SerializeObject("User was created successfully!"));
            }
            return Ok(JsonConvert.SerializeObject("allah"));
        }

        private string GenerateJSONWebToken(SysUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
