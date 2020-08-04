﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vetreg.Models {
    public class Disease {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
