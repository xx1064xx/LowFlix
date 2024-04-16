using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LowFlix.Pages.Films
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
        public FilmEditModel? Film { get; set; }

        public IActionResult OnGet(Guid? id)
        {

            if (id == null)
            {
                return this.BadRequest();
            }

            using var context = this.contextFactory.CreateReadOnlyContext();
            this.Film = context.Films
                .Where(m => m.FilmId == id)
                .Select(x => new FilmEditModel
                {
                    FilmId = x.FilmId,
                    Title = x.Title,
                    Director = x.Director,
                    WatchTimeMinutes = x.WatchTimeMinutes,
                    Year = x.Year,

                })
                .FirstOrDefault();

            if (this.Film == null)
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
            var film = context.Films.FirstOrDefault(x => x.FilmId == this.Film.FilmId);
            if (film == null)
            {
                return this.NotFound();
            }

            try
            {
                film.Title = this.Film.Title;
                film.Director = this.Film.Director;
                film.WatchTimeMinutes = this.Film.WatchTimeMinutes;
                film.Year = this.Film.Year;

                context.SaveChanges();
            }
            catch (Exception)
            {
                return this.RedirectToPage("/Error");
            }

            return this.RedirectToPage("./Index");
        }
    }

    public class FilmEditModel
    {
        public Guid FilmId { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public double WatchTimeMinutes { get; set; }
        public int Year { get; set; }
    }
}
