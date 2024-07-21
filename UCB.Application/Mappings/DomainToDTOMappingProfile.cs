using AutoMapper;
using UBC.Application.DTOs;
using UBC.Domain.Entities;


namespace UBC.Application.Mappings
{
    public class DomainToDTOMappingProfile: Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Student, StudentDTO>().ReverseMap();
        }
    }
}
