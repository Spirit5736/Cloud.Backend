using Cloud.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cloud.Application.Interfaces
{
    public interface ICloudDbContext
    {
        DbSet<CloudEntity> CloudEntities { get; set;}
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
