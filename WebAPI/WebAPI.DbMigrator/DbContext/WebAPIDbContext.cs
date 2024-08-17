using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Collections.Generic;
using WebAPI.EFCore;

namespace WebAPI.DbMigrator.DbContext
{
    public class WebAPIDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public WebAPIDbContext(DbContextOptions<WebAPIDbContext> options) : base(options)
        {
        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        public virtual async Task CommitAsync()
        {
            _ = await base.SaveChangesAsync().ConfigureAwait(true);
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<PizzaType> PizzaTypes { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            base.ConfigureConventions(builder);
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>();
            builder.Properties<TimeOnly>()
                .HaveConversion<TimeOnlyConverter>();
        }
    }
}

public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
{
    public DateOnlyConverter() : base(
        dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
        dateTime => DateOnly.FromDateTime(dateTime))
    { }
}

public class TimeOnlyConverter : ValueConverter<TimeOnly, TimeSpan>
{
    public TimeOnlyConverter() : base(
        timeOnly => timeOnly.ToTimeSpan(),
        timeSpan => TimeOnly.FromTimeSpan(timeSpan))
    { }
}