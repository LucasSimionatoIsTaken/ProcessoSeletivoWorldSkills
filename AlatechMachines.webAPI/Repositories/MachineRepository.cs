using AlatechMachines.webAPI.Contexts;
using AlatechMachines.webAPI.Domains;
using AlatechMachines.webAPI.Interfaces;
using AlatechMachines.webAPI.Response;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AlatechMachines.webAPI.Repositories
{
    public class MachineRepository : IMachineRepository
    {
        private readonly AlatechDbContext _ctx = new AlatechDbContext();

        public int Create(Machine machine)
        {
            _ctx.Machines.Add(machine);

            _ctx.SaveChanges();

            return machine.Id;
        }

        public void Delete(int machineId)
        {
            Machine machine = _ctx.Machines.Find(machineId);

            _ctx.Machines.Remove(machine);

            _ctx.SaveChanges();
        }

        public Machine GetById(int id)
        {
            return _ctx.Machines.Find(id);
        }

        public List<Machine> Read()
        {
            return _ctx.Machines.ToList();
        }

        public List<Machine> SearchByName(string name)
        {
            List<Machine> Machines = _ctx.Machines.ToList();

            List<Machine> MachinesWithName = new List<Machine>();

            foreach (Machine machine in Machines)
            {
                if (machine.Name.ToLower().Contains(name.ToLower()))
                {
                    MachinesWithName.Add(machine);
                }
            }

            return MachinesWithName;
        }

        public void Update(Machine machine)
        {
            _ctx.Entry(machine).State = EntityState.Modified;

            _ctx.SaveChanges();
        }

        public List<Error> VerifyCompatibility(Machine machine)
        {
            List<Error> Errors = new List<Error>();

            machine.Processor = _ctx.Processors.Include(x => x.SocketType).FirstOrDefault(x => x.Id == machine.ProcessorId);
            machine.Motherboard = _ctx.Motherboards.Include(x => x.SocketType).Include(x => x.RamMemoryType).FirstOrDefault(x => x.Id == machine.MotherboardId);
            machine.RamMemory = _ctx.RamMemories.Include(x => x.RamMemoryType).FirstOrDefault(x => x.Id == machine.RamMemoryId);
            machine.GraphicCard = _ctx.GraphicCards.Find(machine.Id);
            machine.PowerSupply = _ctx.PowerSupplies.Find(machine.PowerSupplyId);
;
            // Placa mãe
            if (machine.Motherboard != null)
            {
                Errors.Add(new Error { name = "Placa mãe", Description = "Placa mãe não encontrada" });
                return Errors;
            }

            // Processador
            if (machine.Processor == null)
            {
                Errors.Add(new Error { name = "Processador", Description = "Processador não encontrado" });
            }
            else if (machine.Processor.SocketTypeId != machine.Motherboard.SocketTypeId)
            {
                Errors.Add(new Error { name = "Processador, Placa mãe", Description = "Soquete do processador não compatível com placa mãe" });
            }
            else if (machine.Processor.Tdp > machine.Motherboard.MaxTdp)
            {
                Errors.Add(new Error { name = "Processador, Placa mãe", Description = "TDP do processador superior ao máximo da placa mãe" });
            }

            // Memoria RAM
            if (machine.RamMemory == null)
            {
                Errors.Add(new Error { name = "Memória RAM", Description = "Memórias RAM não encontradas" });
            }
            else if (machine.RamMemory.RamMemoryType != machine.Motherboard.RamMemoryType)
            {
                Errors.Add(new Error { name = "Memória RAM, Placa mãe", Description = "Tipo de memória não compatível com placa mãe" });
            }
            if (machine.RamMemoryAmount == 0)
            {
                Errors.Add(new Error { name = "Memória RAM", Description = "A máquina deve ter pelo menos uma memória RAM" });
            }
            else if (machine.RamMemoryAmount > machine.Motherboard.RamMemorySlots)
            {
                Errors.Add(new Error { name = "Memória RAM, Placa mãe", Description = "A placa mãe tem menos slots que a quantidade de memórias RAM" });
            }

            // Placa de Video
            if (machine.GraphicCard == null)
            {
                Errors.Add(new Error { name = "Placa de Vídeo", Description = "Placa de Vídeo não encontrada" });
            }
            if (machine.GraphicCardAmount == 0)
            {
                Errors.Add(new Error { name = "Placa de Vídeo", Description = "Quantidade de placas de vídeo não pode ser zero" });
            }
            else
            { 
                if (machine.GraphicCardAmount > machine.Motherboard.PciSlots)
                {
                    Errors.Add(new Error { name = "Placa de Vídeo, Placa mãe", Description = "Quantidade de slots PCI Express menor que quantidade de placas de vídeo" });
                }
                if (machine.GraphicCardAmount > 1 && machine.GraphicCard.SupportMultiGpu == false)
                {
                    Errors.Add(new Error { name = "Placa de vídeo", Description = "Placa de vídeo não suporta crossfire e contém mais de uma" });
                }
            } 

            // Armazenamento
            if (machine.MachineHasStorageDevices.Count == 0)
            {
                Errors.Add(new Error { name = "Armazenamento", Description = "É necessário no mínimo um dispositivo de armazenamento" });
            }
            else
            {
                int sata = 0;
                int m2 = 0;
                foreach (MachineHasStorageDevice storageDevice in machine.MachineHasStorageDevices)
                {
                    if (storageDevice.StorageDevice.StorageDeviceInterface)
                    {
                        m2 += storageDevice.Amount;
                    }
                    else
                    {
                        sata += storageDevice.Amount;
                    }
                }
                if (sata > machine.Motherboard.SataSlots)
                {
                    Errors.Add(new Error { name = "Sata, Placa mãe", Description = "Placa mãe não contem slots sata suficientes para os dispositivosde armazenamento tipo sata" });
                }
                if (m2 > machine.Motherboard.M2Slots)
                {
                    Errors.Add(new Error { name = "M2, Placa mãe", Description = "Placa mãe não contém slots m2 suficientes para os dispositivos de armazenamento m2" });
                }
            }

            // Fonte
            if (machine.PowerSupply.Potency < machine.GraphicCardAmount * machine.GraphicCard.MinimumPowerSupply)
            {
                Errors.Add(new Error { name = "PowerSupply", Description = "A potência da fonte de alimentação é insuficiente" });
            }

            return Errors;
        }
    }
}
