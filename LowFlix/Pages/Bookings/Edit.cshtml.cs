
namespace LowFlix.Pages.Bookings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using LowFlix.Core.Interfaces.Data;
    using LowFlix.Core.Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public class EditModel : PageModel
    {
        private readonly IDbContextFactory contextFactory;

        public EditModel(IDbContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        [BindProperty]
        public BookingEditModel Booking { get; set; }
        public List<SelectListItem> CustomerList { get; set; }
        public List<SelectListItem> FilmList { get; set; }

        public IActionResult OnGet(Guid? id)
        {
            if (id == null)
            {
                return this.BadRequest();
            }

            using var context = this.contextFactory.CreateReadOnlyContext();
            CustomerList = context.Customers.Select(a =>
            new SelectListItem
            {
                Value = a.CustomerId.ToString(),
                Text = a.FirstName,
            }).ToList();

            FilmList = context.Films.Select(a =>
            new SelectListItem
            {
                Value = a.FilmId.ToString(),
                Text = a.Title,
            }).ToList();

            this.Booking = context.Bookings
                .Where(m => m.BookingId == id)
                .Select(x => new BookingEditModel
                {
                    BookingId = x.BookingId,
                    CustomerId = x.CustomerId,
                    
                    RentalDate = x.RentalDate
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
            if (!this.ModelState.IsValid)
            {
                return this.Page();
            }

            using var context = this.contextFactory.CreateContext();
            var booking = context.Bookings.FirstOrDefault(x => x.BookingId == this.Booking.BookingId);

            if (booking == null)
            {
                return this.NotFound();
            }

            try
            {
                booking.CustomerId = this.Booking.CustomerId;
                
                booking.RentalDate = this.Booking.RentalDate;

                

                


                context.SaveChanges();
            }
            catch (Exception)
            {
                return this.RedirectToPage("/Error");
            }

            return this.RedirectToPage("./Index");
        }

        public IActionResult OnGetFilmCopyEditList()
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

    public class BookingEditModel
    {
        public Guid BookingId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid FilmId { get; set; }
        public Guid FilmCopyId { get; set; }
        public Guid OldFilmCopyId { get; set; }
        public long FilmNumber { get; set; }
        public DateTime RentalDate { get; set; }
    }

    public class OldFilmCopyEditModel
    {
        public Guid FilmCopyId { get; set; }
        public long FilmNumber { get; set; }
        public Guid FilmId { get; set; }
    }
}
