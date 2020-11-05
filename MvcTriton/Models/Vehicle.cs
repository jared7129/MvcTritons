using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcTriton.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required]
        public string Make { get; set; }
        
        [Required]
        public string Model {get; set; }
        
        [Required]
        public string Mileage {get; set ;}
        
        [Required]
        public string Description {get; set; }
        
        public virtual ICollection<Branch> Branches { get; set; }

        public virtual ICollection<Waybill> Waybills { get; set; }

    }
}