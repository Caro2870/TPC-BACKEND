﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Resources
{
    public class CoordinatorResource : UserResource
    {
        public FacultyResource Faculty { get; set; }
    }
}
