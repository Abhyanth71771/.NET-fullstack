using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace IDP_RPWebAPI.Controllers
{
    [EnableCors("angularapp_policy")]
    [Route("[controller]")]
    [ApiController]

    public class AuthenticationController : ControllerBase
    {

        [HttpPost]
        public IActionResult AuthenticateUser(User u)
        {
            //here you can write your data access code using ADO.NET, EF Core, etc.
            AspnetwebapidbContext context = new AspnetwebapidbContext();
            var result =
                context.Users.Where(
                    user => u.UserName == user.Username && u.Password == user.Pwd)
                        .SingleOrDefault();

            if (result == null)
            {
                return Unauthorized("Authentication failed for user: " + u.UserName);
            }
            //create a digital signature using the encoded secret
            var securitykey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes("thisisthesecretforgeneratingakey(mustbeatleast32bitlong)"));
            var signingCredentials = new SigningCredentials(
                securitykey, SecurityAlgorithms.HmacSha256);
            //create some user claims to be sent with the token
            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("subject", result.Username));
            claimsForToken.Add(new Claim("email", result.Email));
            claimsForToken.Add(new Claim("role", result.Userrole));

            //create a JWT token
            var jwtSecurityToken = new JwtSecurityToken(
                                            "http://localhost:5266",
                                            "Books",
                                            claimsForToken,
                                            DateTime.UtcNow,
                                            DateTime.UtcNow.AddHours(1),
                                            signingCredentials);

            //create a fullfledged JWT token ready to be sent in the response
            var tokenToReturn = new JwtSecurityTokenHandler()
               .WriteToken(jwtSecurityToken);

            var yest = "hello";

            //return the token to the consumer
            return Ok(JsonSerializer.Serialize(tokenToReturn));


        }
        [HttpGet]
        [Route("{name}")]
        public IActionResult GetRole(string name)
        {
            AspnetwebapidbContext context= new AspnetwebapidbContext();
            var result = context.Users.Where(user => user.Username == name).SingleOrDefault();
            return Ok(result);
        }

    }
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        //public string Email { get; set; }
        //public String Role { get; set; }
    }
}
