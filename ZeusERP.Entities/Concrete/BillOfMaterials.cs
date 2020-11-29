using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using ZeusERP.Core.Entities;

namespace ZeusERP.Entities.Concrete
{
    [Table("t_inv_product_boms")]
    public class BillOfMaterials : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int BoMTypeId { get; set; }
        public decimal Quantity { get; set; }
        public int ComponentsId { get; set; }
    }
}
