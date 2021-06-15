using Flunt.Notifications;
using JSP.Domain.Entities;
using JSP_Infra.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;

namespace JSP_Infra.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMap().Configure);
           // modelBuilder.Entity<PersonalProtectiveEquipment>(new PpeMap().Configure);
          
            var entites = Assembly
                .Load("JSP.Domain")
                .GetTypes()
                .Where(w => w.Namespace == "JSP.Domain.Entities" && w.BaseType.BaseType == typeof(Notifiable));

            foreach (var item in entites)
            {
                modelBuilder.Entity(item).Ignore(nameof(Notifiable.Invalid));
                modelBuilder.Entity(item).Ignore(nameof(Notifiable.Valid));
                modelBuilder.Entity(item).Ignore(nameof(Notifiable.Notifications));
            }
        }
    }
}
