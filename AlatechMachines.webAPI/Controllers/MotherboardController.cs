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
    public class MotherboardController : ControllerBase
    {
        private IMotherboardRepository _motherboardRepository;
        private IUserRepository _userRepository;

        public MotherboardController()
        {
            _motherboardRepository = new MotherboardRepository();
            _userRepository = new UserRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                if (!_userRepository.VerifyToken(Request.Headers[HeaderNames.Authorization], Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value))) ;
                {
                    return StatusCode(403, new ResponseData { Message = "Token inválido" });
                }

                List<Motherboard> Motherboards = _motherboardRepository.Read();

                return StatusCode(200, new ResponseData { Message = "Placas mãe listadas", Data = Motherboards });
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

            List<Motherboard> Motherboards = _motherboardRepository.SearchByName(q);

            if (pag.pageSize == 0)
            {
                return StatusCode(200, new ResponseData { Message = "Placas mãe listadas", Data = Motherboards });
            }

            List<Motherboard> Motherboards2 = new List<Motherboard>();

            if (pag.page <= 0)
            {
                for (int i = 0; i < pag.pageSize; i++)
                {
                    Motherboards2.Add(Motherboards[i]);
                }

                return StatusCode(200, new ResponseData { Message = "Placas mãe listadas", Data = Motherboards2 });
            }

            for (int i = (pag.pageSize - 1) * pag.page; i < pag.pageSize * pag.page; i++)
            {
                Motherboards2.Add(Motherboards[i]);
            }

            return StatusCode(200, new ResponseData { Message = "Placas mãe listadas", Data = Motherboards2 });
        }
    }
}
