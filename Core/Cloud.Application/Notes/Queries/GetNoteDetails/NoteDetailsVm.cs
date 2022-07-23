using AutoMapper;
using Cloud.Application.Common.Mappings;
using Cloud.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud.Application.Notes.Queries.GetNoteDetails
{
    class NoteDetailsVm : IMapWith <CloudEntity>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        
        public void Mapping (Profile profile)
        {
            profile.CreateMap<CloudEntity, NoteDetailsVm>()
                .ForMember(noteVm => noteVm.Title,
                opt => opt.MapFrom(note => note.Title))
                .ForMember(noteVm => noteVm.Details,
                opt => opt.MapFrom(note => note.Details))
                .ForMember(noteVm => noteVm.Id,
                opt => opt.MapFrom(note => note.Id))
                 .ForMember(noteVm => noteVm.CreationDate,
                opt => opt.MapFrom(note => note.CreationDate))
                  .ForMember(noteVm => noteVm.EditDate,
                opt => opt.MapFrom(note => note.EditDate));
        }
    }
}
