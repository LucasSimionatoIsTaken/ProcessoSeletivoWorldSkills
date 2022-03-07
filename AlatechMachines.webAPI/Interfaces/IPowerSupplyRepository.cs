using AlatechMachines.webAPI.Domains;
using System.Collections.Generic;

namespace AlatechMachines.webAPI.Interfaces
{
    public interface IPowerSupplyRepository
    {
        /// <summary>
        /// List all PowerSupplies
        /// </summary>
        /// <returns>PowerSupplies list</returns>
        List<PowerSupply> Read();

        /// <summary>
        /// Get a powerSupply by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>PowerSupply or null</returns>
        PowerSupply GetById(int id);

        /// <summary>
        /// Search PowerSupplies by name
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>PowerSupplies list</returns>
        List<PowerSupply> SearchByName(string name);
    }
}
