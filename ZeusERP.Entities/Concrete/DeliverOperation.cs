using System;
using System.Collections.Generic;
using System.Text;

namespace ZeusERP.Entities.Concrete
{
    public class DeliverOperation
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public decimal ReservedQuantity { get; set; }
        public decimal DoneQuantity { get; set; }
    }
}
