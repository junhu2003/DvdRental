using DvdRental.Library.Handlers;

namespace DvdRental.Library
{
    public class Constants
    {

        public static HandlerType[] RETRIEVE_CUSTOMERS_CHAIN = 
            {
                HandlerType.InitDvdRentalHandler,
                HandlerType.RetrieveCustomersHandler,
                HandlerType.FinalDvdRentalHandler
            };

        public static HandlerType[] RETRIEVE_CUSTOMER_RENTALS_CHAIN =
            {
                HandlerType.InitDvdRentalHandler,
                HandlerType.CustomerByIdHandler,
                HandlerType.CustomerRentalsHandler,
                HandlerType.FinalDvdRentalHandler
            };

        public static HandlerType[] RETRIEVE_RENTAL_FILM_CHAIN =
            {
                HandlerType.InitDvdRentalHandler,
                HandlerType.RentalByIdHandler,
                HandlerType.RentalFilmHandler,
                HandlerType.FinalDvdRentalHandler
            };
    }
}
