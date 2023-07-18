using TornowizeAPI.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TornowizeAPI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly AppDbContext context;

        public ContactController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var result =  this.context.Contacts.ToList();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var result =   this.context.Contacts.FirstOrDefault(Contact => Contact.ID == id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] Contact newContact)
        {
            await this.context.Contacts.AddAsync(newContact);

            await this.context.SaveChangesAsync();
            return Ok("");

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteContact(int id)
        {
            var result =  this.context.Contacts.FirstOrDefault(Contact => Contact.ID == id);

             this.context.Contacts.Remove(result);

             this.context.SaveChanges();

            return Ok("");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact([FromBody] Contact newContact)
        {
            var result =  this.context.Contacts.FirstOrDefault(Contact => Contact.ID == newContact.ID);
            Contact temp = new Contact();
            result = temp;
            result.FirstName = newContact.FirstName;
            result.Lastname = newContact.Lastname;
            result.Email = newContact.Email;
            result.DateTime = newContact.DateTime;
            
            
            this.context.SaveChanges();

            return Ok("");


        }


    }
}
