using AlatechMachines.webAPI.Domains;
using System.Collections.Generic;

namespace AlatechMachines.webAPI.Interfaces
{
    public interface IStorageDeviceRepository
    {
        /// <summary>
        /// List all storageDevices
        /// </summary>
        /// <returns>StorageDevices list</returns>
        List<StorageDevice> Read();

        /// <summary>
        /// Get a storageDevice by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>StorageDevice or null</returns>
        StorageDevice GetById(int id);

        /// <summary>
        /// Search storageDevices by name
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>StorageDevices list</returns>
        List<StorageDevice> SearchByName(string name);
    }
}
