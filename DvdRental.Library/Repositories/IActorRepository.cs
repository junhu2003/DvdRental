using DvdRental.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdRental.Library.Repositories
{
    public interface IActorRepository
    {
        List<Actor>? GetAll();
        Actor? GetById(int id);
    }
}
