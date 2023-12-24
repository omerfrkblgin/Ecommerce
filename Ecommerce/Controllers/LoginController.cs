using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Models;
using System.Data.SqlClient;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using MySqlConnector;
using Ecommerce.Data;

namespace Ecommerse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public string login([FromBody] User user) 
        {
            
            MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;database=eticaret;user=root;password=744302");
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM users WHERE email='"+user.Email +"' and password='"+ user.Password +"'",conn);        
            conn.Open();
            MySqlDataReader dr = cmd.ExecuteReader();          
           
            if (dr.Read())
            {
                conn.Close();
                return "giriş başarılı";
            }
            else
            {
                conn.Close();
                return "başarısız";
            }
            

        }
    }
}
