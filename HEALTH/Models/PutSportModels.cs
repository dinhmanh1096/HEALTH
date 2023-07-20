using System.ComponentModel.DataAnnotations;

namespace HEALTH.Models
{
    public class PutSportModels
    {
        [MaxLength(50)]
        public string SportName { get; set; }
    }
}
