using System;
using System.Collections.Generic;

#nullable disable

namespace AlatechMachines.webAPI.Domains
{
    public partial class StorageDevice
    {
        public StorageDevice()
        {
            MachineHasStorageDevices = new HashSet<MachineHasStorageDevice>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public bool StorageDeviceType { get; set; }
        public int Size { get; set; }
        public bool StorageDeviceInterface { get; set; }
        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual ICollection<MachineHasStorageDevice> MachineHasStorageDevices { get; set; }
    }
}
