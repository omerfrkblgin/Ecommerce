using Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        [Route("ProductAdd")]
        public string productAdd([FromBody] Product product) 
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;database=eticaret;user=root;password=744302");
            MySqlCommand cmd = new MySqlCommand("INSERT INTO products (name,description,price,stock_quantity) VALUES('"+product.Name+ "','"+product.Description+"','"+product.Price+"','"+product.Stock+"')", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@name",product.Name);
            cmd.Parameters.AddWithValue("@description", product.Description);
            cmd.Parameters.AddWithValue("@price", product.Price);
            cmd.Parameters.AddWithValue("@stock", product.Stock);
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


        [HttpGet]
        public IActionResult GetProducts()
        {
            List<Product> products = new List<Product>();

            MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;database=eticaret;user=root;password=744302");

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM products", conn);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        Id = Convert.ToInt32(reader["product_id"]),
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString(),
                        Price = reader["Price"].ToString(),
                        Stock = reader["Stock_quantity"].ToString(),
                    });
                }

                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest($"Hata: {ex.Message}");
            }
        }
    }
}
