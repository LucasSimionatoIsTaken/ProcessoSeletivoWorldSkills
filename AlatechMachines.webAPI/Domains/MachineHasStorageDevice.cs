using System;
using System.Collections.Generic;

#nullable disable

namespace AlatechMachines.webAPI.Domains
{
    public partial class MachineHasStorageDevice
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int? MachineId { get; set; }
        public int? StorageDeviceId { get; set; }

        public virtual Machine Machine { get; set; }
        public virtual StorageDevice StorageDevice { get; set; }
    }
}
