using LowFlix.Core.Domain;

namespace LowFlix
{
    using LowFlix.Core.Domain.Entities;
    using LowFlix.Core.Interfaces.Data;
    public static class SampleData
    {

        public static void InitializePedaloDatabase(IDbContextFactory contextFactory)
        {
            using var context = contextFactory.CreateContext();
            if (!context.Database.EnsureCreated())
            {
                return;
            }

            if (!context.Bookings.Any())
            {
                // Only insert data if database was not seeded already
                InsertTestData(context);
            }
        }

        private static void InsertTestData(LowFlixContext context)
        {

            var customer1 = new Customer
            {
                CustomerNumber = 9203839402,
                FirstName = "Mauro",
                LastName = "Meier",
                BirthdayDate = new DateTime(2005, 9, 20),
                PhoneNumber = "+41555555001"
            };
            context.Add(customer1);

            var customer2 = new Customer
            {
                CustomerNumber = 2030922853,
                FirstName = "Alice",
                LastName = "Smith",
                BirthdayDate = new DateTime(1985, 10, 25),
                PhoneNumber = "+41555555002"
            };
            context.Add(customer2);

            var customer3 = new Customer
            {
                CustomerNumber = 8887503849,
                FirstName = "Bob",
                LastName = "Johnson",
                BirthdayDate = new DateTime(1978, 3, 8),
                PhoneNumber = "+41555555003"
            };
            context.Add(customer3);

            var customer4 = new Customer
            {
                CustomerNumber = 1203475947,
                FirstName = "Emily",
                LastName = "Davis",
                BirthdayDate = new DateTime(1983, 12, 10),
                PhoneNumber = "+41555555004"
            };
            context.Add(customer4);

            var customer5 = new Customer
            {
                CustomerNumber = 3339483222,
                FirstName = "Sophia",
                LastName = "Wilson",
                BirthdayDate = new DateTime(1976, 8, 5),
                PhoneNumber = "+41555555005"
            };
            context.Add(customer5);

            var customer6 = new Customer
            {
                CustomerNumber = 2287876584,
                FirstName = "David",
                LastName = "Brown",
                BirthdayDate = new DateTime(1995, 2, 28),
                PhoneNumber = "+41555555006"
            };
            context.Add(customer6);

            var customer7 = new Customer
            {
                CustomerNumber = 1102032234,
                FirstName = "Emma",
                LastName = "Johnson",
                BirthdayDate = new DateTime(1992, 7, 12),
                PhoneNumber = "+41555555007"
            };
            context.Add(customer7);

            var customer8 = new Customer
            {
                CustomerNumber = 1188756443,
                FirstName = "Michael",
                LastName = "Miller",
                BirthdayDate = new DateTime(1980, 4, 18),
                PhoneNumber = "+41555555008"
            };
            context.Add(customer8);

            var customer9 = new Customer
            {
                CustomerNumber = 3348757483,
                FirstName = "Olivia",
                LastName = "Wilson",
                BirthdayDate = new DateTime(1973, 9, 30),
                PhoneNumber = "+41555555009"
            };
            context.Add(customer9);

            var customer11 = new Customer
            {
                CustomerNumber = 2234987653,
                FirstName = "Liam",
                LastName = "Jones",
                BirthdayDate = new DateTime(1998, 6, 15),
                PhoneNumber = "+41555555011"
            };
            context.Add(customer11);

            var customer12 = new Customer
            {
                CustomerNumber = 2300909876,
                FirstName = "Ava",
                LastName = "Brown",
                BirthdayDate = new DateTime(2000, 4, 20),
                PhoneNumber = "+41555555012"
            };
            context.Add(customer12);

            var customer13 = new Customer
            {
                CustomerNumber = 3348769584,
                FirstName = "Noah",
                LastName = "Garcia",
                BirthdayDate = new DateTime(1993, 11, 5),
                PhoneNumber = "+41555555013"
            };
            context.Add(customer13);

            var customer14 = new Customer
            {
                CustomerNumber = 3495048943,
                FirstName = "Isabella",
                LastName = "Martinez",
                BirthdayDate = new DateTime(1987, 8, 12),
                PhoneNumber = "+41555555014"
            };
            context.Add(customer14);

            var customer15 = new Customer
            {
                CustomerNumber = 6767685943,
                FirstName = "William",
                LastName = "Lopez",
                BirthdayDate = new DateTime(1982, 3, 25),
                PhoneNumber = "+41555555015"
            };
            context.Add(customer15);

            var customer16 = new Customer
            {
                CustomerNumber = 3988765748,
                FirstName = "Mia",
                LastName = "Hernandez",
                BirthdayDate = new DateTime(1975, 9, 8),
                PhoneNumber = "+41555555016"
            };
            context.Add(customer16);

            var customer17 = new Customer
            {
                CustomerNumber = 2000009837,
                FirstName = "James",
                LastName = "Young",
                BirthdayDate = new DateTime(1989, 7, 30),
                PhoneNumber = "+41555555017"
            };
            context.Add(customer17);

            var customer18 = new Customer
            {
                CustomerNumber = 2333336574,
                FirstName = "Charlotte",
                LastName = "Scott",
                BirthdayDate = new DateTime(1984, 2, 10),
                PhoneNumber = "+41555555018"
            };
            context.Add(customer18);

            var customer19 = new Customer
            {
                CustomerNumber = 8978657343,
                FirstName = "Logan",
                LastName = "King",
                BirthdayDate = new DateTime(1970, 5, 22),
                PhoneNumber = "+41555555019"
            };
            context.Add(customer19);

            var customer20 = new Customer
            {
                CustomerNumber = 9894750323,
                FirstName = "Ella",
                LastName = "Gonzalez",
                BirthdayDate = new DateTime(1996, 12, 18),
                PhoneNumber = "+41555555020"
            };
            context.Add(customer20);


            var film1 = new Film
            {
                Title = "The Beekeeper",
                Director = "David Ayer",
                WatchTimeMinutes = 101,
                Year = 2024
            };
            context.Add(film1);

            var film2 = new Film
            {
                Title = "The Godfather",
                Director = "Francis Ford Coppola",
                WatchTimeMinutes = 175,
                Year = 1972
            };
            context.Add(film2);

            var film3 = new Film
            {
                Title = "The Dark Knight",
                Director = "Christopher Nolan",
                WatchTimeMinutes = 152,
                Year = 2008
            };
            context.Add(film3);

            var film4 = new Film
            {
                Title = "Pulp Fiction",
                Director = "Quentin Tarantino",
                WatchTimeMinutes = 154,
                Year = 1994
            };
            context.Add(film4);

            var film5 = new Film
            {
                Title = "The Lord of the Rings: The Return of the King",
                Director = "Peter Jackson",
                WatchTimeMinutes = 201,
                Year = 2003
            };
            context.Add(film5);

            var film6 = new Film
            {
                Title = "Forrest Gump",
                Director = "Robert Zemeckis",
                WatchTimeMinutes = 142,
                Year = 1994
            };
            context.Add(film6);

            var film7 = new Film
            {
                Title = "Inglourious Basterds",
                Director = "Quentin Tarantino",
                WatchTimeMinutes = 153,
                Year = 2009
            };
            context.Add(film7);

            var film8 = new Film
            {
                Title = "The Matrix",
                Director = "Lana Wachowski, Lilly Wachowski",
                WatchTimeMinutes = 136,
                Year = 1999
            };
            context.Add(film8);

            var film9 = new Film
            {
                Title = "The Silence of the Lambs",
                Director = "Jonathan Demme",
                WatchTimeMinutes = 118,
                Year = 1991
            };
            context.Add(film9);

            var film10 = new Film
            {
                Title = "Schindler's List",
                Director = "Steven Spielberg",
                WatchTimeMinutes = 195,
                Year = 1993
            };
            context.Add(film10);

            var film11 = new Film
            {
                Title = "The Departed",
                Director = "Martin Scorsese",
                WatchTimeMinutes = 151,
                Year = 2006
            };
            context.Add(film11);

            var film12 = new Film
            {
                Title = "The Green Mile",
                Director = "Frank Darabont",
                WatchTimeMinutes = 189,
                Year = 1999
            };
            context.Add(film12);

            context.SaveChanges();

            var booking1 = new Booking { CustomerId = customer1.CustomerId, RentalDate = new DateTime(2024, 4, 15) };
            var booking2 = new Booking { CustomerId = customer2.CustomerId, RentalDate = new DateTime(2024, 4, 14) };
            var booking3 = new Booking { CustomerId = customer3.CustomerId, RentalDate = new DateTime(2024, 4, 10) };
            var booking4 = new Booking { CustomerId = customer4.CustomerId, RentalDate = new DateTime(2024, 4, 12) };
            var booking5 = new Booking { CustomerId = customer5.CustomerId, RentalDate = new DateTime(2024, 4, 15) };
            var booking6 = new Booking { CustomerId = customer6.CustomerId, RentalDate = new DateTime(2024, 4, 13) };
            var booking7 = new Booking { CustomerId = customer7.CustomerId, RentalDate = new DateTime(2024, 3, 23) };

            context.Bookings.Add(booking1);
            context.Bookings.Add(booking2);
            context.Bookings.Add(booking3);
            context.Bookings.Add(booking4);
            context.Bookings.Add(booking5);
            context.Bookings.Add(booking6);
            context.Bookings.Add(booking7);
            
            
            context.SaveChanges();

            var filmCopy1 = new FilmCopy { FilmId = film7.FilmId, FilmNumber = 123478243857, BookingId = booking1.BookingId};
            var filmCopy2 = new FilmCopy { FilmId = film7.FilmId, FilmNumber = 859430830945, BookingId = null };
            var filmCopy3 = new FilmCopy { FilmId = film7.FilmId, FilmNumber = 215783145773, BookingId = booking4.BookingId };

            var filmCopy4 = new FilmCopy { FilmId = film5.FilmId, FilmNumber = 891589895489, BookingId = null};
            var filmCopy5 = new FilmCopy { FilmId = film5.FilmId, FilmNumber = 349580943289, BookingId = booking2.BookingId};
            var filmCopy6 = new FilmCopy { FilmId = film5.FilmId, FilmNumber = 342891789273, BookingId = null };
            var filmCopy7 = new FilmCopy { FilmId = film5.FilmId, FilmNumber = 092347587328, BookingId = booking4.BookingId};
            var filmCopy8 = new FilmCopy { FilmId = film5.FilmId, FilmNumber = 029347172364, BookingId = booking1.BookingId };

            var filmCopy9 = new FilmCopy { FilmId = film3.FilmId, FilmNumber = 923849330945, BookingId = booking7.BookingId };
            var filmCopy10 = new FilmCopy { FilmId = film3.FilmId, FilmNumber = 034950934859, BookingId = booking4.BookingId };

            context.FilmCopies.Add(filmCopy1);
            context.FilmCopies.Add(filmCopy2);
            context.FilmCopies.Add(filmCopy3);
            context.FilmCopies.Add(filmCopy4);
            context.FilmCopies.Add(filmCopy5);
            context.FilmCopies.Add(filmCopy6);
            context.FilmCopies.Add(filmCopy7);
            context.FilmCopies.Add(filmCopy8);
            context.FilmCopies.Add(filmCopy9);
            context.FilmCopies.Add(filmCopy10);

            context.SaveChanges();

            

            
        }

    }
}
