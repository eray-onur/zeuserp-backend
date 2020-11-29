﻿using System;
using System.Collections.Generic;
using System.Text;

using ZeusERP.Core.Entities;

namespace ZeusERP.Entities.Concrete.ComplexTypes
{
    public class LocationRowDto : IDto
    {
        public int LocationId { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public string AddressTitle { get; set; }
        public string AddressDescription { get; set; }
    }
}
