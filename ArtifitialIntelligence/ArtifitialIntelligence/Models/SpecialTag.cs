using System.ComponentModel.DataAnnotations;

namespace ArtifitialIntelligence.Models

{
    public class SpecialTag
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Category Name")]
        public string SpecialTagName { get; set; }
    }
}
