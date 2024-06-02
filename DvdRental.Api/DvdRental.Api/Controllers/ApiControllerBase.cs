using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DvdRental.Api.Controllers
{
    [Authorize]
    public abstract class ApiControllerBase : Controller
    {
    }
}
