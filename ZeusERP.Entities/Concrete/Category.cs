using System;
using System.Collections.Generic;
using System.Text;

using ZeusERP.Core.Entities;

namespace ZeusERP.Entities.Concrete
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
