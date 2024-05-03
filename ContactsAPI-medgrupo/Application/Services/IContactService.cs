using ContactsAPI_medgrupo.Domain.DTOs;
using ContactsAPI_medgrupo.Domain.Entities;

namespace ContactsAPI_medgrupo.Application.Services
{
    public interface IContactService
    {
        public DateTime convertStringToDateTime(string dataNascimento);

        public int CalcularIdade(DateTime dataInserida);

        public string convertDateTimeToString(DateTime dataNascimento);

        public List<ContactListDTO> mapearContatosList(List<Contact> contacts);

        public ContactDTO mapearContactDetails(Contact contact);
    }
}
