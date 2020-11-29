using System;
using System.Collections.Generic;
using System.Text;

namespace ZeusERP.Entities.Concrete
{
    public class Transfer
    {
        public int Id { get; set; }
        public int ReceiveFromId { get; set; }
        public int OperationTypeId { get; set; }
        public int DestinationLocationId { get; set; }
        public DateTime ScheduledDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public int TransferProductsId { get; set; }
        public int ResponsibleId { get; set; }
    }
}
