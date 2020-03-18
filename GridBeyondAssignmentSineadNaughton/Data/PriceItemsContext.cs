using Microsoft.EntityFrameworkCore;
using System.IO;

namespace GridBeyondAssignmentSineadNaughton.Data
{
    public class PriceItemsContext : DbContext
    {
        //Database table
        public DbSet<PriceItem> PriceItems { get; set; }

        //Connects to database with connection string provided in DatabaseConnectionString.txt
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databaseConnectionString = File.ReadAllText("./Data/DatabaseConnectionString.txt");
            optionsBuilder.UseSqlServer(databaseConnectionString);
        }
    }
}
