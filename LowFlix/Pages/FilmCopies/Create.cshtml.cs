using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LowFlix.Pages.FilmCopies
{
    using LowFlix.Core.Domain.Entities;
    using LowFlix.Core.Interfaces.Data;
    using LowFlix.Pages.Bookings;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    public class CreateModel : PageModel
    {
        private readonly IDbContextFactory contextFactory;

        public CreateModel(IDbContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }
        [BindProperty]
        public FilmCopyCreateModel FilmCopy { get; set; }

        public List<SelectListItem> FilmList { get; set; } = new List<SelectListItem>();

        public void OnGet()
        {
            using var context = this.contextFactory.CreateReadOnlyContext();

            FilmList = context.Films.Select(a =>
            new SelectListItem
            {
                Value = a.FilmId.ToString(),
                Text = a.Title,
            }).ToList();

        }
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
                    var newFilmCopy = new FilmCopy
                    {
                        FilmId = this.FilmCopy.FilmId,
                        FilmNumber = this.FilmCopy.FilmNumber,
                        isAvailable = true
                    };

                    context.FilmCopies.Add(newFilmCopy);
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

    public class FilmCopyCreateModel
    {
        public Guid FilmId { get; set; }
        public long FilmNumber { get; set; }
    }

}
