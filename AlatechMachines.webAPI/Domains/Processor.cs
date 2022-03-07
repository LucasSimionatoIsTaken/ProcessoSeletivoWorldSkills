using System;
using System.Collections.Generic;

#nullable disable

namespace AlatechMachines.webAPI.Domains
{
    public partial class Processor
    {
        public Processor()
        {
            Machines = new HashSet<Machine>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Cores { get; set; }
        public double BaseFrequency { get; set; }
        public double MaxFrequency { get; set; }
        public double CacheMemory { get; set; }
        public int Tdp { get; set; }
        public int SocketTypeId { get; set; }
        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual SocketType SocketType { get; set; }
        public virtual ICollection<Machine> Machines { get; set; }
    }
}
