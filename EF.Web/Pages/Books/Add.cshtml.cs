using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EF.Web.Pages.Books
{
    public class Add : PageModel
    {
        private readonly ILogger<Add> _logger;

        public AddBookViewModel AddBookRequest { get; set; }

        public Add(ILogger<Add> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}