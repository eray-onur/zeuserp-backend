using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using ZeusERP.Core.Entities;
using ZeusERP.Entities.Concrete.Enums;

namespace ZeusERP.Entities.Concrete
{
    [Table("t_inv_receipts")]
    public class ReceiptOrder
    {
        public int Id { get; set; }
        public int ReceiveFromId { get; set; }
        public DateTime ScheduledDate { get; set; }
        public int ReceiptOperationsId { get; set; }
    }
}