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
    public class PowerSupplyController : ControllerBase
    {
        private IPowerSupplyRepository _powerSupplyRepository;
        private IUserRepository _userRepository;

        public PowerSupplyController()
        {
            _powerSupplyRepository = new PowerSupplyRepository();
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

                List<PowerSupply> PowerSupplies = _powerSupplyRepository.Read();

                return StatusCode(200, new ResponseData { Message = "Fontes de alimentação listadas", Data = PowerSupplies });
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

            List<PowerSupply> PowerSupplies = _powerSupplyRepository.SearchByName(q);

            if (pag.pageSize == 0)
            {
                return StatusCode(200, new ResponseData { Message = "Fontes de alimentação listadas", Data = PowerSupplies });
            }

            List<PowerSupply> PowerSupplies2 = new List<PowerSupply>();

            if (pag.page <= 0)
            {
                for (int i = 0; i < pag.pageSize; i++)
                {
                    PowerSupplies2.Add(PowerSupplies[i]);
                }

                return StatusCode(200, new ResponseData { Message = "Fontes de alimentação listadas", Data = PowerSupplies2 });
            }

            for (int i = (pag.pageSize - 1) * pag.page; i < pag.pageSize * pag.page; i++)
            {
                PowerSupplies2.Add(PowerSupplies[i]);
            }

            return StatusCode(200, new ResponseData { Message = "Fontes de alimentação listadas", Data = PowerSupplies2 });
        }
    }
}
