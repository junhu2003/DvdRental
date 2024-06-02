using DvdRental.Library.Handlers;

namespace DvdRental.Library
{
    public class Constants
    {
        public static HandlerType[] SINGLE_CALC_CHAIN = {
                                                            HandlerType.InitCalcHandler,                                                            
                                                            HandlerType.FinalCalcHandler
                                                        };
    }
}
