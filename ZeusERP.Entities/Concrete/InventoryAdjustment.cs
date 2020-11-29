using System;
using System.Collections.Generic;
using System.Text;

namespace ZeusERP.Entities.Concrete
{
    public class InventoryAdjustment
    {
        public int Id { get; set; }
        public string InventoryRefName { get; set; }
        public int LocationsId { get; set; }
        public int ProductsId { get; set; }
        public int InventoryLinesId { get; set; }
    }
}
