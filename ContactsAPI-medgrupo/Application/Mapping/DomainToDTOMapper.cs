using AutoMapper;
using ContactsAPI_medgrupo.Domain.DTOs;
using ContactsAPI_medgrupo.Domain.Entities;

namespace ContactsAPI_medgrupo.Application.Mapping
{
    public class DomainToDTOMapper : Profile
    {
        public DomainToDTOMapper() 
        {
            CreateMap<Contact, ContactDTO>();
        }
        
    }
}
