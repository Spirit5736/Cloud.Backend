using Cloud.Application.Common.Mappings;
using Cloud.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using AutoMapper;

namespace Cloud.Application.Notes.Queries.GetNoteList
{
    class NoteLookupDto : IMapWith<CloudEntity>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CloudEntity, NoteLookupDto>()
                .ForMember(noteVm => noteVm.Id,
                opt => opt.MapFrom(note => note.Id))
                .ForMember(noteVm => noteVm.Title,
                opt => opt.MapFrom(note => note.Title));
                }
    }
}
