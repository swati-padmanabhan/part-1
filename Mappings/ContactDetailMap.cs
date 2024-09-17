﻿using ContactAppProject.Models;
using FluentNHibernate.Mapping;

namespace ContactAppProject.Mappings
{
    public class ContactDetailMap : ClassMap<ContactDetail>
    {
        public ContactDetailMap()
        {
            Table("ContactDetails");
            Id(cd => cd.Id).GeneratedBy.GuidComb();
            Map(cd => cd.Number);
            Map(cd => cd.Email);
            References(cd => cd.Contact).Column("ContactId").Unique().Cascade.None();
        }
    }
}