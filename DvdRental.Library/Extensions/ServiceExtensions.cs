using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DvdRental.Library.Handlers;
using DvdRental.Library.Models;
using DvdRental.Library.Repositories;
using DvdRental.Library.Services;
using DvdRental.Library.Validators;

namespace DvdRental.Library.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IActorRepository, ActorRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IFilmCategoryRepository, FilmCategoryRepository>();
            services.AddTransient<IFilmRepository, FilmRepository>();
            services.AddTransient<ILanguageRepository, LanguageRepository>();
            services.AddTransient<IFilmActorRepository, FilmActorRepository>();
            services.AddTransient<IInventoryRepository, InventoryRepository>();
            services.AddTransient<IRentalRepository, RentalRepository>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddTransient<IStaffRepository, StaffRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<IStoreRepository, StoreRepository>();
        }        

        public static void AddFactories(this IServiceCollection services)
        {
            services.AddTransient<IHandlerFactory, HandlerFactory>();
            services.AddTransient<IHandlerChainFactory, DvdRentalChainHandlerFactory>();
            services.AddTransient<IDbConnectionFactory, DatabaseConnectionFactory>();
            services.AddTransient<IDbContextFactory, DbContextFactory>();
        }

        public static void AddHandlers(this IServiceCollection services)
        {
            services.AddTransient<IHandler, InitDvdRentalHandler>();
            services.AddTransient<IHandler, RetrieveCustomersHandler>();
            services.AddTransient<IHandler, CustomerByIdHandler>();
            services.AddTransient<IHandler, CustomerRentalsHandler>();
            services.AddTransient<IHandler, RentalByIdHandler>();
            services.AddTransient<IHandler, RentalFilmHandler>();
            services.AddTransient<IHandler, FinalDvdRentalHandler>();
        }

        public static void AddValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<DvdRentalContext>, DvdRentalContextValidator>();
            services.AddTransient<IValidator<DvdRentalInputs>, DvdRentalInputsValidator>();
            services.AddTransient<IValidator<Actor>, ActorValidator>();
        }

        public static void AddCalculators(this IServiceCollection services)
        {            
            services.AddTransient<IDvdRental, DvdRental>();
            services.AddTransient<ICommand, RunDvdRentalCommand>();
            services.AddTransient<IDvdRentalInvoker, DvdRentalInvoker>();
        }

        public static void AddWebServices(this IServiceCollection services, IConfiguration configuration)
        {            
            services.AddTransient<IContextStatusService, ContextStatusService>();
        }
    }
}
