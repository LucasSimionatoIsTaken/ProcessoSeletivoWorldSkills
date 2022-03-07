using AlatechMachines.webAPI.Domains;
using System.Collections.Generic;

namespace AlatechMachines.webAPI.Interfaces
{
    public interface IProcessorRepository
    {
        /// <summary>
        /// List all processors
        /// </summary>
        /// <returns>Processors list</returns>
        List<Processor> Read();

        /// <summary>
        /// Get a processor by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Processor or null</returns>
        Processor GetById(int id);

        /// <summary>
        /// Search processors by name
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>processors list</returns>
        List<Processor> SearchByName(string name);
    }
}
