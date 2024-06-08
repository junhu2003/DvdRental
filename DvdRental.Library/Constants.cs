using DvdRental.Library.Handlers;

namespace DvdRental.Library
{
    public class Constants
    {/*
        public static HandlerType[] SINGLE_CALC_CHAIN = {
                                                            HandlerType.InitDvdRentalHandler,
                                                            HandlerType.FinalDvdRentalHandler
                                                        };
        */
        public static HandlerType[] RETRIEVE_CUSTOMERS_CHAIN = 
            {
                HandlerType.InitDvdRentalHandler,
                HandlerType.RetrieveCustomersHandler,
                HandlerType.FinalDvdRentalHandler
            };

    }
}
