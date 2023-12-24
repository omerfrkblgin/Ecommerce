using Microsoft.AspNetCore.Mvc;
using Ecommerce.Models;
using System.ComponentModel.DataAnnotations;
using static Ecommerce.Models.User;

namespace Ecommerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        

        [HttpGet]
        public IActionResult GetUser([FromBody] User user)
        {
            User users = new User();

            return Ok(user);
        }
        [HttpPost("Update")]
        public IActionResult UpdateUser([FromBody] User user)
        {
            
            User users = new User();
            
            if (user == null)
            {
                return NotFound("Kullanıcı Bulunamadı");
            }
            users.Id = user.Id;
            users.Name = user.Name;
            users.Email = user.Email;
            users.Phone = user.Phone;
            users.Password = user.Password;
            return NoContent(); 
        }
    }
}
