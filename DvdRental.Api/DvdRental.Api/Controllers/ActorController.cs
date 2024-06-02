using DvdRental.Library.Models;
using DvdRental.Library.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DvdRental.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ApiControllerBase
    {
        private readonly ILogger<ActorController> _logger;
        private readonly IActorRepository _actorRepository;

        public ActorController(ILogger<ActorController> logger, IActorRepository actorRepository)
        { 
            _logger = logger;
            _actorRepository = actorRepository;
        }

        [HttpGet]
        public Actor Get(int actorId)
        {
            var aa = _actorRepository.GetById(actorId);
            return _actorRepository.GetById(actorId);
        }
    }
}
