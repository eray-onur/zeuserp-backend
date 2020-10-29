﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using ZeusERP.Core.Entities;

namespace ZeusERP.Entities.Concrete
{
    [Table("t_inv_categories")]
    public class Category : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(75)]
        public string CategoryName { get; set; }
        [Required, MaxLength(200)]
        public string CategoryDescription { get; set; }
        public int SubcategoryId { get; set; }
    }
}
