using AlatechMachines.webAPI.Contexts;
using AlatechMachines.webAPI.Domains;
using AlatechMachines.webAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AlatechMachines.webAPI.Repositories
{
    public class ProcessorRepository : IProcessorRepository
    {
        private readonly AlatechDbContext _ctx = new AlatechDbContext();
        public Processor GetById(int id)
        {
            return _ctx.Processors.Find(id);
        }

        public List<Processor> Read()
        {
            return _ctx.Processors.ToList();
        }

        public List<Processor> SearchByName(string name)
        {
            List<Processor> Processors = _ctx.Processors.ToList();

            List<Processor> ProcessorsWithName = new List<Processor>();

            foreach (Processor processor in Processors)
            {
                if (processor.Name.ToLower().Contains(name.ToLower()))
                {
                    ProcessorsWithName.Add(processor);
                }
            }

            return ProcessorsWithName;
        }
    }
}
