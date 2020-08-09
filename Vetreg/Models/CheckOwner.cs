using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vetreg.Models {
    public class CheckOwner {
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public TypeOwner TypeOwner { get; set; }
        public bool IsChected { get; set; }
    }
}
