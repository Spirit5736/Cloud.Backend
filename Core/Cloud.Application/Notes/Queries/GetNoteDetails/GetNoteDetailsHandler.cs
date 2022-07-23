using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Cloud.Application.Common.Exceptions;
using Cloud.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cloud.Application.Notes.Queries.GetNoteDetails
{
    class GetNoteDetailsHandler : IRequestHandler<GetNoteDetailsQuery, NoteDetailsVm>
    {
        private readonly ICloudDbContext _cloudDbContext;
        private readonly IMapper _mapper;

        public GetNoteDetailsHandler (ICloudDbContext cloudDbContext, IMapper mapper) => (_cloudDbContext, _mapper) = (cloudDbContext, mapper);

        public async Task<NoteDetailsVm> Handle(GetNoteDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _cloudDbContext.CloudEntities
                .FirstOrDefaultAsync(note =>
                note.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Cloud), request.Id);
            }

            _cloudDbContext.CloudEntities.Remove(entity);
            await _cloudDbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<NoteDetailsVm>(entity);
        }
    }
}
