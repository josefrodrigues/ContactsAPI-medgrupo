using ContactsAPI_medgrupo.Contexts;
using ContactsAPI_medgrupo.Domain.Entities;
using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ContactsAPI_medgrupo.Repositories
{
    public class ContactRepository : IContactRepository

    {
        private readonly DbMedgrupoContext _context = new();

        
        public void Add(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }

        public List<Contact> GetAll()
        {
            var contactsList = _context.Contacts.ToList().Where(contact => contact.IsActive=="S");

            return contactsList.ToList();
        }

        public Contact? GetContactById(int id)
        {
            var contact = _context.Contacts.FirstOrDefault(contact => contact.id == id & contact.IsActive == "S");
            return contact;
        }

        public void DisableContact(int id)
        {
            var contact = _context.Contacts.FirstOrDefault(contact => contact.id == id);
            contact.IsActive = "N";
            _context.SaveChanges();

        }

        public void Delete(int id)
        {
            var contact = _context.Contacts.FirstOrDefault(contact => contact.id == id);
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
        }
    }
}
