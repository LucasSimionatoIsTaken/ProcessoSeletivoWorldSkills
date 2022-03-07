using System;
using System.Collections.Generic;

#nullable disable

namespace AlatechMachines.webAPI.Domains
{
    public partial class GraphicCard
    {
        public GraphicCard()
        {
            Machines = new HashSet<Machine>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int MemorySize { get; set; }
        public bool MemoryType { get; set; }
        public int MinimumPowerSupply { get; set; }
        public bool SupportMultiGpu { get; set; }
        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual ICollection<Machine> Machines { get; set; }
    }
}
