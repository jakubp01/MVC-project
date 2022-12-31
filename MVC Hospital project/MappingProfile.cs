using AutoMapper;
using MVC_Hospital_project.Entities;
using MVC_Hospital_project.Models;

namespace MVC_Hospital_project
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Visit, VisitDto>()
                .ForMember(m => m.DoctorName, c => c.MapFrom(d => d.Doctor.Name))
                .ForMember(m => m.PatientName, c => c.MapFrom(p => p.Patient.Name));

        }

    }
}
