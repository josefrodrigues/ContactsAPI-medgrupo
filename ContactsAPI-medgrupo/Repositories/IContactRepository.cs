using ContactsAPI_medgrupo.Domain.Entities;

namespace ContactsAPI_medgrupo.Repositories
{
    public interface IContactRepository
    {
        void Add(Contact contact);

        Contact? GetContactById(int id);

        List<Contact> GetAll();

        void DisableContact(int id);
        void Delete(int id);
    }
}
