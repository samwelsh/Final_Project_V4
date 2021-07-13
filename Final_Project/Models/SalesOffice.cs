using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Models
{
    public class SalesOffice
    {
        public int SalesOfficeId { get; set; }
        [DisplayName("Agents")]
        public List<Agent> Agents { get; set; }

        [DisplayName("Location")]
        public City City { get; set; }
        public int CityId { get; set; }

        [DisplayName("Sales Office Name")]
        public string SalesOfficeName { get; set; }

        [DisplayName("Number of Dwellings")]
        public int numAgents
        {
            get
            {
                if (Agents == null)
                {
                    return 0;
                }
                int agentcount = 0;
                foreach (var item in Agents)
                {
                    agentcount++;
                }
                int numAgents = agentcount;
                return numAgents;
            }

        }
    }
}
