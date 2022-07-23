using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud.Application.Notes.Commands.UpdateNote
{
    class DeleteNoteCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
