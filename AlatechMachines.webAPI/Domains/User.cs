﻿using System;
using System.Collections.Generic;

#nullable disable

namespace AlatechMachines.webAPI.Domains
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AccessToken { get; set; }
    }
}
