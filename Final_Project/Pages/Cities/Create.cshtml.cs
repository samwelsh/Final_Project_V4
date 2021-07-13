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

namespace Final_Project.Pages.Cities
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
            return Page();
        }

        [BindProperty]
        public City City { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // ADDRESS VALIDATION
            var CityZip = City.Zip;
            bool zipExists = await _context.City.AnyAsync(x => x.Zip == CityZip);

            if (zipExists)
            {
                ModelState.AddModelError("Dwelling.Address, Dwelling.Zip", "This address already exists");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.City.Add(City);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
