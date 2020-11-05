using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcTriton.Models
{
    public class Waybill
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Required]
         
        [Display(Name = "Customer Address")]
        public string CustomerAddress {get; set; }




        [Required]
        [Display(Name = "Customer Number")]
        public string CustomerNumber {get; set ;}

        [Required]
        [Display(Name = "Total Weight")]
        public int TotalWeight {get; set; }
        
        [Required]
        [Display(Name = "Number of Parcels")]
        public int NoParcels {get; set; }
        
        [Required]
        [Display(Name = "Total Value")]
        public decimal TotalValue {get; set; }

    }
}