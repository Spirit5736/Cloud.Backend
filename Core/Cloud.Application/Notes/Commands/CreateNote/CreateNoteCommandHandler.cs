using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MediatR;
using Cloud.Domain;
using System.Threading.Tasks;
using Cloud.Application.Interfaces;

namespace Cloud.Application.Notes.Commands.CreateNote
{
     public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, Guid>
    {
        private readonly ICloudDbContext _cloudDbContext;

        public CreateNoteCommandHandler(ICloudDbContext cloudDbContext) => _cloudDbContext = cloudDbContext;

        public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var cloud = new CloudEntity
            {
                UserId = request.UserId,
                Title = request.Title,
                Details = request.Details,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                EditDate = null,
            };

            await _cloudDbContext.CloudEntities.AddAsync(cloud, cancellationToken);
            await _cloudDbContext.SaveChangesAsync(cancellationToken);

            return cloud.Id;
        }
    }
}
