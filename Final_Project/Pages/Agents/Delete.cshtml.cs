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
    public class DeleteModel : PageModel
    {
        private readonly Final_Project.Data.Final_ProjectContext _context;

        public DeleteModel(Final_Project.Data.Final_ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Agent Agent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Agent = await _context.Agent
                .Include(a => a.SalesOffice).FirstOrDefaultAsync(m => m.AgentId == id);

            if (Agent == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Agent = await _context.Agent.FindAsync(id);

            if (Agent != null)
            {
                _context.Agent.Remove(Agent);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
