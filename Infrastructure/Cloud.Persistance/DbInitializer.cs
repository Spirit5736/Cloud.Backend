using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud.Persistance
{
    class DbInitializer
    {
        public static void Initialize (CloudDbContext cloudDbContext)
        {
            cloudDbContext.Database.EnsureCreated();
        }
    }
}
