using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using ZeusERP.Core.Entities;

namespace ZeusERP.Entities.Concrete
{
    [Table("t_inv_locations")]
    public class Location : IEntity
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
        public string LocationCode { get; set; }
        public int LocationTypeId { get; set; }
        public int AddressId { get; set; }
        public bool IsInternal { get; set; }
    }
}
