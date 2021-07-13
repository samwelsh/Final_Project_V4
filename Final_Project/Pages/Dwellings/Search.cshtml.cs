using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Final_Project.Data;
using Final_Project.Models;

namespace Final_Project.Pages.Dwellings
{
    public class SearchModel : PageModel
    {
        private readonly Final_Project.Data.Final_ProjectContext _context;

        public SearchModel(Final_Project.Data.Final_ProjectContext context)
        {
            _context = context;
        }

        public IList<Dwelling> Dwelling { get;set; }
        public bool SearchCompleted { get; set; }
        public string Query { get; set; }

        public async Task OnGetAsync(string query)
        {
            Query = query;
            if (!string.IsNullOrWhiteSpace(query))
            {
                SearchCompleted = true;
                Dwelling = await _context.Dwelling
                .Include(d => d.Agent)
                .Include(d => d.City).Where(x => x.City.Name.Equals(query)).ToListAsync();
            }
            else
            {
                SearchCompleted = false;
                Dwelling = new List<Dwelling>();
            }
            
        }
    }
}
