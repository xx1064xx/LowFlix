using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LowFlix.Pages.Films
{
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public FilmDeleteModel? Film { get; set; }

        public IActionResult OnGet(Guid? id)
        {
            if (id == null)
            {
                return this.BadRequest();
            }

            using var context = this.contextFactory.CreateReadOnlyContext();
            this.Film = context.Films
                .Where(m => m.FilmId == id)
                .Select(x => new FilmDeleteModel
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
            if (Film == null)
            {
                return BadRequest();
            }

            using (var context = contextFactory.CreateContext())
            {
                var FilmToDelete = context.Films.FirstOrDefault(x => x.FilmId == Film.FilmId);
                if (FilmToDelete == null)
                {
                    return NotFound();
                }

                context.Films.Remove(FilmToDelete);
                context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }

    public class FilmDeleteModel
    {
        public Guid FilmId { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public double WatchTimeMinutes { get; set; }
        public int Year { get; set; }
    }
}
