
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Builders
{
    public class DatabaseBuilder
    {

        public DataBaseContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<DataBaseContext>()
              .UseInMemoryDatabase(Guid.NewGuid().ToString())
              .Options;
            return new DataBaseContext(options);
        }

    }
}
