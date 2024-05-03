using ContactsAPI_medgrupo.Domain.DTOs;
using ContactsAPI_medgrupo.Domain.Entities;

namespace ContactsAPI_medgrupo.Application.Services.Implementation
{
    public class ContactService : IContactService
    {
        private readonly ILogger<ContactService> _logger;

        public ContactService(ILogger<ContactService> logger)
        {
            _logger = logger;
        }

        public DateTime convertStringToDateTime(string dataNascimento)
        {
            DateTime birthday = DateTime.ParseExact(dataNascimento, "dd/MM/yyyy", null);
            if (ValidarIdade(birthday))
            {
                return birthday;
            }
            else
            {
                throw new BadHttpRequestException("Data de nascimento inválida");
            }

        }
        private bool ValidarIdade(DateTime dataNascimento)
        {
            var now = DateTime.Today;
            if (dataNascimento >= now)
            {
                _logger.LogInformation("Data de nascimento inserida é maior que o dia de hoje.");
                return false;
            }
            var idade = CalcularIdade(dataNascimento);

            if (idade < 18 ^ idade == 0)
            {
                _logger.LogInformation("Contato deve ser maior de idade.");
                return false; ;
            }

            return true;

        }

        public int CalcularIdade(DateTime dataInserida)
        {
            var now = DateTime.Today;
            int idade = now.Year - dataInserida.Year;
            return idade;
        }

        public string convertDateTimeToString(DateTime dataNascimento)
        {
            return dataNascimento.ToString("dd/MM/yyyy");
        }

        public List<ContactListDTO> mapearContatosList(List<Contact> contacts)
        {
            List<ContactListDTO> listaDTOs = new List<ContactListDTO>();
            foreach (Contact contact in contacts)
            {
                ContactListDTO dto = new ContactListDTO { id = contact.id, NomeContato = contact.NomeContato };
                listaDTOs.Add(dto);
            }
            return listaDTOs;
        }

        public ContactDTO mapearContactDetails(Contact contact)
        {
            ContactDTO dto = new ContactDTO
            {
                NomeContato = contact.NomeContato,
                DataNascimento = convertDateTimeToString(contact.DataNascimento),
                Idade = CalcularIdade(contact.DataNascimento),
                Sexo = contact.Sexo
            };

            return dto;
        }

    }
}
