using DvdRental.Library.Handlers;
using DvdRental.Library.Models;

namespace DvdRental.Library
{
    public class RunDvdRentalCommand : ICommand
    {
        private readonly IDvdRental _dvdRental;

        public DvdRentalInputs DvdRentalInputs { get; set; } = new DvdRentalInputs();
        public HandlerType[] HandlerTypes { get; set; } = new HandlerType[0];

        public RunDvdRentalCommand(IDvdRental dvdRental)
        {
            _dvdRental = dvdRental;
        }
        public async Task<DvdRentalOutputs> Execute()
        {
            var context = await _dvdRental.Execute(new DvdRentalContext() { Inputs = DvdRentalInputs }, HandlerTypes);

            return context?.Outputs;
        }
    }
}
