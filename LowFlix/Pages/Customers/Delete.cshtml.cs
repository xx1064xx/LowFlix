
namespace LowFlix.Pages.Customers
{
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using LowFlix.Core.Domain.Entities;
    using LowFlix.Core.Interfaces.Data;
    public class DeleteModel : PageModel
    {

        private readonly IDbContextFactory contextFactory;

        public DeleteModel(IDbContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        [BindProperty]
        public CustomerDeleteModel? Customer { get; set; }

        public IActionResult OnGet(Guid? id)
        {
            if (id == null)
            {
                return this.BadRequest();
            }

            using var context = this.contextFactory.CreateReadOnlyContext();
            this.Customer = context.Customers
                .Where(m => m.CustomerId == id)
                .Select(x => new CustomerDeleteModel
                {
                    CustomerId = x.CustomerId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    BirthdayDate = x.BirthdayDate,
                    PhoneNumber = x.PhoneNumber

                })
                .FirstOrDefault();

            if (this.Customer == null)
            {
                return this.NotFound();
            }

            return this.Page();
        }

        public IActionResult OnPost()
        {
            if (Customer == null)
            {
                return BadRequest();
            }

            using (var context = contextFactory.CreateContext())
            {
                var CustomerToDelete = context.Customers.FirstOrDefault(x => x.CustomerId == Customer.CustomerId);
                if (CustomerToDelete == null)
                {
                    return NotFound();
                }

                context.Customers.Remove(CustomerToDelete);
                context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }

        public string getDate(DateTime dateTime)
        {
            return dateTime.ToString("dd.MM.yyyy");
        }
    }

    public class CustomerDeleteModel
    {
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string PhoneNumber { get; set; }
    }
}
