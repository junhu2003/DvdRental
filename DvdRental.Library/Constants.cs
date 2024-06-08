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
                HandlerType.CustomerRentalsHandler,
                HandlerType.FinalDvdRentalHandler
            };

    }
}
