
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
    public class CreateModel : PageModel
    {
        private readonly IDbContextFactory contextFactory;

        public CreateModel(IDbContextFactory contextFactory, IConfiguration configuration)
        {
            this.contextFactory = contextFactory;
        }

        [BindProperty]
        public BookingCreateModel Booking { get; set; }
        [BindProperty]
        public List<SelectListItem> CustomerList { get; set; } = new List<SelectListItem>();

        [BindProperty]
        public List<SelectListItem> FilmList { get; set; } = new List<SelectListItem>();

        [BindProperty]
        public List<FilmCopyCreate> FilmCopies { get; set; } = new List<FilmCopyCreate>();

        public void OnGet()
        {
            using var context = this.contextFactory.CreateReadOnlyContext();

            CustomerList = context.Customers.Select(a =>
            new SelectListItem
            {
                Value = a.CustomerId.ToString(),
                Text = a.FirstName + " " + a.LastName,
            }).ToList();

            FilmList = context.Films.Select(a =>
            new SelectListItem
            {
                Value = a.FilmId.ToString(),
                Text = a.Title,
            }).ToList();



        }

        public IActionResult OnPost()
        {
            if (!this.ModelState.IsValid)
            {
                return this.Page();
            }

            using var context = this.contextFactory.CreateContext();
            
            try
            {

                var newBooking = new Booking
                {
                    CustomerId = this.Booking.CustomerId,
                    
                    RentalDate = this.Booking.RentalDate,
                };

                context.Bookings.Add(newBooking);

                
                context.SaveChanges();



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


    public class BookingCreateModel
    {
        public Guid CustomerId { get; set; }
        public DateTime RentalDate { get; set; }
    }

    public class FilmCopyCreate
    {
        public string FilmNumber { get; set; }
    }

}
