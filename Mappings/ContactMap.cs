using ContactAppProject.Models;
using FluentNHibernate.Mapping;

namespace ContactAppProject.Mappings
{
    public class ContactMap : ClassMap<Contact>
    {
        public ContactMap()
        {
            Table("Contacts");
            Id(c => c.Id).GeneratedBy.GuidComb();
            Map(c => c.FirstName);
            Map(c => c.LastName);
            Map(c => c.IsActive);
            References(c => c.User).Columns("UserId").Unique().Cascade.None();
            HasMany(c => c.ContactsDetails).Inverse().Cascade.All();
        }
    }
}