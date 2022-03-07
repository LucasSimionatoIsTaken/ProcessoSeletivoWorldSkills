using AlatechMachines.webAPI.Contexts;
using AlatechMachines.webAPI.Domains;
using AlatechMachines.webAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AlatechMachines.webAPI.Repositories
{
    public class RamMemoryRepository : IRamMemoryRepository
    {
        private readonly AlatechDbContext _ctx = new AlatechDbContext();
        public RamMemory GetById(int id)
        {
            return _ctx.RamMemories.Find(id);
        }

        public List<RamMemory> Read()
        {
            return _ctx.RamMemories.ToList();
        }

        public List<RamMemory> SearchByName(string name)
        {
            List<RamMemory> RamMemories = _ctx.RamMemories.ToList();

            List<RamMemory> RamMemoriesWithName = new List<RamMemory>();

            foreach (RamMemory ramMemory in RamMemories)
            {
                if (ramMemory.Name.ToLower().Contains(name.ToLower()))
                {
                    RamMemoriesWithName.Add(ramMemory);
                }
            }

            return RamMemoriesWithName;
        }
    }
}
