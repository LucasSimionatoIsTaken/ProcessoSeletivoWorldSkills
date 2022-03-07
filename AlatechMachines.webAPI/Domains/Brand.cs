using System;
using System.Collections.Generic;

#nullable disable

namespace AlatechMachines.webAPI.Domains
{
    public partial class Brand
    {
        public Brand()
        {
            GraphicCards = new HashSet<GraphicCard>();
            Motherboards = new HashSet<Motherboard>();
            PowerSupplies = new HashSet<PowerSupply>();
            Processors = new HashSet<Processor>();
            RamMemories = new HashSet<RamMemory>();
            StorageDevices = new HashSet<StorageDevice>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<GraphicCard> GraphicCards { get; set; }
        public virtual ICollection<Motherboard> Motherboards { get; set; }
        public virtual ICollection<PowerSupply> PowerSupplies { get; set; }
        public virtual ICollection<Processor> Processors { get; set; }
        public virtual ICollection<RamMemory> RamMemories { get; set; }
        public virtual ICollection<StorageDevice> StorageDevices { get; set; }
    }
}
