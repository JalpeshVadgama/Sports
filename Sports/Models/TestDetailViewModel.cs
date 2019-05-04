using System.ComponentModel;

namespace Sports.Models
{
    public class TestDetailViewModel
    {
        public int TestDetailId { get; set; }

        [DisplayName("Athlete")]
        public string User { get; set; }
        [DisplayName("Fitness Ranking")]
        public string FitnessRanking { get; set; }
        [DisplayName("Distance(Meters)")]
        public double Distnace { get; set; }
      
    }
}
