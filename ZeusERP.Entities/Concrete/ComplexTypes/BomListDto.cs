using System;
using System.Collections.Generic;
using System.Text;

using ZeusERP.Core.Entities;
using ZeusERP.Entities.Concrete.Enums;

namespace ZeusERP.Entities.Concrete.ComplexTypes
{
    public class BomListDto : IDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        //public int BoMTypeId { get { return Enum.GetName(BoMType, this.BoMTypeId); } }
        public decimal Quantity { get; set; }
        public IList<BillOfMaterialsComponent> Components { get; set; }
    }
}
