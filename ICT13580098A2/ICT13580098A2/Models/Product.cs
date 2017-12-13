using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ICT13580098A2.Models
{
    public class Product
    {   
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        [MaxLength(200)]
        public String Name { get; set; }
        public String Description { get; set; }

        [MaxLength(100)]
        public string Category { get; set; }
        public decimal salePrice { get; set; }
        public string Sellprice { get; internal set; }
    }
}
