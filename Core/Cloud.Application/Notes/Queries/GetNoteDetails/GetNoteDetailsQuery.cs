using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud.Application.Notes.Queries.GetNoteDetails
{
    class GetNoteDetailsQuery: IRequest <NoteDetailsVm>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }


    }
}
