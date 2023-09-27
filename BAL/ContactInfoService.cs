using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class ContactInfoService : IContactInfoService
    {
        private readonly IContactInfoRepo _contactInfoRepo;

        public ContactInfoService(IContactInfoRepo contactInfoRepo)
        {
            _contactInfoRepo = contactInfoRepo;
        }

        public ContactInfo addContactInfo(ContactInfo contactInfo)
        {
            var result = _contactInfoRepo.addContactInfo(contactInfo);
            return result;
        }
    }
}
