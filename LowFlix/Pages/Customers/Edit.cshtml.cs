using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LowFlix.Pages.Customers
{
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using LowFlix.Core.Interfaces.Data;
    using LowFlix.Core.Domain.Entities;
    public class EditModel : PageModel
    {
        private readonly IDbContextFactory contextFactory;

        public EditModel(IDbContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        [BindProperty]
        public CustomerEditModel? Customer { get; set; }

        public IActionResult OnGet(Guid? id)
        {

            if (id == null)
            {
                return this.BadRequest();
            }

            using var context = this.contextFactory.CreateReadOnlyContext();
            this.Customer = context.Customers
                .Where(m => m.CustomerId == id)
                .Select(x => new CustomerEditModel
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
            if (!this.ModelState.IsValid)
            {
                return this.Page();
            }

            using var context = this.contextFactory.CreateContext();
            var customer = context.Customers.FirstOrDefault(x => x.CustomerId == this.Customer.CustomerId);
            if (customer == null)
            {
                return this.NotFound();
            }

            try
            {
                customer.FirstName = this.Customer.FirstName;
                customer.LastName = this.Customer.LastName;
                customer.BirthdayDate = this.Customer.BirthdayDate;
                customer.PhoneNumber = this.Customer.PhoneNumber;

                context.SaveChanges();
            }
            catch (Exception)
            {
                return this.RedirectToPage("/Error");
            }

            return this.RedirectToPage("./Index");
        }
    }

    public class CustomerEditModel
    {
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthdayDate { get; set;}
        public string PhoneNumber { get; set; }
    }

}
