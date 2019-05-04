using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sports.Models
{
    public class TestDetail
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        
        public int TestId { get; set; }

        [Required]
        public Double Distnace { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("TestId")]
        public Test Test { get; set; }
    }
}
