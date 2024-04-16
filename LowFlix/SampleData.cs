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
                FirstName = "Mauro",
                LastName = "Meier",
                BirthdayDate = new DateTime(2005, 9, 20),
                PhoneNumber = "+41555555001"
            };
            context.Add(customer1);

            var customer2 = new Customer
            {
                FirstName = "Alice",
                LastName = "Smith",
                BirthdayDate = new DateTime(1985, 10, 25),
                PhoneNumber = "+41555555002"
            };
            context.Add(customer2);

            var customer3 = new Customer
            {
                FirstName = "Bob",
                LastName = "Johnson",
                BirthdayDate = new DateTime(1978, 3, 8),
                PhoneNumber = "+41555555003"
            };
            context.Add(customer3);

            var customer4 = new Customer
            {
                FirstName = "Emily",
                LastName = "Davis",
                BirthdayDate = new DateTime(1983, 12, 10),
                PhoneNumber = "+41555555004"
            };
            context.Add(customer4);

            var customer5 = new Customer
            {
                FirstName = "Sophia",
                LastName = "Wilson",
                BirthdayDate = new DateTime(1976, 8, 5),
                PhoneNumber = "+41555555005"
            };
            context.Add(customer5);

            var customer6 = new Customer
            {
                FirstName = "David",
                LastName = "Brown",
                BirthdayDate = new DateTime(1995, 2, 28),
                PhoneNumber = "+41555555006"
            };
            context.Add(customer6);

            var customer7 = new Customer
            {
                FirstName = "Emma",
                LastName = "Johnson",
                BirthdayDate = new DateTime(1992, 7, 12),
                PhoneNumber = "+41555555007"
            };
            context.Add(customer7);

            var customer8 = new Customer
            {
                FirstName = "Michael",
                LastName = "Miller",
                BirthdayDate = new DateTime(1980, 4, 18),
                PhoneNumber = "+41555555008"
            };
            context.Add(customer8);

            var customer9 = new Customer
            {
                FirstName = "Olivia",
                LastName = "Wilson",
                BirthdayDate = new DateTime(1973, 9, 30),
                PhoneNumber = "+41555555009"
            };
            context.Add(customer9);

            var customer11 = new Customer
            {
                FirstName = "Liam",
                LastName = "Jones",
                BirthdayDate = new DateTime(1998, 6, 15),
                PhoneNumber = "+41555555011"
            };
            context.Add(customer11);

            var customer12 = new Customer
            {
                FirstName = "Ava",
                LastName = "Brown",
                BirthdayDate = new DateTime(2000, 4, 20),
                PhoneNumber = "+41555555012"
            };
            context.Add(customer12);

            var customer13 = new Customer
            {
                FirstName = "Noah",
                LastName = "Garcia",
                BirthdayDate = new DateTime(1993, 11, 5),
                PhoneNumber = "+41555555013"
            };
            context.Add(customer13);

            var customer14 = new Customer
            {
                FirstName = "Isabella",
                LastName = "Martinez",
                BirthdayDate = new DateTime(1987, 8, 12),
                PhoneNumber = "+41555555014"
            };
            context.Add(customer14);

            var customer15 = new Customer
            {
                FirstName = "William",
                LastName = "Lopez",
                BirthdayDate = new DateTime(1982, 3, 25),
                PhoneNumber = "+41555555015"
            };
            context.Add(customer15);

            var customer16 = new Customer
            {
                FirstName = "Mia",
                LastName = "Hernandez",
                BirthdayDate = new DateTime(1975, 9, 8),
                PhoneNumber = "+41555555016"
            };
            context.Add(customer16);

            var customer17 = new Customer
            {
                FirstName = "James",
                LastName = "Young",
                BirthdayDate = new DateTime(1989, 7, 30),
                PhoneNumber = "+41555555017"
            };
            context.Add(customer17);

            var customer18 = new Customer
            {
                FirstName = "Charlotte",
                LastName = "Scott",
                BirthdayDate = new DateTime(1984, 2, 10),
                PhoneNumber = "+41555555018"
            };
            context.Add(customer18);

            var customer19 = new Customer
            {
                FirstName = "Logan",
                LastName = "King",
                BirthdayDate = new DateTime(1970, 5, 22),
                PhoneNumber = "+41555555019"
            };
            context.Add(customer19);

            var customer20 = new Customer
            {
                FirstName = "Ella",
                LastName = "Gonzalez",
                BirthdayDate = new DateTime(1996, 12, 18),
                PhoneNumber = "+41555555020"
            };
            context.Add(customer20);

            var customer21 = new Customer
            {
                FirstName = "Alexander",
                LastName = "Lee",
                BirthdayDate = new DateTime(1988, 10, 8),
                PhoneNumber = "+41555555021"
            };
            context.Add(customer21);

            var customer22 = new Customer
            {
                FirstName = "Grace",
                LastName = "Clark",
                BirthdayDate = new DateTime(1991, 5, 12),
                PhoneNumber = "+41555555022"
            };
            context.Add(customer22);

            var customer23 = new Customer
            {
                FirstName = "Lucas",
                LastName = "Lewis",
                BirthdayDate = new DateTime(1983, 8, 30),
                PhoneNumber = "+41555555023"
            };
            context.Add(customer23);

            var customer24 = new Customer
            {
                FirstName = "Chloe",
                LastName = "Baker",
                BirthdayDate = new DateTime(1977, 12, 5),
                PhoneNumber = "+41555555024"
            };
            context.Add(customer24);

            var customer25 = new Customer
            {
                FirstName = "Benjamin",
                LastName = "Hill",
                BirthdayDate = new DateTime(1974, 3, 18),
                PhoneNumber = "+41555555025"
            };
            context.Add(customer25);

            var customer26 = new Customer
            {
                FirstName = "Zoe",
                LastName = "Wright",
                BirthdayDate = new DateTime(1997, 7, 22),
                PhoneNumber = "+41555555026"
            };
            context.Add(customer26);

            var customer27 = new Customer
            {
                FirstName = "Ethan",
                LastName = "Adams",
                BirthdayDate = new DateTime(1980, 9, 14),
                PhoneNumber = "+41555555027"
            };
            context.Add(customer27);

            var customer28 = new Customer
            {
                FirstName = "Madison",
                LastName = "Green",
                BirthdayDate = new DateTime(1986, 4, 28),
                PhoneNumber = "+41555555028"
            };
            context.Add(customer28);

            var customer29 = new Customer
            {
                FirstName = "Henry",
                LastName = "Russell",
                BirthdayDate = new DateTime(1979, 1, 7),
                PhoneNumber = "+41555555029"
            };
            context.Add(customer29);

            var customer30 = new Customer
            {
                FirstName = "Lily",
                LastName = "Morris",
                BirthdayDate = new DateTime(1981, 6, 10),
                PhoneNumber = "+41555555030"
            };
            context.Add(customer30);

            var customer31 = new Customer
            {
                FirstName = "Jacob",
                LastName = "Sullivan",
                BirthdayDate = new DateTime(1990, 11, 19),
                PhoneNumber = "+41555555031"
            };
            context.Add(customer31);

            var customer32 = new Customer
            {
                FirstName = "Natalie",
                LastName = "Ross",
                BirthdayDate = new DateTime(1972, 2, 27),
                PhoneNumber = "+41555555032"
            };
            context.Add(customer32);

            var customer33 = new Customer
            {
                FirstName = "Daniel",
                LastName = "Coleman",
                BirthdayDate = new DateTime(1984, 8, 3),
                PhoneNumber = "+41555555033"
            };
            context.Add(customer33);

            var customer34 = new Customer
            {
                FirstName = "Avery",
                LastName = "Barnes",
                BirthdayDate = new DateTime(1995, 4, 14),
                PhoneNumber = "+41555555034"
            };
            context.Add(customer34);

            var customer35 = new Customer
            {
                FirstName = "Jackson",
                LastName = "Edwards",
                BirthdayDate = new DateTime(1987, 12, 21),
                PhoneNumber = "+41555555035"
            };
            context.Add(customer35);

            var customer36 = new Customer
            {
                FirstName = "Hannah",
                LastName = "Fisher",
                BirthdayDate = new DateTime(1976, 10, 2),
                PhoneNumber = "+41555555036"
            };
            context.Add(customer36);

            var customer37 = new Customer
            {
                FirstName = "Sebastian",
                LastName = "Kelly",
                BirthdayDate = new DateTime(1982, 5, 16),
                PhoneNumber = "+41555555037"
            };
            context.Add(customer37);

            var customer38 = new Customer
            {
                FirstName = "Aria",
                LastName = "Phillips",
                BirthdayDate = new DateTime(1973, 9, 29),
                PhoneNumber = "+41555555038"
            };
            context.Add(customer38);

            var customer39 = new Customer
            {
                FirstName = "Gabriel",
                LastName = "Richardson",
                BirthdayDate = new DateTime(1998, 3, 4),
                PhoneNumber = "+41555555039"
            };
            context.Add(customer39);

            var customer40 = new Customer
            {
                FirstName = "Mila",
                LastName = "Carter",
                BirthdayDate = new DateTime(1971, 7, 11),
                PhoneNumber = "+41555555040"
            };
            context.Add(customer40);

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
            context.Add(film12);
            context.SaveChanges();

            context.Bookings.Add(new Booking { CustomerId = customer1.CustomerId, FilmId = film2.FilmId, RentalDate = new DateTime(2024, 4, 15) });
            context.Bookings.Add(new Booking { CustomerId = customer2.CustomerId, FilmId = film3.FilmId, RentalDate = new DateTime(2024, 4, 14) });
            context.Bookings.Add(new Booking { CustomerId = customer3.CustomerId, FilmId = film4.FilmId, RentalDate = new DateTime(2024, 4, 10) });
            context.Bookings.Add(new Booking { CustomerId = customer4.CustomerId, FilmId = film5.FilmId, RentalDate = new DateTime(2024, 4, 12) });
            context.Bookings.Add(new Booking { CustomerId = customer5.CustomerId, FilmId = film6.FilmId, RentalDate = new DateTime(2024, 4, 15) });
            context.Bookings.Add(new Booking { CustomerId = customer6.CustomerId, FilmId = film7.FilmId, RentalDate = new DateTime(2024, 4, 13) });
            context.Bookings.Add(new Booking { CustomerId = customer7.CustomerId, FilmId = film8.FilmId, RentalDate = new DateTime(2024, 3, 23) });
            context.SaveChanges();

            context.FilmCopies.Add(new FilmCopy { FilmId = film7.FilmId, FilmNumber = 123478243857});
            context.FilmCopies.Add(new FilmCopy { FilmId = film7.FilmId, FilmNumber = 859430830945});
            context.FilmCopies.Add(new FilmCopy { FilmId = film7.FilmId, FilmNumber = 215783145773});

            context.FilmCopies.Add(new FilmCopy { FilmId = film5.FilmId, FilmNumber = 891589895489});
            context.FilmCopies.Add(new FilmCopy { FilmId = film5.FilmId, FilmNumber = 349580943289});
            context.FilmCopies.Add(new FilmCopy { FilmId = film5.FilmId, FilmNumber = 342891789273});
            context.FilmCopies.Add(new FilmCopy { FilmId = film5.FilmId, FilmNumber = 092347587328});
            context.FilmCopies.Add(new FilmCopy { FilmId = film5.FilmId, FilmNumber = 029347172364});

            context.SaveChanges();
        }

    }
}
