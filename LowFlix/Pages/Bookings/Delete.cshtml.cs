
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
        public List<FilmCopy> FilmCopies { get; set; } = new List<FilmCopy>();

        public IActionResult OnGet(Guid? id)
        {
            if (id == null)
            {
                return this.BadRequest();
            }

            using var context = this.contextFactory.CreateReadOnlyContext();
            this.Booking = context.Bookings
                .Where(m => m.BookingId == id)
                .Select(x => new BookingDeleteModel
                {
                    BookingId = x.BookingId,
                    RentalDate = x.RentalDate,
                    CustomerName = context.Customers.Where(c => c.CustomerId == x.CustomerId).FirstOrDefault().FirstName,
                    

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
                FilmCopies = context.FilmCopies
                    .Where(m => m.BookingId == Booking.BookingId)
                    .ToList();


                foreach (var filmcopy in FilmCopies)
                {
                    var filmcopyFromDb = context.FilmCopies.FirstOrDefault(x => x.FilmNumber == filmcopy.FilmNumber);

                    if (filmcopyFromDb == null)
                    {
                        return this.NotFound();
                    }

                    filmcopyFromDb.BookingId = null;

                    context.SaveChanges();

                }


                var BookingToDelete = context.Bookings.FirstOrDefault(x => x.BookingId == this.Booking.BookingId);
                if (BookingToDelete == null)
                {
                    return NotFound();
                }

                context.Bookings.Remove(BookingToDelete);

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
        public DateTime RentalDate { get; set; }
        public string CustomerName { get; set; }
    }
}
