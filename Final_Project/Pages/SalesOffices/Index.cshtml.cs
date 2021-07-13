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
    public class IndexModel : PageModel
    {
        private readonly Final_Project.Data.Final_ProjectContext _context;

        public IndexModel(Final_Project.Data.Final_ProjectContext context)
        {
            _context = context;
        }

        public IList<SalesOffice> SalesOffice { get;set; }

        public async Task OnGetAsync()
        {
            SalesOffice = await _context.SalesOffice
                .Include(s => s.City).ToListAsync();
        }
    }
}
