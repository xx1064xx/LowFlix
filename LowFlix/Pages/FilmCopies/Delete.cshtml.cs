using LowFlix.Pages.Bookings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LowFlix.Pages.FilmCopies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Mvc.Rendering;
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
        public FilmCopyDeleteModel? FilmCopy { get; set; }

        public IActionResult OnGet(Guid? id)
        {
            if (id == null)
            {
                return this.BadRequest();
            }

            using var context = this.contextFactory.CreateReadOnlyContext();
            this.FilmCopy = context.FilmCopies
                .Where(m => m.FilmCopyId == id)
                .Select(x => new FilmCopyDeleteModel
                {
                    FilmCopyId = x.FilmCopyId,
                    FilmNumber = x.FilmNumber,
                    FilmTitle = context.Films.Where(c => c.FilmId == x.FilmId).FirstOrDefault().Title,

                })
                .FirstOrDefault();

            if (this.FilmCopy == null)
            {
                return this.NotFound();
            }

            return this.Page();
        }

        public IActionResult OnPost()
        {
            if (FilmCopy == null)
            {
                return BadRequest();
            }

            using (var context = contextFactory.CreateContext())
            {
                var FilmCopyToDelete = context.FilmCopies.FirstOrDefault(x => x.FilmCopyId == FilmCopy.FilmCopyId);


                if (FilmCopyToDelete == null)
                {
                    return NotFound();
                }

                if (FilmCopyToDelete.BookingId == null)
                {
                    context.FilmCopies.Remove(FilmCopyToDelete);
                    context.SaveChanges();
                }

            }

            return RedirectToPage("./Index");
        }


    }
    public class FilmCopyDeleteModel
    {
        public Guid FilmCopyId { get; set; }
        public long FilmNumber { get; set; }
        public string FilmTitle { get; set;}
    }
}
