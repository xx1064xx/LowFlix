

namespace LowFlix.Core.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    public class Booking
    {

        public Guid BookingId { get; set; } = Guid.NewGuid();
        public DateTime RentalDate { get; set; }
        public Guid CustomerId { get; set; }
        public Guid FilmCopyId { get; set; }


        public Customer Customer { get; set; }
        public FilmCopy FilmCopy { get; set; }
        

    }
}
