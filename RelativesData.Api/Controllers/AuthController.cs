using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RelativesData.Core.Dto;
using RelativesData.Core.Models;
using RelativesData.Core.Repositories;

namespace RelativesData.Api.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _auth;

        public AuthController(IAuthRepository auth)
        {
            _auth = auth;
        }
        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] LoginModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (user == null || user.secretKey!= "QRqM73b3@cF")
            {
                return BadRequest("Invalid client request");
            }
            var realUser = new User() { SapNumber=user.SapNumber,Password=user.Password}; 

            var userResult =_auth.Login(realUser);


            if (userResult != null)
            {
                return Ok(new { Token = ReturnToken() });
            }

            //if (user.UserName == "johndoe" && user.Password == "def@123")
            //{
            //    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("QRqM73b3cFY6NBNwuYuSttGOIJ1Hy3JemM86vGab9Iw="));
            //    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            //    var tokeOptions = new JwtSecurityToken(
            //        issuer: "http://localhost:32181",
            //        audience: "http://localhost:32181",
            //        //claims: new List<Claim>(),
            //        null,
            //        expires: DateTime.Now.AddMinutes(100),
            //        signingCredentials: signinCredentials
            //    );
            //    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            //    return Ok(new { Token = tokenString });
            //}
            else
            {
                return Unauthorized();
            }
        }



        [HttpPost, Route("Register")]
        public IActionResult Register([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }


            var userResult = _auth.Login(user);


            if (userResult != null)
            {
                return BadRequest("Already Registered Please Login");
            }

            var registerUserResult = _auth.Register(user);


            if (registerUserResult != null)
            {
                // return Ok(new { Token = ReturnToken() });
                return Ok("Registriation Is Done Please Login");
            }

            
            else
            {
                return Unauthorized();
            }
        }

        public string ReturnToken()
        {
           
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("QRqM73b3cFY6NBNwuYuSttGOIJ1Hy3JemM86vGab9Iw="));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:32181",
                    audience: "http://localhost:32181",
                    //claims: new List<Claim>(),
                    null,
                    expires: DateTime.Now.AddMinutes(100),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return tokenString;
            
        }
    }
}