
namespace LowFlix.Pages.Bookings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using LowFlix.Core.Domain.Entities;
    using LowFlix.Core.Interfaces.Data;
    using Microsoft.EntityFrameworkCore;

    public class DeleteModel : PageModel
    {

        private readonly IDbContextFactory contextFactory;

        public DeleteModel(IDbContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        [BindProperty]
        public BookingDeleteModel Booking { get; set; }

        public IActionResult OnGet(Guid? id)
        {
            if (id == null)
            {
                return this.BadRequest();
            }

            using var context = this.contextFactory.CreateReadOnlyContext();
            this.Booking = context.Bookings
                .Where(m => m.BookingId == id)
                .Include(x => x.FilmCopy)
                .Include(x => x.FilmCopy.Film)
                .Select(x => new BookingDeleteModel
                {
                    BookingId = x.BookingId,
                    FilmCopyId = x.FilmCopyId,
                    RentalDate = x.RentalDate,
                    FilmNumber = x.FilmCopy.FilmNumber,
                    CustomerName = context.Customers.Where(c => c.CustomerId == x.CustomerId).FirstOrDefault().FirstName,
                    FilmTitle = x.FilmCopy.Film.Title,

                })
                .FirstOrDefault();

            if (this.Booking == null)
            {
                return this.NotFound();
            }

            return this.Page();
        }

        public IActionResult OnPost()
        {
            if (Booking == null)
            {
                return BadRequest();
            }

            using (var context = contextFactory.CreateContext())
            {
                var BookingToDelete = context.Bookings.FirstOrDefault(x => x.BookingId == Booking.BookingId);
                if (BookingToDelete == null)
                {
                    return NotFound();
                }

                context.Bookings.Remove(BookingToDelete);

                var FilmCopyToChange = context.FilmCopies.FirstOrDefault(x => x.FilmCopyId == Booking.FilmCopyId);

                FilmCopyToChange.isAvailable = true;

                context.SaveChanges();

            }

            return RedirectToPage("./Index");
        }

        public string getDate(DateTime? dateTime)
        {
            return dateTime.Value.ToString("dd.MM.yyyy");
        }

    }


    public class BookingDeleteModel
    {
        public Guid BookingId { get; set; }
        public Guid FilmCopyId { get; set; }
        public DateTime RentalDate { get; set; }
        public long FilmNumber { get; set; }
        public string CustomerName { get; set; }
        public string FilmTitle { get; set; }
    }
}
