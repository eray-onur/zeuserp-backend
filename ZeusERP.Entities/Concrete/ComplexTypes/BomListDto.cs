using System;
using System.Collections.Generic;
using System.Text;

using ZeusERP.Core.Entities;
using ZeusERP.Entities.Concrete.Enums;

namespace ZeusERP.Entities.Concrete.ComplexTypes
{
    public class BomListDto : IDto
    {
        public int BoMId { get; set; }
        public string BoMReference { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public BoMType BoMType { get; set; }
        public decimal Quantity { get; set; }
        public IList<BillOfMaterialsComponent> BoMComponents { get; set; }
    }
}
