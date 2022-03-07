using System;
using System.Collections.Generic;

#nullable disable

namespace AlatechMachines.webAPI.Domains
{
    public partial class RamMemory
    {
        public RamMemory()
        {
            Machines = new HashSet<Machine>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Size { get; set; }
        public double Frequency { get; set; }
        public int RamMemoryTypeId { get; set; }
        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual RamMemoryType RamMemoryType { get; set; }
        public virtual ICollection<Machine> Machines { get; set; }
    }
}
