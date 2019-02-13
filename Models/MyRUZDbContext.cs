using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRUZ.Models
{
    public class MyRUZDbContext: DbContext
    {
        public MyRUZDbContext(DbContextOptions<MyRUZDbContext> options) : base(options)
        {
        }
        public DbSet<Lesson> Lessons { get; set; }
    }
}
