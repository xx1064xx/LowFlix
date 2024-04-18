using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LowFlix.Pages.FilmCopies
{
    using LowFlix.Core.Domain.Entities;
    using LowFlix.Core.Interfaces.Data;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    public class IndexModel : PageModel
    {
        private readonly IDbContextFactory contextFactory;

        public IndexModel(IDbContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public IReadOnlyList<FilmCopy> FilmCopies { get; set; }
        public IReadOnlyList<Film> Films { get; set; }

        public IActionResult OnGet()
        {
            using var context = this.contextFactory.CreateReadOnlyContext();

            this.Films = context.Films
                .ToList();

            this.FilmCopies = context.FilmCopies
                .ToList();
            return this.Page();
        }

        public string getAvailability(Guid? id)
        {
            if (id == null)
            {
                return "verfügbar";
            }
            else
            {
                return "ausgeliehen";
            }
        }

    }
}
