using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DapperPrac.Model
{
    [Table("Industries")]
    public class Industry
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(255)")]
        public string IndustryName { get; set; }
        [Required]
        [Column(TypeName = "CHAR(14)")]
        public string Cnpj { get; set; }

        public Industry(string industryName, string cnpj)
        {
            IndustryName = industryName;
            Cnpj = cnpj;
        }
    }
}