using Cloud.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cloud.Application.Common.Exceptions;

namespace Cloud.Application.Notes.Commands.UpdateNote
{
    class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand>
    {
        private readonly ICloudDbContext _cloudDbContext;

        public DeleteNoteCommandHandler(ICloudDbContext cloudDbContext) => _cloudDbContext = cloudDbContext;

        public async Task<Unit> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _cloudDbContext.CloudEntities
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Cloud), request.Id);
            }

            _cloudDbContext.CloudEntities.Remove(entity);
            await _cloudDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
