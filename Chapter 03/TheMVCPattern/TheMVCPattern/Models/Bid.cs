using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheMVCPattern.Models {
    public class Bid {
        public Member Member { get; set; }
        public DateTime DatePlaced { get; set; }
        public decimal BidAmount { get; set; }
    }
}