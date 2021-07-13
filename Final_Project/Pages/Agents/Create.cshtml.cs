using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Final_Project.Data;
using Final_Project.Models;

namespace Final_Project.Pages.Agents
{
    public class CreateModel : PageModel
    {
        private readonly Final_Project.Data.Final_ProjectContext _context;

        public CreateModel(Final_Project.Data.Final_ProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["SalesOfficeID"] = new SelectList(_context.Set<SalesOffice>(), "SalesOfficeId", "SalesOfficeName");
            return Page();
        }

        [BindProperty]
        public Agent Agent { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Agent.Add(Agent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
