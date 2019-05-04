using System.ComponentModel;
using System;

namespace Sports.Models
{
    public class TestViewModel
    {
        public int Id { get; set; }
        [DisplayName("Number of Participants")]
        public int NoOfParticipants { get; set; }
        [DisplayName("Test Type")]
        public TestTypeEnum TypeOfTest { get; set; }
        [DisplayName("Date")]
        public DateTime TestDate { get; set; }
    }
}
