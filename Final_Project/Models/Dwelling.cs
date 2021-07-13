using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Models
{
    public class Dwelling
    {
        [DisplayName("Dwelling ID")]
        public int DwellingId { get; set; }

        [DisplayName("Street Address")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Please enter a valid type of dwelling")]
        public string Address { get; set; }

        [DisplayName("City")]
        public City City { get; set; }
        public int CityId { get; set; }

        [DisplayName("ZIP Code")]
        public int Zip { get; set; }

        [DisplayName("Type")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Please enter a valid type of dwelling")]
        public string Type { get; set; }
       
        [DisplayName("Agent")]
        public Agent Agent { get; set; }
        public int AgentId { get; set; }

        [DisplayName("Price")]
        public int Price { get; set; }
    }
}
