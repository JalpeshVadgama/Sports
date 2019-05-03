﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;

namespace Sports.Models
{
    public class Test
    {
        public int Id { get; set; }
        [Required]
        public TestTypeEnum TypeOfTest { get; set; }
        public DateTime TestDate { get; set; }
    }

    public enum TestTypeEnum
    {
        [Description("Cooper Test")]
        Coopertest =1,

        [Description("100 Meter Sprint")]
        HundredMeterSprint =2,
    }

    public class TestType :  EnumBase<TestTypeEnum>
    {
        public TestType() : base() { } //for EF
        private TestType(TestTypeEnum e) : base(e) { }

        public static implicit operator TestType(TestTypeEnum @enum) => new TestType(@enum);
        public static implicit operator TestTypeEnum(TestType classObj) => (TestTypeEnum)classObj.id;
    }
}