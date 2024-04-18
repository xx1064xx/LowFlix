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
    using Microsoft.EntityFrameworkCore.Metadata.Conventions;
    using Microsoft.EntityFrameworkCore;

    public class AutoDeleteModel : PageModel
    {
        private readonly IDbContextFactory contextFactory;

        public AutoDeleteModel(IDbContextFactory contextFactory, IConfiguration configuration)
        {
            this.contextFactory = contextFactory;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        [BindProperty]
        public List<Booking> Bookings { get; set; }

        [BindProperty]
        public List<FilmCopyDisplayModel> OldFilmCopies { get; set; } = new List<FilmCopyDisplayModel>();

        [BindProperty]
        public List<FilmGetModel> FilmCopies { get; set; } = new List<FilmGetModel>();




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

            this.Bookings = context.Bookings
                .Where(m => m.CustomerId == this.Customer.CustomerId)
                .ToList();

            foreach (var booking in Bookings)
            {
                var filmCopiesForBooking = context.FilmCopies
                    .Where(m => m.BookingId == booking.BookingId)
                    .Include(x => x.Film)
                    .Select(a =>
                        new FilmCopyDisplayModel
                        {
                            FilmCopyId = a.FilmCopyId,
                            BookingId = booking.BookingId,
                            FilmNumber = a.FilmNumber,
                            FilmTitle = a.Film.Title,
                        })
                    .ToList();

                this.OldFilmCopies.AddRange(filmCopiesForBooking);
            }


        }

        public IActionResult OnPost()
        {


            using var context = this.contextFactory.CreateContext();

            if (OldFilmCopies.Count > 0)
            {
                foreach (var oldFilmCopy in OldFilmCopies)
                {

                    bool found = false;

                    foreach (var filmCopy in FilmCopies)
                    {
                        if (oldFilmCopy.FilmNumber.ToString() == filmCopy.FilmNumber)
                        {
                            found = true;
                            break;
                        }
                    }


                    if (!found)
                    {

                        var filmCopyToEdit = context.FilmCopies
                            .Where(m => m.FilmNumber == oldFilmCopy.FilmNumber)
                            .FirstOrDefault();

                        filmCopyToEdit.BookingId = null;

                        context.SaveChanges();

                    }
                }

                context.SaveChanges();

                var bookings = context.Bookings
                    .Where(m => m.CustomerId == this.Customer.CustomerId)
                    .ToList();

                var newFilmCopies = context.FilmCopies
                    .ToList();

                foreach (var booking in bookings)
                {
                    bool hasMatchingFilmCopy = false;

                    foreach (var filmCopy in newFilmCopies)
                    {
                        if (booking.BookingId == filmCopy.BookingId)
                        {
                            hasMatchingFilmCopy = true;
                            break;
                        }
                    }

                    if (!hasMatchingFilmCopy)
                    {
                        context.Remove(booking);
                    }
                }

                context.SaveChanges();
            }

            return this.RedirectToPage("../Index");

        }


        public string getDate(DateTime? dateTime)
        {
            return dateTime.Value.ToString("dd.MM.yyyy");
        }

    }

    public class FilmCopyDisplayModel
    {
        public Guid FilmCopyId { get; set; }
        public Guid BookingId { get; set; }
        public long FilmNumber { get; set; }
        public string FilmTitle { get; set; }
    }

    public class FilmGetModel
    {
        public string FilmNumber { get; set; }
        
    }

}
