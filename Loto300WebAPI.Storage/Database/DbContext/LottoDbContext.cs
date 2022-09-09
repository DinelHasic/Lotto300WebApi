using Loto3000App.Models;
using Loto300WebApi.Domain.Entites;
using Loto300WebApi.Domain.Enum;
using Loto300WebAPI.Storage.Helper;
using Microsoft.EntityFrameworkCore;

namespace Loto300WebAPI.Storage
{
    public class LottoDbContext : DbContext,ILottoDbContextcs
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Price> Prices { get; set; }

        public DbSet<Session> Seesions { get; set; }

        public DbSet<TicketNumber> TicketNumber { get; set; }

        public LottoDbContext(DbContextOptions<LottoDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(

            new User(1, "Vanja", "Broski", "VanjaBroski",HasingPassword.GetPassword("Test111"), UserType.PLayer),
            new User(2, "Dinko", "Lord", "DinkoLord", HasingPassword.GetPassword("Test222"), UserType.PLayer),
            new User(3, "Monika", "Beluci", "MonikaBeluci", HasingPassword.GetPassword("Test333"), UserType.PLayer),
            new User(4, "Jhony", "Smith", "Jhony123", HasingPassword.GetPassword("Jhony123"), UserType.Admin)

            );

            modelBuilder.Entity<Price>().HasData(
            new Price(1,"Car", 7),
            new Price(2,"Vacation", 6),
            new Price(3,"TV", 5),
            new Price(4,"100$ Gift Card", 4),
            new Price(5,"50$ Gift Card", 3)
            );
        }

    }
}
