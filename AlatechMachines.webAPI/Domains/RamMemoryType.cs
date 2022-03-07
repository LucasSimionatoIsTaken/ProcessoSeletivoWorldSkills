using System;
using System.Collections.Generic;

#nullable disable

namespace AlatechMachines.webAPI.Domains
{
    public partial class RamMemoryType
    {
        public RamMemoryType()
        {
            Motherboards = new HashSet<Motherboard>();
            RamMemories = new HashSet<RamMemory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Motherboard> Motherboards { get; set; }
        public virtual ICollection<RamMemory> RamMemories { get; set; }
    }
}
