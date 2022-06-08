using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTutorial.DbContexts
{
    public class WPFTutorialDesignTimeDBContextFactory : IDesignTimeDbContextFactory<WPFTutorialDbContext>
    {
        public WPFTutorialDbContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source=WPFTutorial.db").Options;

            return new WPFTutorialDbContext(options);
        }
    }
}
