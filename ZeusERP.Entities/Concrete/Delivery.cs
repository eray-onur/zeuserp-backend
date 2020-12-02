using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using ZeusERP.Core.Entities;

namespace ZeusERP.Entities.Concrete
{
    [Table("t_inv_orders_deliveries")]
    public class Delivery : IEntity
    {
        public int Id { get; set; }
        public int DeliveryAddressId { get; set; }
        public int SourceLocationId { get; set; }
        public DateTime ScheduledDate { get; set; }
        public int DeliveryOperationsId { get; set; }
    }
}
