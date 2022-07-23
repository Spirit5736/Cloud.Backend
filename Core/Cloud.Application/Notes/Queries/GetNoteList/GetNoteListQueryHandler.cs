using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Cloud.Application.Interfaces;
using Cloud.Application.Common.Exceptions;
using System.Linq;
using AutoMapper.QueryableExtensions;

namespace Cloud.Application.Notes.Queries.GetNoteList
{
    class GetNoteListQueryHandler : IRequestHandler<GetNoteListQuery, NoteListVm>
    {
        private readonly ICloudDbContext _cloudDbContext;
        private readonly IMapper _mapper;

        public GetNoteListQueryHandler(ICloudDbContext cloudDbContext, IMapper mapper) => (_cloudDbContext, _mapper) = (cloudDbContext, mapper);

        async public Task<NoteListVm> Handle(GetNoteListQuery request, CancellationToken cancellationToken)
        {
            var noteQuery = await _cloudDbContext.CloudEntities
               .Where(note => note.UserId == request.UserId)
               .ProjectTo<NoteLookupDto>(_mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);

            return new NoteListVm { Notes = noteQuery };
        }
    }
}
