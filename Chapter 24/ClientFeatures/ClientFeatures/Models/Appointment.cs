using System;
using System.ComponentModel.DataAnnotations;

namespace ClientFeatures.Models {
    public class Appointment {

        [Required]
        public string ClientName { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public bool TermsAccepted { get; set; }
    }
}
