using AlatechMachines.webAPI.Domains;
using AlatechMachines.webAPI.Interfaces;
using AlatechMachines.webAPI.Repositories;
using AlatechMachines.webAPI.Response;
using AlatechMachines.webAPI.utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace AlatechMachines.webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class RamMemoryController : ControllerBase
    {
        private IRamMemoryRepository _ramMemoryRepository;
        private IUserRepository _userRepository;

        public RamMemoryController()
        {
            _ramMemoryRepository = new RamMemoryRepository();
            _userRepository = new UserRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                if (Request.Headers[HeaderNames.Authorization] != _userRepository.FindById(Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value)).AccessToken);
                {
                    return StatusCode(403, new ResponseData { Message = "Token inválido" });
                }

                List<RamMemory> RamMemories = _ramMemoryRepository.Read();

                return StatusCode(200, new ResponseData { Message = "Memórias RAM listadas", Data = RamMemories });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseData { Message = "Erro interno", Data = ex });
            }
        }

        [Authorize]
        [HttpGet("{q}")]
        public IActionResult GetSearch(string q, Page pag)
        {

            if (!_userRepository.VerifyToken(Request.Headers[HeaderNames.Authorization], Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value)))
            {
                return StatusCode(403, new ResponseData { Message = "Token Inválido" });
            }

            List<RamMemory> RamMemories = _ramMemoryRepository.SearchByName(q);

            if (pag.pageSize == 0)
            {
                return StatusCode(200, new ResponseData { Message = "Memórias RAM listadas", Data = RamMemories });
            }

            List<RamMemory> RamMemories2 = new List<RamMemory>();

            if (pag.page <= 0)
            {
                for (int i = 0; i < pag.pageSize; i++)
                {
                    RamMemories2.Add(RamMemories[i]);
                }

                return StatusCode(200, new ResponseData { Message = "Memórias RAM listados", Data = RamMemories2 });
            }

            for (int i = (pag.pageSize - 1) * pag.page; i < pag.pageSize * pag.page; i++)
            {
                RamMemories2.Add(RamMemories[i]);
            }

            return StatusCode(200, new ResponseData { Message = "Memórias RAM listadas", Data = RamMemories2 });
        }
    }
}
