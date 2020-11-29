using System;
using System.Collections.Generic;
using System.Text;

using ZeusERP.Core.Entities;

namespace ZeusERP.Entities.Concrete.ComplexTypes
{
    public class ProductListDto : IDto
    {
        public IList<ProductDetailsDto> ProductList { get; set; }
    }
}
