using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GridBeyondAssignmentSineadNaughton.Data
{
    public class PriceItemsContext : DbContext
    {
        public DbSet<PriceItem> PriceItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databaseConnectionString = File.ReadAllText("./Data/DatabaseConnectionString.txt");
            optionsBuilder.UseSqlServer(databaseConnectionString);
        }
    }
}
