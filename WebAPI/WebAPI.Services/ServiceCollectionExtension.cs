using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.DbMigrator.DbContext;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterWebApiDependencies(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IDbFactory, DbFactory>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //Repositories
            services.AddTransient<IPizzaRepository, PizzaRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderDetailRepository, OrderDetailRepository>();
            services.AddTransient<IPizzaTypeRepository, PizzaTypeRepository>();

            //Services
            services.AddTransient<IPizzaService, PizzaService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IImportService, ImportService>();
        }
    }
}