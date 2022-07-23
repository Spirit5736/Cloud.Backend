﻿using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Cloud.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
    }
}
