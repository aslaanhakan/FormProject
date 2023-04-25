﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormProject.Entity.Concrate.Identity
{
    public class User: IdentityUser
    {
        public List<Form> Forms { get; set; }
    }
}
