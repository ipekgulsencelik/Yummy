using FluentValidation;
using Yummy.Business.Abstract;
using Yummy.Business.Concrete;
using Yummy.Business.ValidationRules.ProductValidations;
using Yummy.DataAccess.Abstract;
using Yummy.DataAccess.Concrete;
using Yummy.DataAccess.Repositories;
using Yummy.DTO.DTOs.ProductDTOs;

namespace Yummy.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServiceExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryManager>();

            services.AddScoped<IChefRepository, ChefRepository>();
            services.AddScoped<IChefService, ChefManager>();

            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IContactService, ContactManager>();

            services.AddScoped<IFeatureRepository, FeatureRepository>();
            services.AddScoped<IFeatureService, FeatureManager>();

            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IMessageService, MessageManager>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductManager>();

            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IServiceService, ServiceManager>();

            services.AddScoped<IValidator<CreateProductDTO>, CreateProductValidator>();
            services.AddScoped<IValidator<UpdateProductDTO>, UpdateProductValidator>();
        }
    }
}