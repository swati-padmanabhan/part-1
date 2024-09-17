﻿using ContactAppProject.Models;
using FluentNHibernate.Mapping;

namespace ContactAppProject.Mappings
{
    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            Table("Roles");
            Id(r => r.Id).GeneratedBy.GuidComb();
            Map(r => r.RoleName);
            References(r => r.User).Column("UserId").Unique().Cascade.None();
        }
    }
}