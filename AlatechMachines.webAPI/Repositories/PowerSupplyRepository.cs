using AlatechMachines.webAPI.Contexts;
using AlatechMachines.webAPI.Domains;
using AlatechMachines.webAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AlatechMachines.webAPI.Repositories
{
    public class PowerSupplyRepository : IPowerSupplyRepository
    {
        private readonly AlatechDbContext _ctx = new AlatechDbContext();
        public PowerSupply GetById(int id)
        {
            return _ctx.PowerSupplies.Find(id);
        }

        public List<PowerSupply> Read()
        {
            return _ctx.PowerSupplies.Include(x => x.Badge80Plus).ToList();
        }

        public List<PowerSupply> SearchByName(string name)
        {
            List<PowerSupply> PowerSupplies = _ctx.PowerSupplies.ToList();

            List<PowerSupply> PowerSuppliesWithName = new List<PowerSupply>();

            foreach (PowerSupply powerSupply in PowerSupplies)
            {
                if (powerSupply.Name.ToLower().Contains(name.ToLower()))
                {
                    PowerSuppliesWithName.Add(powerSupply);
                }
            }

            return PowerSuppliesWithName;
        }
    }
}
