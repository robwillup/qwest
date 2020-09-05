using System.ComponentModel.DataAnnotations;

namespace Quest.Models
{
    public class Feature
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
