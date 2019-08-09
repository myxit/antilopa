using System;
using System.Collections.Generic;
using System.Globalization;
using AntilopaApi.Data;

namespace AntilopaApiTest
{
    public static class Utilities
    {
        #region snippet1
        public static void InitializeDbForTests(ApplicationDbContext db)
        {
            db.Owners.AddRange(new Owner[] {
                owner1
            });
            db.SaveChanges();
        }

        public static Owner owner1 = new Owner {
            Id = 1,
            Name = "Glukoza Inc.",
            Address = "11717, Stockholm, Kungsgatan 1",
            CreatedAt = DateTime.ParseExact("2019-08-01T12:00:00Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
            UpdatedAt = DateTime.ParseExact("2019-08-01T12:00:00Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),

        };

        #endregion
    }
}
