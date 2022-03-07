using AlatechMachines.webAPI.Contexts;
using AlatechMachines.webAPI.Domains;
using AlatechMachines.webAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AlatechMachines.webAPI.Repositories
{
    public class StorageDeviceRepository : IStorageDeviceRepository
    {
        private readonly AlatechDbContext _ctx = new AlatechDbContext();
        public StorageDevice GetById(int id)
        {
            return _ctx.StorageDevices.Find(id);
        }

        public List<StorageDevice> Read()
        {
            return _ctx.StorageDevices.ToList();
        }

        public List<StorageDevice> SearchByName(string name)
        {
            List<StorageDevice> StorageDevices = _ctx.StorageDevices.ToList();

            List<StorageDevice> StorageDevicesWithName = new List<StorageDevice>();

            foreach (StorageDevice storageDevice in StorageDevices)
            {
                if (storageDevice.Name.ToLower().Contains(name.ToLower()))
                {
                    StorageDevicesWithName.Add(storageDevice);
                }
            }

            return StorageDevicesWithName;
        }
    }
}
