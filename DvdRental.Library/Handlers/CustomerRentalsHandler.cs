using FluentValidation;
using Microsoft.Extensions.Logging;
using DvdRental.Library.Models;
using Microsoft.Extensions.Configuration;
using DvdRental.Library.Services;
using DvdRental.Library.Repositories;

namespace DvdRental.Library.Handlers
{
    public class CustomerRentalsHandler : HandlerBase
    {
        private readonly IConfiguration _configuration;
        
        private readonly IAddressRepository _addressRepository;
        private readonly ICityRepository _cityRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IStaffRepository _staffRepository;
        private readonly IRentalRepository _rentalRepository;

        public CustomerRentalsHandler(ILogger<InitDvdRentalHandler> logger, IConfiguration configuration,
            IAddressRepository addressRepository, ICityRepository cityRepository, ICountryRepository countryRepository,
            IStoreRepository storeRepository, IPaymentRepository paymentRepository, IStaffRepository staffRepository, IRentalRepository rentalRepository,
            IValidator<DvdRentalContext> contextValidator, IContextStatusService contextStatusService) : base(logger, contextValidator, contextStatusService)
        {
            _configuration = configuration;
            
            _addressRepository = addressRepository;
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
            _storeRepository = storeRepository;
            _paymentRepository = paymentRepository;
            _staffRepository = staffRepository;
            _rentalRepository = rentalRepository;
        }

        public override HandlerType HandlerType => HandlerType.CustomerRentalsHandler;

        public override string[] RuleSets => new string[] { HandlerType.ToString() };

        protected override async Task<DvdRentalContext> HandleImpl(DvdRentalContext context)
        {     
            _logger.LogInformation($"{HandlerType} - Date processing: {context.DateAccept.ToString("yyyy-MM-dd hh:mm:ss")}");
                        
            context.Customer.Address = _addressRepository.GetById(context.Customer.AddressId);
            context.Customer.Address.City = _cityRepository.GetById(context.Customer.Address.CityId);
            context.Customer.Address.City.Country = _countryRepository.GetById(context.Customer.Address.City.CountryId);

            context.Customer.Payments = _paymentRepository.GetByCustomerId(context.Customer.CustomerId);

            context.Customer.Rentals = _rentalRepository.GetRentalByCustomer(context.Customer.CustomerId);

            _logger.LogInformation($"{HandlerType} - Finish processing ...");
            return context;
        }

    }
}
