using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Models;
using System.Data.SqlClient;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using MySqlConnector;
using Ecommerce.Data;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RegistrationController : ControllerBase
    {
        
        [HttpPost]
        [Route("registration")]
        public string registration([FromBody] User user)
        {
            
            MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;database=eticaret;user=root;password=744302"); 
            MySqlCommand cmd = new MySqlCommand("INSERT INTO users(email,password,name,address,phone) VALUES('" + user.Email+ "','"+user.Password+"','"+user.Name+"','"+user.Address+"','"+user.Phone+"' )",conn);

            
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@Address", user.Address);
            cmd.Parameters.AddWithValue("@Phone", user.Phone);

            conn.Open();
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            if (i == 1)
            {
                return "Data inserted";

            }
            else
            {
                return "error";

            }
            
        }
        
    }
}
