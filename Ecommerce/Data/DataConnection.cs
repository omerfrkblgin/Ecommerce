using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;


namespace Ecommerce.Data
{
    public class DataConnection
    {

        public string dataConn;
        public DataConnection(string dataConn) 
        {
            this.dataConn = dataConn;
        }
        
        public void connectionString(string dataConn)
        {
            
            MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;database=eticaret;user=root;password=744302");
            MySqlCommand cmd = new MySqlCommand(dataConn, conn);
        }
    }
}