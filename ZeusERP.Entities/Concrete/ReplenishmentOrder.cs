﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using ZeusERP.Core.Entities;
using ZeusERP.Entities.Concrete.Enums;

namespace ZeusERP.Entities.Concrete
{
    [Table("t_orders_replenishment")]
    public class ReplenishmentOrder : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int ProductToReplenishId { get; set; }
        public int LocationId { get; set; }
        public int WarehouseId { get; set; }
        public int BomId { get; set; }
        public decimal OrderQuantity { get; set; }
        public decimal OnHandQuantity { get; set; }
        public ReplenishmentStatus Status { get; set; }
    }
}
