﻿using Exoticamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Contracts.Persistence
{
    public interface ILoactionRepository : IAsyncRepository<Location>
    {
        Task<Location> GetLocationById(string id);

    }
}
