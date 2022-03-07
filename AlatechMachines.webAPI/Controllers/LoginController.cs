using AlatechMachines.webAPI.Domains;
using AlatechMachines.webAPI.Repositories;
using AlatechMachines.webAPI.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace AlatechMachines.webAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUserRepository _userRepository;

        public LoginController()
        {
            _userRepository = new UserRepository();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            try
            {
                User _user = _userRepository.FindByEmailAndPassword(user.Username, user.Password);

                if (_user == null)
                {
                    return StatusCode(400, new ResponseData { Message = "Credenciais inválidas" });
                }

                //if (!_userRepository.VerifyToken(Request.Headers[HeaderNames.Authorization], _user.Id))
                //{
                //    return StatusCode(403, new ResponseData { Message = "Usuário já autenticado" });
                //}

                var claims = new[]
                {
                    new Claim("Username", _user.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, _user.Id.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("SP_Medical_group"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "Issuer",
                    audience: "Audience",
                    claims: claims,
                    signingCredentials: creds
                    );

                var token2 = new { token = new JwtSecurityTokenHandler().WriteToken(token) };
                Console.WriteLine(token2);
                _userRepository.SaveToken(token2.token, _user.Id);

                return StatusCode(200, new ResponseData { Message = "Usuario logado", Data = token2 });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseData { Message = "Erro interno", Data = ex });
            }
        }

        [HttpDelete]
        [Authorize]
        public IActionResult Logout()
        {
            try
            {
                User user = _userRepository.FindById(Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value));

                if (user == null)
                {
                    return StatusCode(404, new ResponseData { Message = "Usuario não encontrado" });
                }

                if (!_userRepository.VerifyToken(Request.Headers[HeaderNames.Authorization], user.Id))
                {
                    return StatusCode(403, new ResponseData { Message = "Token inválido" });
                }

                _userRepository.DeleteUserToken(user.Id);

                return StatusCode(200, new ResponseData { Message = "Logout com sucesso" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseData { Message = "Erro interno", Data = ex });
            }
        }
    }
}
