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
    public class DeleteModel : PageModel
    {
        private readonly Final_Project.Data.Final_ProjectContext _context;

        public DeleteModel(Final_Project.Data.Final_ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dwelling Dwelling { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dwelling = await _context.Dwelling
                .Include(d => d.Agent)
                .Include(d => d.City).FirstOrDefaultAsync(m => m.DwellingId == id);

            if (Dwelling == null)
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

            Dwelling = await _context.Dwelling.FindAsync(id);

            if (Dwelling != null)
            {
                _context.Dwelling.Remove(Dwelling);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
