using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SearchFilghts.Assignment.Models
{
    public class SearchFlightModel
    {
        [Required]
        [StringLength(3)]
        public string Origin { get; set; }
        public DateTime DepartureTime { get; set; }
        [Required]
        [StringLength(3)]
        public string Destination { get; set; }
        public DateTime DestinationTime { get; set; }
        public float Price { get; set; }
    }
}