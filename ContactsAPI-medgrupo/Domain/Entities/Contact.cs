using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactsAPI_medgrupo.Domain.Entities
{
    [Table("Contacts")]
    public class Contact
    {
        [Key]
        public int id { get; set; }

        public string NomeContato { get; set; } = "";
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; } = "";
        public string? IsActive { get; set; } = "S";

        public Contact() { }
        public Contact(string contactName, DateTime birthday, string sex)
        {
            this.NomeContato = contactName ?? throw new ArgumentNullException(nameof(contactName));
            this.DataNascimento = birthday;
            this.Sexo = sex ?? throw new ArgumentNullException(nameof(sex));
        }

    }
}
