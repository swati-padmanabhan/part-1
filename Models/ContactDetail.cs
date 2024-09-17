﻿using System;

namespace ContactAppProject.Models
{
    public class ContactDetail
    {
        public virtual Guid Id { get; set; }

        public virtual long Number { get; set; }

        public virtual string Email { get; set; }

        public virtual Contact Contact { get; set; }
    }
}