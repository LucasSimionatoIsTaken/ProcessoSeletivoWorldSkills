using AlatechMachines.webAPI.Domains;
using AlatechMachines.webAPI.Response;
using System.Collections.Generic;

namespace AlatechMachines.webAPI.Interfaces
{
    public interface IMachineRepository
    {
        /// <summary>
        /// Create a machine
        /// </summary>
        /// <param name="machine">Machine</param>
        /// <returns>Machine id</returns>
        int Create(Machine machine);

        /// <summary>
        /// List all Machines
        /// </summary>
        /// <returns>Machines list</returns>
        List<Machine> Read();

        /// <summary>
        /// Update a machine
        /// </summary>
        /// <param name="machine">Machine</param>
        void Update(Machine machine);

        /// <summary>
        /// Deletes a machine
        /// </summary>
        /// <param name="machineId">Machine id</param>
        void Delete(int machineId);

        /// <summary>
        /// Get a machine by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Machine or null</returns>
        Machine GetById(int id);

        /// <summary>
        /// Search Machines by name
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>Machines list</returns>
        List<Machine> SearchByName(string name);

        /// <summary>
        /// Verify if machine is compatible
        /// </summary>
        /// <param name="machine">machine</param>
        /// <returns>Errors list or null</returns>
        List<Error> VerifyCompatibility(Machine machine);
    }
}
