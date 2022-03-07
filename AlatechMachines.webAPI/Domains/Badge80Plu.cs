using System;
using System.Collections.Generic;

#nullable disable

namespace AlatechMachines.webAPI.Domains
{
    public partial class Badge80Plu
    {
        public Badge80Plu()
        {
            PowerSupplies = new HashSet<PowerSupply>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PowerSupply> PowerSupplies { get; set; }
    }
}
