
namespace LowFlix.Pages.Customers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using LowFlix.Core.Domain.Entities;
    using LowFlix.Core.Interfaces.Data;

    public class IndexModel : PageModel
    {
        private readonly IDbContextFactory contextFactory;

        public IndexModel(IDbContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        [BindProperty]
        public IReadOnlyList<Customer> Customers { get; set; }

        public IActionResult OnGet()
        {

            using var context = this.contextFactory.CreateReadOnlyContext();
            this.Customers = context.Customers.ToList();

            return this.Page();

        }

        public string getDate(DateTime date)
        {
            string formattedDate = date.ToString("dd.MM.yyyy");

            return formattedDate;
        }

    }
}
