using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SampleSourceKT.Application.DTO;
using SampleSourceKT.Application.DTO.Requests.Users;
using SampleSourceKT.Application.DTO.Responses;
using SampleSourceKT.Application.ServiceContracts.Products;
using SampleSourceKT.Application.ServiceContracts.Users;
using SampleSourceKT.Data.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SampleSourceKT.Application.ApplicationServices
{
    public class UserSerivices : IUserServices
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _config;

        public UserSerivices(IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IConfiguration config)
        {
            this._mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
        }

        public async Task<ApiResult<string>> Authenticate(LoginRequestDto model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                return new ApiErrorResult<string>("Can not find user name!");
            }
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.IsRemembered, true);
            if (!result.Succeeded)
            {
                return new ApiErrorResult<string>("Invalid user to login!");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Email,user.Email),
                //new Claim(ClaimTypes.MobilePhone,user.PhoneNumber),
                //new Claim(ClaimTypes.Role, string.Join(";",roles)),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "User"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);
            //var data = new JwtSecurityTokenHandler().WriteToken(token);
            return new ApiSuccessResult<string>(new JwtSecurityTokenHandler().WriteToken(token));

        }

        public async Task<ApiResult<bool>> Register(RegisterRequestDto model)
        {
            AppUser user;
            user = await _userManager.FindByNameAsync(model.Username);
            if (user != null)
            {
                return new ApiErrorResult<bool>("This Username is exist!");
            }
            user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                return new ApiErrorResult<bool>("This Email is exist!");
            }
            user = this._mapper.Map<AppUser>(model);
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>("Register successfully");
            }
            return new ApiErrorResult<bool>("Register is not success!");
        }
    }
}
