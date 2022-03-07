using System;
using System.Collections.Generic;

#nullable disable

namespace AlatechMachines.webAPI.Domains
{
    public partial class SocketType
    {
        public SocketType()
        {
            Motherboards = new HashSet<Motherboard>();
            Processors = new HashSet<Processor>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Motherboard> Motherboards { get; set; }
        public virtual ICollection<Processor> Processors { get; set; }
    }
}
