﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }

        public int UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
