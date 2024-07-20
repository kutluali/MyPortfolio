using MyPortolio.DAL.Entities;

namespace MyPortfolio.Models
{
    public class ContactMessageViewModel
    {
        public List<Message> Messages { get; set; }

        public List<Contact> Contacts { get; set; }
    }
}
