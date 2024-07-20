using AutoMapper;
using UCB.Application.DTOs;
using UCB.Domain.Entities;


namespace UCB.Application.Mappings
{
    public class DomainToDTOMappingProfile: Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Student, StudentDTO>().ReverseMap();
        }
    }
}
