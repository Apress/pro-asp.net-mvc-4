using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheMVCPattern.Models {
    public class Member {
        public string LoginName { get; set; } // The unique key
        public int ReputationPoints { get; set; }
    }
}