using Quest.Validators;
using System.ComponentModel.DataAnnotations;

namespace Quest.Models
{
    public class Feature
    {
        [Required, Name]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
    }
}
