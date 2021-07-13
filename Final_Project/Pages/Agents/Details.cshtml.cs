using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Final_Project.Data;
using Final_Project.Models;

namespace Final_Project.Pages.Agents
{
    public class DetailsModel : PageModel
    {
        private readonly Final_Project.Data.Final_ProjectContext _context;

        public DetailsModel(Final_Project.Data.Final_ProjectContext context)
        {
            _context = context;
        }

        public Agent Agent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Agent = await _context.Agent
                .Include(a => a.Dwellings).Include(b => b.SalesOffice).FirstOrDefaultAsync(m => m.AgentId == id);

            if (Agent == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
