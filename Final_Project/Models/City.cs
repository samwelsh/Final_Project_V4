using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Models
{
    public class City
    {
        public int CityId { get; set; }
        [DisplayName("City")]
        [Required(ErrorMessage = "City is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Please enter a valid city name")]


        public string Name { get; set; }
        [DisplayName("State")]
        [Required(ErrorMessage = "State is required")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Please enter a valid state abbreviation")]


        public string State { get; set; }
        [DisplayName("Zip Code")]

        public int Zip { get; set; }
        [DisplayName("Dwellings")]
        public List<Dwelling>? Dwellings { get; set; }
       // public int DwellingId { get; set; }

        [DisplayName("Sales Offices")]
        public List<SalesOffice> SalesOffices { get; set; }

        [DisplayName("Number of Dwellings")]
        public int numDwellings
        {
            get
            {
                if (Dwellings == null)
                {
                    return 0;
                }
                int dwell = 0;
                foreach (var item in Dwellings)
                {
                    dwell++;
                }
                int numDwellings = dwell;
                return numDwellings;
            }

        }

    }
}
