using AlatechMachines.webAPI.Domains;
using System.Collections.Generic;

namespace AlatechMachines.webAPI.Interfaces
{
    public interface IRamMemoryRepository
    {
        /// <summary>
        /// List all RamMemories
        /// </summary>
        /// <returns>RamMemories list</returns>
        List<RamMemory> Read();

        /// <summary>
        /// Get a ramMemory by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>RamMemory or null</returns>
        RamMemory GetById(int id);

        /// <summary>
        /// Search ramMemories by name
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>RamMemories list</returns>
        List<RamMemory> SearchByName(string name);
    }
}
