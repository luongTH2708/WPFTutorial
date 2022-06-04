using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTutorial.DbContexts
{
    public class WPFTutorialDbContextFactory
    {
        private readonly string _connectionString;

        public WPFTutorialDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public WPFTutorialDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().
                UseSqlite(_connectionString).Options;

            return new WPFTutorialDbContext(options);
        }
    }
}
