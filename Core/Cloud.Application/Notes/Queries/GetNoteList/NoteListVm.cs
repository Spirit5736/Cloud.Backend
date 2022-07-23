using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud.Application.Notes.Queries.GetNoteList
{
    class NoteListVm
    {
        public IList<NoteLookupDto> Notes { get; set; }
    }
}
