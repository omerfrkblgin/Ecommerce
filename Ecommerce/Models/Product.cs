﻿using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Stock { get; set; }
        
    }

}
