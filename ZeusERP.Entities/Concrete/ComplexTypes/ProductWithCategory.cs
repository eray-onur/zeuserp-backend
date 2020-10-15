using System;
using System.Collections.Generic;
using System.Text;

using ZeusERP.Core.Entities;

namespace ZeusERP.Entities.Concrete.ComplexTypes
{
    public class ProductWithCategory : IDto
    {
        public Product Product { get; set; }
        public Category Category { get; set; }

        public ProductWithCategory()
        {

        }
        public ProductWithCategory(Product product, Category category)
        {
            Product = product;
            Category = category;
        }
    }
}
