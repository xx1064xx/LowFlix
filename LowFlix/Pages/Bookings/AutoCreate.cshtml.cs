using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LowFlix.Pages.Bookings
{
    using System;
    using System.Collections.Generic;
    using System.Net.Mail;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using LowFlix.Core.Domain.Entities;
    using LowFlix.Core.Interfaces.Data;
    using System.Text;
    using Microsoft.Extensions.Configuration;
    using LowFlix.Pages.Films;

    public class AutoCreateModel : PageModel
    {
        private readonly IDbContextFactory contextFactory;

        public AutoCreateModel(IDbContextFactory contextFactory, IConfiguration configuration)
        {
            this.contextFactory = contextFactory;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        [BindProperty]
        public List<FilmCopyBookingStart> FilmCopies { get; set; } = new List<FilmCopyBookingStart>();

        public void OnGet(long number)
        {

            using var context = this.contextFactory.CreateReadOnlyContext();
            this.Customer = context.Customers
                .Where(m => m.CustomerNumber == number)
                .Select(x => new Customer
                {
                    CustomerId = x.CustomerId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    CustomerNumber = x.CustomerNumber,

                })
                .FirstOrDefault();

        }

        public IActionResult OnPost()
        {

          
            using var context = this.contextFactory.CreateContext();

            try
            {

                var newBooking = new Booking
                {
                    CustomerId = this.Customer.CustomerId,
                    RentalDate = DateTime.Now,
                };

                context.Bookings.Add(newBooking);

                context.SaveChanges();

                foreach (var filmcopy in  FilmCopies)
                {
                    var filmcopyFromDb = context.FilmCopies.FirstOrDefault(x => x.FilmNumber == long.Parse(filmcopy.FilmCopyNumber));

                    if (filmcopyFromDb == null)
                    {
                        return this.NotFound();
                    }

                    filmcopyFromDb.BookingId = newBooking.BookingId;

                    context.SaveChanges();

                }


            }
            catch (Exception)
            {
                return this.RedirectToPage("/Error");
            }

            return this.RedirectToPage("./Index");

        }

        public IActionResult OnGetFilmCopyList()
        {

            using (var context = contextFactory.CreateReadOnlyContext())
            {
                var FilmCopyList = context.FilmCopies
                    .Where(a => a.BookingId == null)
                    .Select(a =>
                        new FilmCopy
                        {
                            FilmCopyId = a.FilmCopyId,
                            FilmNumber = a.FilmNumber,
                            FilmId = a.FilmId,
                        })
                    .ToList();

                return new JsonResult(FilmCopyList);
            }
        }



    }

    public class FilmCopyBookingStart
    {
        public string FilmCopyNumber { get; set; }
    }
}
