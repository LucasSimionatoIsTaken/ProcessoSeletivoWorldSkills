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
    public class MachineController : ControllerBase
    {
        private IMachineRepository _machineRepository;
        private IUserRepository _userRepository;

        public MachineController()
        {
            _machineRepository = new MachineRepository();
            _userRepository = new UserRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                if (!_userRepository.VerifyToken(Request.Headers[HeaderNames.Authorization], Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value)))
                {
                    return StatusCode(403, new ResponseData { Message = "Token inválido" });
                }

                List<Machine> Machines = _machineRepository.Read();

                return StatusCode(200, new ResponseData { Message = "Fontes de alimentação listadas", Data = Machines });
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
            try
            {
                if (!_userRepository.VerifyToken(Request.Headers[HeaderNames.Authorization], Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value)))
                {
                    return StatusCode(403, new ResponseData { Message = "Token Inválido" });
                }

                List<Machine> Machines = _machineRepository.SearchByName(q);

                if (pag.pageSize == 0)
                {
                    return StatusCode(200, new ResponseData { Message = "Fontes de alimentação listadas", Data = Machines });
                }

                List<Machine> Machines2 = new List<Machine>();

                if (pag.page <= 0)
                {
                    for (int i = 0; i < pag.pageSize; i++)
                    {
                        Machines2.Add(Machines[i]);
                    }

                    return StatusCode(200, new ResponseData { Message = "Fontes de alimentação listadas", Data = Machines2 });
                }

                for (int i = (pag.pageSize - 1) * pag.page; i < pag.pageSize * pag.page; i++)
                {
                    Machines2.Add(Machines[i]);
                }

                return StatusCode(200, new ResponseData { Message = "Fontes de alimentação listadas", Data = Machines2 });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseData { Message = "Erro interno", Data = ex });
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post(Machine machine)
        {
            try
            {
                if (!_userRepository.VerifyToken(Request.Headers[HeaderNames.Authorization], Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value)))
                {
                    return StatusCode(403, new ResponseData { Message = "Token Inválido" });
                }

                List<Error> Errors = _machineRepository.VerifyCompatibility(machine);

                if (Errors != null)
                {
                    return StatusCode(400, new ResponseData { Message = "Um ou mais dispositivos são incompatíveis", Errors = Errors });
                }

                int IdMachine = _machineRepository.Create(machine);

                return StatusCode(200, new ResponseData { Message = "Criado", Data = IdMachine });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseData { Message = "Erro interno", Data = ex });
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Machine machine)
        {
            try
            {
                if (!_userRepository.VerifyToken(Request.Headers[HeaderNames.Authorization], Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value)))
                {
                    return StatusCode(403, new ResponseData { Message = "Token Inválido" });
                }

                Machine oldMachine = _machineRepository.GetById(id);

                if (machine == null)
                {
                    return StatusCode(404, new ResponseData { Message = "Não encontrado" });
                }

                machine.Id = id;
                machine.Description = machine.Description == null ? oldMachine.Description : machine.Description;
                machine.GraphicCardId = machine.GraphicCardId == 0 ? oldMachine.GraphicCardId : machine.GraphicCardId;
                machine.GraphicCardAmount = machine.GraphicCardAmount == 0 ? oldMachine.GraphicCardAmount : machine.GraphicCardAmount;
                machine.MachineHasStorageDevices = machine.MachineHasStorageDevices == null ? oldMachine.MachineHasStorageDevices : machine.MachineHasStorageDevices;
                machine.MotherboardId = machine.MotherboardId == 0 ? oldMachine.MotherboardId : machine.MotherboardId;
                machine.Name = machine.Name == null ? oldMachine.Name : machine.Name;
                machine.PowerSupplyId = machine.PowerSupplyId == 0 ? oldMachine.PowerSupplyId : machine.PowerSupplyId;
                machine.ProcessorId = machine.ProcessorId == 0 ? oldMachine.ProcessorId : machine.ProcessorId;
                machine.RamMemoryId = machine.RamMemoryId == 0 ? oldMachine.RamMemoryId : machine.RamMemoryId;
                machine.RamMemoryAmount = machine.RamMemoryAmount == 0 ? oldMachine.RamMemoryAmount : machine.RamMemoryAmount;

                List<Error> Errors = _machineRepository.VerifyCompatibility(machine);

                if (Errors != null)
                {
                    return StatusCode(400, new ResponseData { Message = "Um ou mais dispositivos incompatíveis", Errors = Errors });
                }

                _machineRepository.Update(machine);

                return StatusCode(200, new ResponseData { Message = "Atualizado" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseData { Message = "Erro interno", Data = ex });
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (!_userRepository.VerifyToken(Request.Headers[HeaderNames.Authorization], Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value)))
                {
                    return StatusCode(403, new ResponseData { Message = "Token Inválido" });
                }

                Machine machine = _machineRepository.GetById(id);

                if (machine == null)
                {
                    return StatusCode(404, new ResponseData { Message = "Não encontrado" });
                }

                _machineRepository.Delete(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseData { Message = "Erro interno" });
            }
        }

        [Authorize]
        [HttpPost("verify")]
        public IActionResult Verify(Machine machine)
        {
            try
            {
                if (!_userRepository.VerifyToken(Request.Headers[HeaderNames.Authorization], Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value)))
                {
                    return StatusCode(403, new ResponseData { Message = "Token Inválido" });
                }

                List<Error> Errors = _machineRepository.VerifyCompatibility(machine);

                if (Errors == null)
                {
                    return StatusCode(200, new ResponseData { Message = "Máquina válida" });
                }

                return StatusCode(400, new ResponseData { Message = "Um ou mais dispositivos incompatíveis", Data = Errors });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseData { Message = "Erro interno", Data = ex });
            }
        }
    }
}
