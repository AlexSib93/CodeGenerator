using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using TerminalApi.ViewModels;
using DataAccessLayer.Dto;
using DataAccessLayer;
using Mapster;
using BuisinessLogicLayer.Services;
using System.Text;

namespace TerminalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController: ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        public AuthController( IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<PeopleViewModel>> Login(UserAuthView request)
        {
            PeopleViewModel resPeopole = null;
            try
            {
                bool authByBarcode = string.IsNullOrEmpty(request.UserPassword);
                bool passByBarcode = false;
                User user;
                if (authByBarcode)
                {
                    user = _userService.GetByBarcode(request.UserLogin);
                    passByBarcode = user != null;
                }
                else
                {
                    user = _userService.GetByLogin(request.UserLogin);
                }

                if (user == null)
                {
                    return BadRequest("User not found.");
                }

                if (!passByBarcode && !VerifyPassword(request.UserPassword, user))
                {
                    return BadRequest("Wrong password.");
                }

                resPeopole = user.Adapt<PeopleViewModel>();
                resPeopole.Jwt = CreateToken(user);

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
           
            return Ok(resPeopole);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private bool VerifyPassword(string password, User user)
        {
            bool isPswCorrect = VerifyMd5Hash(password, user.Password ?? "");

            return isPswCorrect;
        }

        private string GetMd5Hash(string input)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
                sBuilder.Append(data[i].ToString("x2"));

            return sBuilder.ToString();
        }

        private bool VerifyMd5Hash(string input, string hash)
        {
            string hashOfInput = GetMd5Hash(input);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
                return true;
            else
                return false;
        }
    }
}