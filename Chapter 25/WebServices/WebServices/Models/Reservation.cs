﻿using System.ComponentModel.DataAnnotations;

namespace WebServices.Models {
    public class Reservation {

        public int ReservationId { get; set; }

        public string ClientName { get; set; }

        public string Location { get; set; }    
    }
}