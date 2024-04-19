
namespace LowFlix.Pages.Customers
{
    using System;
    using System.Linq;
    using LowFlix.Core.Domain.Entities;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using LowFlix.Core.Interfaces.Data;

    public class CreateModel : PageModel
    {

        private readonly IDbContextFactory contextFactory;
        public CreateModel(IDbContextFactory contextFactory)
        {

            this.contextFactory = contextFactory;
        }

        [BindProperty]
        public CustomerCreateModel Customer { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            try
            {
                using (var context = contextFactory.CreateContext())
                {
                    var newCustomer = new Customer
                    {
                        FirstName = Customer.FirstName,
                        LastName = Customer.LastName,
                        CustomerNumber = Customer.CustomerNumber,
                        BirthdayDate = Customer.BirthdayDate,
                        PhoneNumber = Customer.PhoneNumber
                    };

                    context.Customers.Add(newCustomer);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return RedirectToPage("/Error");
            }

            return RedirectToPage("./Index");
        }

    }

    public class CustomerCreateModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long CustomerNumber { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string PhoneNumber { get; set; }
    }
}
