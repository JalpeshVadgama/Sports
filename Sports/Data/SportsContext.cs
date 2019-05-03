using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sports.Models;
using System;
using System.Linq;

namespace Sports.Data
{
    public class SportsContext :IdentityDbContext<ApplicationUser, ApplicationRole, string>, IDbContext
    {
        public SportsContext
           (DbContextOptions<SportsContext> options)
            : base(options)
        {
            //nothing here
        }

        public DbSet<TestType> TestType { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<TestDetail> TestDetail { get; set; }

        DatabaseFacade IDbContext.Database => throw new NotImplementedException();

        protected static void SeedEnumValues<T, TEnum>(EntityTypeBuilder entity, Func<TEnum, T> converter)
        {
            Enum.GetValues(typeof(TEnum))
                .Cast<object>()
                .Select(value => converter((TEnum)value)).ToList()
                .ForEach(instance => entity.HasData(instance));
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedEnumValues<TestType, TestTypeEnum>(modelBuilder.Entity<TestType>(), e => e);
        }
    }
}
