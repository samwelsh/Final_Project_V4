using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Final_Project.Data;
using Final_Project.Models;

namespace Final_Project.Pages.Dwellings
{
    public class EditModel : PageModel
    {
        private readonly Final_Project.Data.Final_ProjectContext _context;

        public EditModel(Final_Project.Data.Final_ProjectContext context)
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
           ViewData["AgentId"] = new SelectList(_context.Agent, "AgentId", "FirstName");
           ViewData["CityId"] = new SelectList(_context.City, "CityId", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Dwelling).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DwellingExists(Dwelling.DwellingId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DwellingExists(int id)
        {
            return _context.Dwelling.Any(e => e.DwellingId == id);
        }
    }
}
