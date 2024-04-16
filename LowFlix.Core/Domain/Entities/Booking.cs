

namespace LowFlix.Core.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    public class Booking
    {

        public Guid BookingId { get; set; } = Guid.NewGuid();
        public DateTime RentalDate { get; set; }
        public Guid CustomerId { get; set; }
        public Guid FilmId { get; set; }


        public Customer Customer { get; set; }
        public Film Film { get; set; }
        

    }
}
