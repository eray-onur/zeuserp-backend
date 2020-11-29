using System;
using System.Collections.Generic;
using System.Text;

namespace ZeusERP.Entities.Concrete
{
    public class InventoryLines
    {
        public int ProductId { get; set; }
        public int LocationId { get; set; }
        public decimal OnHandQuantity { get; set; }
        public decimal CountedQuantity { get; set; }
    }
}
