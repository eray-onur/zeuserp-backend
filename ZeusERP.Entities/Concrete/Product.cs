using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using ZeusERP.Core.Entities;

namespace ZeusERP.Entities.Concrete
{
    [Table("t_inv_products")]
    public class Product : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string BarcodeNumber { get; set; }
        public decimal UnitsInStock { get; set; }
        public decimal StockLimit { get; set; }
        public decimal Price { get; set; }
    }
}
