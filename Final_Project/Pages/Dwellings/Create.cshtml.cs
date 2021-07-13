using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Final_Project.Data;
using Final_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Final_Project.Pages.Dwellings
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
        ViewData["AgentId"] = new SelectList(_context.Agent, "AgentId", "FirstName");
        ViewData["CityId"] = new SelectList(_context.City, "CityId", "Name");
            return Page();
        }

        [BindProperty]
        public Dwelling Dwelling { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // PRICE RANGE VALIDATION
            var minPrice = 100000;
            var maxPrice = 10000000;
            var actualPrice = Dwelling.Price;
            if (actualPrice < minPrice)
            {
                ModelState.AddModelError("Dwelling.Price", "This dwelling is not within our agent's price range");
            }

            if (actualPrice > maxPrice)
            {
                ModelState.AddModelError("Dwelling.Price", "This dwelling is not within our agent's price range");
            }
            // ADDRESS VALIDATION
            var DwellingAddress = Dwelling.Address;
            bool addressExists = await _context.Dwelling.AnyAsync(x => x.Address == DwellingAddress);

            if (addressExists)
            {
                ModelState.AddModelError("Dwelling.Address", "This address already exists");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Dwelling.Add(Dwelling);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

