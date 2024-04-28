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
        private readonly IPeoplesService _peoplesService;
        public AuthController(WdContext context, IConfiguration configuration, IPeoplesService peoplesService)
        {
            _configuration = configuration;
            _peoplesService = peoplesService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<PeopleViewModel>> Login(UserDto request)
        {
            PeopleViewModel resPeopole = null;
            try
            {
                bool authByBarcode = string.IsNullOrEmpty(request.UserPassword);
                bool passByBarcode = false;
                people people;
                if (authByBarcode)
                {
                    people = _peoplesService.GetByBarcode(request.UserLogin);
                    passByBarcode = people != null;
                }
                else
                {
                    people = _peoplesService.GetByLogin(request.UserLogin);
                }

                if (people == null)
                {
                    return BadRequest("User not found.");
                }

                if (!passByBarcode && !VerifyPassword(request.UserPassword, people))
                {
                    return BadRequest("Wrong password.");
                }

                resPeopole = people.Adapt<PeopleViewModel>();
                resPeopole.Jwt = CreateToken(people);

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
           
            return Ok(resPeopole);
        }

        private string CreateToken(people user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.userlogin),
                new Claim(ClaimTypes.NameIdentifier, user.idpeople.ToString())
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

        private bool VerifyPassword(string password, people people)
        {
            bool isPswCorrect = (people.iscrypt ?? false)
                ? VerifyMd5Hash(password, people.userpassword ?? "")
                : password == people.userpassword;

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