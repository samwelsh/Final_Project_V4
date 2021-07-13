using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Final_Project.Data;
using Final_Project.Models;

namespace Final_Project.Pages.SalesOffices
{
    public class DetailsModel : PageModel
    {
        private readonly Final_Project.Data.Final_ProjectContext _context;

        public DetailsModel(Final_Project.Data.Final_ProjectContext context)
        {
            _context = context;
        }

        public SalesOffice SalesOffice { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SalesOffice = await _context.SalesOffice
                .Include(s => s.City).Include(x => x.Agents).FirstOrDefaultAsync(m => m.SalesOfficeId == id);

            if (SalesOffice == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
