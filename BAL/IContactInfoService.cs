﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public interface IContactInfoService
    {
        ContactInfo addContactInfo(ContactInfo contactInfo);
    }
}
