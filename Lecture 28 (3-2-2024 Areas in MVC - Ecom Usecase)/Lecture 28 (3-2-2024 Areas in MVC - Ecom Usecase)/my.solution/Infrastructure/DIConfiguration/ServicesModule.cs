using AutoMapper;
using Infrastructure.Implementation;
using Infrastructure.Interfaces;
using Infrastructure.Utilities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DIConfiguration
{
    public class ServicesModule
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<IInventoryRepository, InventoryRepository>();
            services.AddTransient<IGenericRepository, GenericRepository>();

            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
