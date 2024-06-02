using DvdRental.Library;
using DvdRental.Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace DvdRental.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DvdRentalController : ApiControllerBase
    {
        private readonly ILogger<DvdRentalController> _logger;
        private readonly IDvdRental _dvdRental;
        private readonly IDvdRentalInvoker _dvdRentalInvoker;

        public DvdRentalController(ILogger<DvdRentalController> logger, IDvdRental dvdRental, IDvdRentalInvoker dvdRentalInvoker)
        { 
            _logger = logger;
            _dvdRental = dvdRental;
            _dvdRentalInvoker = dvdRentalInvoker;
        }

        [HttpPost(Name = "Process")]
        public async Task<ActionResult> Process(DvdRentalInputs dvdRentalInputs) 
        {
            _logger.LogInformation("Start processing ...");

            var runDvdRentalCommand = new RunDvdRentalCommand(_dvdRental);
            runDvdRentalCommand.DvdRentalInputs = dvdRentalInputs;

            dvdRentalInputs.User = User?.Identity?.Name;

            _dvdRentalInvoker.SetCommand(runDvdRentalCommand);
            var outputs = await _dvdRentalInvoker.ExecuteCommand();

            if (outputs?.Errors?.Count > 0)
            {
                return NotFound();
            }

            return Ok(outputs);
        }
    }
}
