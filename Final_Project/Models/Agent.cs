using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Models
{
    public class Agent
    {
        public int AgentId { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(20, ErrorMessage = "Please enter a valid first name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(20, ErrorMessage = "Please enter a valid last name")]
        public string LastName { get; set; }

        [DisplayName("Full Name")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        [DisplayName("Dwellings")]
        public List<Dwelling> Dwellings { get; set; }

        [DisplayName("Sales Office")]
        public SalesOffice SalesOffice { get; set; }
        public int SalesOfficeId { get; set; }

        [DisplayName("Number of Dwellings")]
        public int numHomes
        {
            get
            {
                int homes = 0;
                foreach (var item in Dwellings)
                {
                    homes++;
                }
                int numHomes = homes;
                return numHomes;
            }

        }

    }
}
