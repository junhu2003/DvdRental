using FluentValidation;
using Microsoft.Extensions.Logging;
using DvdRental.Library.Models;
using Microsoft.Extensions.Configuration;
using DvdRental.Library.Services;
using DvdRental.Library.Repositories;

namespace DvdRental.Library.Handlers
{
    public class RentalFilmHandler : HandlerBase
    {
        private readonly IConfiguration _configuration;
                
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IFilmRepository _filmRepository;
        private readonly IFilmCategoryRepository _filmCategoryRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly IFilmActorRepository _filmActorRepository;
        private readonly IActorRepository _actorRepository;
        private readonly IStaffRepository _staffRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IPaymentRepository _paymentRepository;

        public RentalFilmHandler(ILogger<InitDvdRentalHandler> logger, IConfiguration configuration,
            IInventoryRepository inventoryRepository, IFilmRepository filmRepository, IFilmCategoryRepository filmCategoryRepository, 
            ICategoryRepository categoryRepository, ILanguageRepository languageRepository, IFilmActorRepository filmActorRepository, 
            IActorRepository actorRepository, IStaffRepository staffRepository, ICustomerRepository customerRepository, IPaymentRepository paymentRepository,
        IValidator<DvdRentalContext> contextValidator, IContextStatusService contextStatusService) : base(logger, contextValidator, contextStatusService)
        {
            _configuration = configuration;
                        
            _inventoryRepository = inventoryRepository;
            _filmRepository = filmRepository;
            _filmCategoryRepository = filmCategoryRepository;
            _categoryRepository = categoryRepository;
            _languageRepository = languageRepository;
            _filmActorRepository = filmActorRepository;
            _actorRepository = actorRepository;
            _staffRepository = staffRepository;
            _customerRepository = customerRepository;
            _paymentRepository = paymentRepository;
        }

        public override HandlerType HandlerType => HandlerType.RentalFilmHandler;

        public override string[] RuleSets => new string[] { HandlerType.ToString() };

        protected override async Task<DvdRentalContext> HandleImpl(DvdRentalContext context)
        {     
            _logger.LogInformation($"{HandlerType} - Date processing: {context.DateAccept.ToString("yyyy-MM-dd hh:mm:ss")}");
                        
            context.Rental.Customer = _customerRepository.GetById(context.Rental.CustomerId);
            context.Rental.Staff = _staffRepository.GetById(context.Rental.StaffId);
            context.Rental.Payments = _paymentRepository.GetByRentalId(context.Inputs.RentalId);
            context.Rental.Inventory = _inventoryRepository.GetById(context.Rental.InventoryId);
            context.Rental.Inventory.Film = _filmRepository.GetById(context.Rental.Inventory.FilmId);
            context.Rental.Inventory.Film.Language = _languageRepository.GetById(context.Rental.Inventory.Film.LanguageId);
            
            context.Rental.Inventory.Film.FilmCategories = _filmCategoryRepository.GetByFilmId(context.Rental.Inventory.Film.FilmId);
            foreach (var item in context.Rental.Inventory.Film.FilmCategories)
                item.Category = _categoryRepository.GetById(item.CategoryId);

            context.Rental.Inventory.Film.FilmActors = _filmActorRepository.GetByFilmId(context.Rental.Inventory.Film.FilmId);
            foreach (var item in context.Rental.Inventory.Film.FilmActors)
                item.Actor = _actorRepository.GetById(item.ActorId);            

            _logger.LogInformation($"{HandlerType} - Finish processing ...");
            return context;
        }        
    }
}
