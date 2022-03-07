using AlatechMachines.webAPI.Domains;
using System.Collections.Generic;

namespace AlatechMachines.webAPI.Interfaces
{
    public interface IMotherboardRepository
    {
        /// <summary>
        /// List all motherboards
        /// </summary>
        /// <returns>Motherboards list</returns>
        List<Motherboard> Read();

        /// <summary>
        /// Get a motherboard by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Motherboard or null</returns>
        Motherboard GetById(int id);

        /// <summary>
        /// Search motherboards by name
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>Motherboards list</returns>
        List<Motherboard> SearchByName(string name);
    }
}
