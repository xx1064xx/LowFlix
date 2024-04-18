
namespace LowFlix.Core.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    public class Customer
    {
        public Guid CustomerId { get; set; } = Guid.NewGuid();
        public long CustomerNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Booking> Bookings { get; set; }

    }
}
