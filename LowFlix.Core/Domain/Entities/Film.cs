
namespace LowFlix.Core.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    public class Film
    {

        public Guid FilmId { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Director { get; set; }
        public double WatchTimeMinutes { get; set; }
        public int Year { get; set; }

        public ICollection<FilmCopy> FilmCopys { get; set; }

    }
}
