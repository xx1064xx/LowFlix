using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LowFlix.Pages.Films
{
    using System;
    using System.Linq;
    using LowFlix.Core.Domain.Entities;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using LowFlix.Core.Interfaces.Data;

    public class CreateModel : PageModel
    {

        private readonly IDbContextFactory contextFactory;
        public CreateModel(IDbContextFactory contextFactory)
        {

            this.contextFactory = contextFactory;
        }

        [BindProperty]
        public FilmCreateModel? Film { get; set; }

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
                    var newFilm = new Film
                    {
                        Title = Film.Title,
                        Director = Film.Director,
                        WatchTimeMinutes = Film.WatchTimeMinutes,
                        Year = Film.Year,
                    };

                    context.Films.Add(newFilm);
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

    public class FilmCreateModel
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public double WatchTimeMinutes { get; set; }
        public int Year { get; set; }
    }
}
