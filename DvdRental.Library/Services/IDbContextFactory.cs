﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdRental.Library.Services
{
    public interface IDbContextFactory
    {
        DbContext CreateDbContext(DatabaseType dbType);
    }
}