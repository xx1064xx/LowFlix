using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LowFlix.Pages
{
    using LowFlix.Core.Domain.Entities;
    using LowFlix.Core.Interfaces.Data;
    using Microsoft.EntityFrameworkCore;

    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IDbContextFactory contextFactory;

        public IndexModel(ILogger<IndexModel> logger, IDbContextFactory contextFactory)
        {
            _logger = logger;
            this.contextFactory = contextFactory;
        }

        [BindProperty]  
        public Customer Customer { get; set; }

        public IReadOnlyList<Booking> Bookings { get; set; }

        public IActionResult OnGet()
        {
            using (var context = this.contextFactory.CreateReadOnlyContext())
            {
                
                var cutoffDate = DateTime.Now.AddDays(-7);

                this.Bookings = context.Bookings
                    .Where(x => x.RentalDate < cutoffDate)
                    .Include(x => x.Customer)
                    .ToList();
            }
            return this.Page();
        }

        public IActionResult OnPost()
        {

            return this.RedirectToPage("./Bookings/AutoCreate", new { number = Customer.CustomerNumber });
        }

        public string getDate(DateTime? dateTime)
        {
            if (dateTime.HasValue)
            {
                return dateTime.Value.ToString("dd.MM.yyyy");
            }
            else
            {
                return null;
            }
        }
    }
}
