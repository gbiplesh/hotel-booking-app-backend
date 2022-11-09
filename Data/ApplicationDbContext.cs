using Microsoft.EntityFrameworkCore;
using HotelAppAPI.Models;

namespace HotelApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<Checkouts> Checkouts { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserLogin> UserLogin { get; set; }
        //public DbSet<UserConstants> UserConstants { get; set; }
    }
}