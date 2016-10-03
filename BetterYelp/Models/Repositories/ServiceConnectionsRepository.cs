﻿using WeShouldGo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WeShouldGo.Models.Repositories
{
    public class ServiceConnectionsRepository : Repository<ServiceConnections>, IServiceConnectionsRepository
    {
        public ServiceConnectionsRepository(DbContext context) : base(context)
        {
        }
    }
}
