using DvdRental.Library.Models;

namespace DvdRental.Library
{
    public class DvdRentalInvoker : IDvdRentalInvoker
    {
        ICommand _command;

        public async Task<DvdRentalOutputs> ExecuteCommand()
        {
            return await _command.Execute();
        }

        public void SetCommand(ICommand command)
        {
            _command = command;
        }
    }
}
