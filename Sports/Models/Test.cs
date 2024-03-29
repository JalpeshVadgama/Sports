﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;

namespace Sports.Models
{
    public class Test
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Test Type")]
        public TestTypeEnum TypeOfTest { get; set; }

        [DisplayName("Date")]
        public DateTime TestDate { get; set; }
    }
}
