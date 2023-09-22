using Customer_API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Customer_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IConfiguration _config;
        public LoginController(IConfiguration config)
        {
            _config = config;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public ActionResult Login([FromBody] UserLogin userLogin)
        {
            var user = LoginHelper.LoginHelper.Authenticate(userLogin);
            if (user != null)
            {
                var token = LoginHelper.LoginHelper.GenerateToken(user, _config);
                return Ok(token);
            }

            return NotFound("user not found");
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("Logout")]
        public ActionResult Logout()
        {
            return Ok("okay");
        }


        //private string GenerateToken(UserModel user)
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var claims = new[]
        //    {
        //        new Claim(ClaimTypes.NameIdentifier,user.Username),
        //        new Claim(ClaimTypes.Role,user.Role)
        //    };

        //    var token = new JwtSecurityToken(_config["Jwt:Issuer"],
        //        _config["Jwt:Audience"],
        //        claims,
        //        expires: DateTime.Now.AddMinutes(15),
        //        signingCredentials: credentials);


        //    return new JwtSecurityTokenHandler().WriteToken(token);

        //}

        //To authenticate user
        //private UserModel Authenticate(UserLogin userLogin)
        //{
        //    var currentUser = UserConstants.Users.FirstOrDefault(x => x.Username.ToLower() ==
        //        userLogin.Username.ToLower() && x.Password == userLogin.Password);
        //    if (currentUser != null)
        //    {
        //        return currentUser;
        //    }
        //    return null;
        //}

    }
}
