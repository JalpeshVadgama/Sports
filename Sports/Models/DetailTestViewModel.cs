using System.ComponentModel;
using System;
using System.Collections.Generic;

namespace Sports.Models
{
    public class DetailTestViewModel
    {
        public int Id { get; set; }

        [DisplayName("Test Type")]
        public TestTypeEnum TypeOfTest { get; set; }

        [DisplayName("Date")]
        public DateTime TestDate { get; set; }

        public List<TestDetailViewModel> TestDetails { get; set; }

        public DetailTestViewModel()
        {
            TestDetails = new List<TestDetailViewModel>();
        }
    }
}
