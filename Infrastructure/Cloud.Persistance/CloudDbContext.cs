using Cloud.Application.Interfaces;
using Cloud.Domain;
using Cloud.Persistance.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cloud.Persistance
{
    public class CloudDbContext : DbContext, ICloudDbContext
    {
         DbSet<CloudEntity> ICloudDbContext.CloudEntities { get; set; }

        public CloudDbContext (DbContextOptions<CloudDbContext> options) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CloudConfiguration());
            base.OnModelCreating(builder);

        }
    }
}
