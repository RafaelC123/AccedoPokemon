using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PokemonAccedo.Api.Util.Attributes.Versions;
using PokemonAccedo.Dtos;
using PokemonAccedo.Dtos.Account.Request;
using PokemonAccedo.Dtos.Account.Response;
using PokemonAccedo.Models.Account;
using System.Diagnostics.SymbolStore;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;

namespace PokemonAccedo.Api.Controllers.V1.Account
{
    [ApiController]
    [Route("Api/Account")]
    [HeaderRequestVersion("x-version", "1")]
    public class AccountController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly UserManager<UserIdentity> userManager;
        private readonly SignInManager<UserIdentity> signInManager;
        private readonly IMapper mapper;

        public AccountController(IConfiguration configuration, UserManager<UserIdentity> userManager, SignInManager<UserIdentity> signInManager, IMapper mapper)
        {
            this.configuration = configuration;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ResponseDto<string>>> Register(RegisterRequestDto Request)
        {
            var UserRequest = mapper.Map<UserIdentity>(Request);
            UserRequest.UserName = Request.Email;

            var Result = await userManager.CreateAsync(UserRequest,Request.Password); 
            if(Result.Succeeded && User != null)
            {
                //No agregare verificacion por Email para evitar dejar credenciales de Email en el codigo 
                return new ResponseDto<string>
                {
                    Message = "¡Usuario registrado correctamente!",
                    IsSuccess = true,
                    Data = null
                };
            }
            return new ResponseDto<string>
            {
                Message = Result.Errors.FirstOrDefault().Description,
                Exception = Result.Errors.FirstOrDefault().Code,
                Data = null,
                IsSuccess = false,
            };
        }


        [HttpPost("Login")]
        public async Task<ActionResult<ResponseDto<LoginResponseDto>>> Login(LoginRequestDto Request)
        {
            var User = await userManager.FindByEmailAsync(Request.Email);
            var UserSiginInResult = await signInManager.PasswordSignInAsync(User, Request.Password, isPersistent: false,false);
            
            if (UserSiginInResult.Succeeded && User != null)
            {
                var Response = await GenerateSignInToken(Request, User);

                return new ResponseDto<LoginResponseDto>
                {
                    Message = "¡Usuario Logueado correctamente!",
                    IsSuccess = true,
                    Data = Response
                };
            }
            return new ResponseDto<LoginResponseDto>
            {
                Message = "Credenciales incorrectas",
                IsSuccess = false,
                Data = null
            };
        }



        private async Task<LoginResponseDto> GenerateSignInToken(LoginRequestDto request, UserIdentity User)
        {
          

            List<Claim> Claims = new List<Claim>
            {
                new Claim("Email", User.Email),
                new Claim("Name", User.FirstName),
                new Claim("SurName", User.FirstSurName)
            };

            SymmetricSecurityKey Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["KeyJWT"]));
            SigningCredentials Credentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
            DateTime Expiration = DateTime.Now.Add(TimeSpan.FromHours(12));
            SecurityToken token = new JwtSecurityToken(issuer: null, signingCredentials: Credentials, claims: Claims, expires: Expiration);

            return new LoginResponseDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = Expiration,
                UserName = User.UserName,
                Name = User.FirstName,
                SurName = User.FirstSurName
            };

        }
    }
}
