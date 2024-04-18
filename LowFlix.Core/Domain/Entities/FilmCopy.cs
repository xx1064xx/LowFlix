using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowFlix.Core.Domain.Entities
{
    public class FilmCopy
    {

        public Guid FilmCopyId { get; set; } = Guid.NewGuid();
        public long FilmNumber { get; set; }
        public Guid? BookingId { get; set; }
        public Guid FilmId { get; set; }

        public Film Film {  get; set; }
        public Booking Booking { get; set; }

    }
}
