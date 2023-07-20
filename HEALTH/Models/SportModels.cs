using System.ComponentModel.DataAnnotations;

namespace HEALTH.Models
{
    public class SportModels
    {
        public string SportID { get; set; }

        [MaxLength(50)]
        public string SportName { get; set; }
    }
}
