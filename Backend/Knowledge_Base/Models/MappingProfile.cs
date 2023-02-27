using AutoMapper;
using BusinessLogicLayer.DTO;
using Knowledge_Base.Models.ViewModels;

namespace Knowledge_Base.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<NoteDTO, NoteViewModel>();
            this.CreateMap<NoteViewModel, NoteDTO>();
            this.CreateMap<NoteDTO, LeftMenuNoteViewModel>();
        }
    }
}
