﻿using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DvdRental.Library.Handlers;
using DvdRental.Library.Models;
using DvdRental.Library.Repositories;
using DvdRental.Library.Services;
using DvdRental.Library.Validators;
using Victor.Calculator.Library;

namespace DvdRental.Library.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IActorRepository, ActorRepository>();            
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