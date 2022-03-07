using AlatechMachines.webAPI.Contexts;
using AlatechMachines.webAPI.Domains;
using AlatechMachines.webAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AlatechMachines.webAPI.Repositories
{
    public class MotherboardRepository : IMotherboardRepository
    {
        private readonly AlatechDbContext _ctx = new AlatechDbContext();
        public Motherboard GetById(int id)
        {
            return _ctx.Motherboards.Find(id);
        }

        public List<Motherboard> Read()
        {
            return _ctx.Motherboards.ToList();
        }

        public List<Motherboard> SearchByName(string name)
        {
            List<Motherboard> Motherboards = _ctx.Motherboards.ToList();

            List<Motherboard> MotherboardsWithName = new List<Motherboard>();

            foreach (Motherboard motherboard in Motherboards)
            {
                if (motherboard.Name.ToLower().Contains(name.ToLower()))
                {
                    MotherboardsWithName.Add(motherboard);
                }
            }

            return MotherboardsWithName;
        }
    }
}
