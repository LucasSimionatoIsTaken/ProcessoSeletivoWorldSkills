using System;
using System.Collections.Generic;

#nullable disable

namespace AlatechMachines.webAPI.Domains
{
    public partial class Machine
    {
        public Machine()
        {
            MachineHasStorageDevices = new HashSet<MachineHasStorageDevice>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int RamMemoryAmount { get; set; }
        public int GraphicCardAmount { get; set; }
        public int MotherboardId { get; set; }
        public int ProcessorId { get; set; }
        public int RamMemoryId { get; set; }
        public int GraphicCardId { get; set; }
        public int PowerSupplyId { get; set; }

        public virtual GraphicCard GraphicCard { get; set; }
        public virtual Motherboard Motherboard { get; set; }
        public virtual PowerSupply PowerSupply { get; set; }
        public virtual Processor Processor { get; set; }
        public virtual RamMemory RamMemory { get; set; }
        public virtual ICollection<MachineHasStorageDevice> MachineHasStorageDevices { get; set; }
    }
}
