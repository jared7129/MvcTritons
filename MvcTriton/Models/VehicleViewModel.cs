using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MvcTriton.Models;

namespace MvcTriton.Models
{
    public class MovieGenreViewModel
    {
        public List<Vehicle> Vehicles { get; set; }
        public SelectList Models { get; set; }
        public string VehicleModels { get; set; }
        public string SearchString { get; set; }
    }
}