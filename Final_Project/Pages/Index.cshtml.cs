using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Project.Models;
using Final_Project.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SQLitePCL;

namespace Final_Project.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public Agent Agent { get; set; }
        public Dwelling Dwelling { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }


        public void OnGet()
        {

        }
    }
}
