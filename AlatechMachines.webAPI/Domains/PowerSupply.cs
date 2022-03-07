﻿using System;
using System.Collections.Generic;

#nullable disable

namespace AlatechMachines.webAPI.Domains
{
    public partial class PowerSupply
    {
        public PowerSupply()
        {
            Machines = new HashSet<Machine>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Potency { get; set; }
        public int Badge80PlusId { get; set; }
        public int BrandId { get; set; }

        public virtual Badge80Plu Badge80Plus { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual ICollection<Machine> Machines { get; set; }
    }
}
