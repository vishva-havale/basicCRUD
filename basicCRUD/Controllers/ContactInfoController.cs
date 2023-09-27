using BAL;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace basicCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInfoController:ControllerBase
    {
        private readonly IContactInfoService _contactInfoService;
        public ContactInfoController(IContactInfoService contactInfoService)
        {
            _contactInfoService = contactInfoService;
        }

        [HttpPost]
        [Route("addContactInfo")]
        public IActionResult addContactInfo(ContactInfo contactInfo)
        {
            var result=_contactInfoService.addContactInfo(contactInfo);
            return Ok(result);
        }
        
    }
}
