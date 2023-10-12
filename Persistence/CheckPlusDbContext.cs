using FileTransformationTest.Persistence.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTransformationTest.Persistence
{
    internal class CheckPlusDbContext : DbContext
    {
        public CheckPlusDbContext(DbContextOptions<CheckPlusDbContext> options)
        : base(options) { }
        public DbSet<Banks> Banks { get; set; }
    }
}
