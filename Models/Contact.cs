using System;
using System.Collections.Generic;

namespace ContactAppProject.Models
{
    public class Contact
    {
        public virtual Guid Id { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual User User { get; set; }

        public virtual IList<ContactDetail> ContactsDetails { get; set; } = new List<ContactDetail>();
    }
}