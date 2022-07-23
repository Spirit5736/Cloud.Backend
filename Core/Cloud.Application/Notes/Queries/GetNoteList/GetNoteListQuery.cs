using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud.Application.Notes.Queries.GetNoteList
{
    class GetNoteListQuery : IRequest<NoteListVm>
    {
        public Guid UserId { get; set; }
    }
}
