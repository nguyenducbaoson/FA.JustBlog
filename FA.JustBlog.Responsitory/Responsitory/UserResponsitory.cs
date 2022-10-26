using FA.JustBlog.Entities.Data;
using FA.JustBlog.Entities.Models;
using FA.JustBlog.Responsitory.IResponsitory;
using FA.JustBlog.ViewModel.Login;
using FA.JustBlog.ViewModel.Register;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Responsitory.Responsitory
{
    public class UserResponsitory : IUserResponsitory
    {
        private readonly ApplicationDbContext applicationDbContext;
        private string secretKey;
        public UserResponsitory(ApplicationDbContext applicationDbContext, IConfiguration configuration)
        {
            this.applicationDbContext = applicationDbContext;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }

        public bool IsUniqueUser(string username)
        {
            var user = applicationDbContext.LocalUsers.FirstOrDefault(x => x.UserName == username);
            if(user == null)
            {
                return true;
            }
            return false;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var user = applicationDbContext.LocalUsers.FirstOrDefault(x => x.UserName.ToLower() == request.UserName.ToLower() && x.PassWord == request.Password);
            if(user == null )
            {
                return new LoginResponse()
                {
                    Token = "",
                    User = null,
                };
            }
            //if user was found generate JWT Token
            var tokenHanler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHanler.CreateToken(tokenDescriptor);
            LoginResponse loginResponse = new LoginResponse()
            {
                Token = tokenHanler.WriteToken(token),
                User = user
            };
            return loginResponse;
        }

        public async Task<LocalUser> Register(RegisterationRequest registerationRequest)
        {
            LocalUser user = new LocalUser()
            {
                UserName = registerationRequest.UserName,
                Name = registerationRequest.Name,
                PassWord=registerationRequest.PassWord,
                Role=registerationRequest.Role,
            };
            applicationDbContext.LocalUsers.Add(user);
            await applicationDbContext.SaveChangesAsync();
            user.PassWord = "";
            return user; 
        }
    }
}
