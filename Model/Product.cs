using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DapperPrac.Model
{
    [Table("Products")]
    public class Product
    {

        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public float Price  { get; set; }
        [Required]
        public int IndustryId  { get; set; }
        public Product()
        {

        }

        public Product(string productName, float price, int industryId)
        {
            ProductName = productName;
            Price = price;
            IndustryId = industryId;
        }
    }
}