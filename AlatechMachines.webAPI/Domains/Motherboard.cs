using System;
using System.Collections.Generic;

#nullable disable

namespace AlatechMachines.webAPI.Domains
{
    public partial class Motherboard
    {
        public Motherboard()
        {
            Machines = new HashSet<Machine>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int RamMemorySlots { get; set; }
        public int MaxTdp { get; set; }
        public int SataSlots { get; set; }
        public int M2Slots { get; set; }
        public int PciSlots { get; set; }
        public int RamMemoryTypeId { get; set; }
        public int SocketTypeId { get; set; }
        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual RamMemoryType RamMemoryType { get; set; }
        public virtual SocketType SocketType { get; set; }
        public virtual ICollection<Machine> Machines { get; set; }
    }
}
