using Microsoft.AspNetCore.Mvc;
using net_core_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_core_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetContacts()
        {
            try
            {
                return Ok(GenerateContacts());
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        private List<Contact> GenerateContacts()
        {
            List<PaymentHistory> GlobalPayments = new List<PaymentHistory>()
            {
                new PaymentHistory("Azure subscription", "Paid on 24.01.2020", 150),
                new PaymentHistory("AWS Functions", "Paid on 12.12.2019", 250),
                new PaymentHistory("Website maintenance", "Payment pending - 31.01.2020", 150, false),
                new PaymentHistory("Security updates", "Paid on 11.11.2019", 149),
                new PaymentHistory("Hosting charges", "Payment pending 23.01.2020", 150, false),
                new PaymentHistory("OneDrive storage", "Paid on 12.11.2019", 50),
                new PaymentHistory("Google charges", "Paid on 11.11.2019", 350)
            };

            var contact1 = new Contact("Aleksandar Todorov", "myemail@abv.bg", "+31 12312312", "01.01.2020 - 02.02.2020", 500, "01.02.2020 - 31.02.2020");
            contact1.AddPayment(GlobalPayments[6]);
            contact1.AddPayment(GlobalPayments[5]);
            contact1.AddPayment(GlobalPayments[2]);


            var contact2 = new Contact("Joshua Fluke", "otheremail@abv.bg", "+31 41231232", "01.01.2020 - 02.02.2020", 435, "01.02.2020 - 31.02.2020");
            contact2.AddPayment(GlobalPayments[1]);
            contact2.AddPayment(GlobalPayments[3]);
            contact2.AddPayment(GlobalPayments[4]);


            var contact3 = new Contact("Adam Smasher", "smash@abv.bg", "+31 67123232", "01.01.2020 - 02.02.2020", 775, "01.02.2020 - 31.02.2020");
            contact3.AddPayment(GlobalPayments[4]);
            contact3.AddPayment(GlobalPayments[5]);
            contact3.AddPayment(GlobalPayments[2]);

            Contact.GlobalContactID = 0;
            return new List<Contact>() { contact1, contact2, contact3 };
        }
    }
}
