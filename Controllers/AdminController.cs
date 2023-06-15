using Microsoft.AspNetCore.Http;using Microsoft.AspNetCore.Mvc;using Microsoft.IdentityModel.Tokens;using System.IdentityModel.Tokens.Jwt;using System.Security.Claims;using System.Text;using W4Assessment.Model;namespace W.Controllers{    [Route("api/[controller]")]    [ApiController]    public class AdminController : ControllerBase    {        public AdminController()        {

        }        Dictionary<string, string> UsersRecords = new Dictionary<string, string>        {                { "mohammed","moh12"},                { "ashik","ash12"},                { "ibrahim","ibr12"},        };        [HttpPost]        [Route("[action]")]        public IActionResult Login([FromBody] User User)        {
            // TODO: Authenticate Admin with Database
            // If not authenticate return 401 Unauthorized
            // Else continue with below flow

            //var Claims = new List<Claim>
            //{
            //    new Claim("type", "Admin"),
            //};

            //Claims,

            if (!UsersRecords.Any(x => x.Key == User.Username && x.Value == User.Password))            {                return null;            }            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SXkSqsKyNUyvGbnHs7ke2NCq8zQzNLW7mPmHbnZZ"));

            var token = new JwtSecurityToken(
                "https://fbi-demo.com",
                "https://fbi-demo.com",
                expires: DateTime.Now.AddDays(30.0),
                signingCredentials: new SigningCredentials(Key, SecurityAlgorithms.HmacSha256)
            );            var tokenHandler = new JwtSecurityTokenHandler();            var stringToken = tokenHandler.WriteToken(token);            return Ok(new { token = stringToken });        }    }}